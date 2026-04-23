from __future__ import annotations

from bisect import bisect_right
from dataclasses import dataclass
import math
import random
from statistics import NormalDist
from typing import Iterable, List, Sequence

MANDATORY_SAMPLE_SIZES: tuple[int, ...] = (10, 100, 1000, 10000)

CHI_SQUARE_CRITICAL_0_05 = {
    1: 3.841,
    2: 5.991,
    3: 7.815,
    4: 9.488,
    5: 11.070,
    6: 12.592,
    7: 14.067,
    8: 15.507,
    9: 16.919,
    10: 18.307,
    11: 19.675,
    12: 21.026,
    13: 22.362,
    14: 23.685,
    15: 24.996,
    16: 26.296,
    17: 27.587,
    18: 28.869,
    19: 30.144,
    20: 31.410,
    21: 32.671,
    22: 33.924,
    23: 35.172,
    24: 36.415,
    25: 37.652,
    26: 38.885,
    27: 40.113,
    28: 41.337,
    29: 42.557,
    30: 43.773,
}


@dataclass(slots=True)
class DiscreteRunResult:
    n: int
    counts: list[int]
    empirical_probabilities: list[float]
    sample_mean: float
    sample_variance: float
    mean_relative_error_pct: float
    variance_relative_error_pct: float
    chi_square: float
    chi_square_critical: float
    chi_square_passed: bool


@dataclass(slots=True)
class DiscreteExperimentResult:
    values: list[float]
    probabilities: list[float]
    theoretical_mean: float
    theoretical_variance: float
    runs: list[DiscreteRunResult]


@dataclass(slots=True)
class NormalRunResult:
    n: int
    samples: list[float]
    sample_mean: float
    sample_variance: float
    mean_relative_error_pct: float
    variance_relative_error_pct: float
    chi_square: float
    chi_square_critical: float
    chi_square_passed: bool
    histogram_bin_count: int


@dataclass(slots=True)
class NormalExperimentResult:
    target_mean: float
    target_variance: float
    runs: list[NormalRunResult]


def parse_numeric_list(text: str) -> list[float]:
    normalized = text.replace(";", ",").replace(" ", "")
    if not normalized:
        raise ValueError("Input list is empty.")
    chunks = [item for item in normalized.split(",") if item != ""]
    if not chunks:
        raise ValueError("Input list is empty.")
    return [float(item) for item in chunks]


def prepare_distribution(values: Sequence[float], probabilities: Sequence[float]) -> tuple[list[float], list[float]]:
    if len(values) < 2:
        raise ValueError("At least two values are required.")

    vals = list(values)
    probs = list(probabilities)

    if len(probs) == len(vals) - 1:
        last_probability = 1.0 - sum(probs)
        probs.append(last_probability)

    if len(probs) != len(vals):
        raise ValueError("Number of values and probabilities must match.")

    if any(p < 0 for p in probs):
        raise ValueError("Probabilities must be non-negative.")

    total_probability = sum(probs)
    if total_probability <= 0:
        raise ValueError("Sum of probabilities must be positive.")

    if not math.isclose(total_probability, 1.0, rel_tol=1e-9, abs_tol=1e-9):
        probs = [p / total_probability for p in probs]

    if any(p == 0 for p in probs):
        raise ValueError("Every probability must be greater than zero for chi-square test.")

    return vals, probs


def theoretical_mean(values: Sequence[float], probabilities: Sequence[float]) -> float:
    return sum(v * p for v, p in zip(values, probabilities))


def theoretical_variance(values: Sequence[float], probabilities: Sequence[float], mean_value: float | None = None) -> float:
    mu = theoretical_mean(values, probabilities) if mean_value is None else mean_value
    return sum(((v - mu) ** 2) * p for v, p in zip(values, probabilities))


def sample_mean(samples: Sequence[float]) -> float:
    return sum(samples) / len(samples)


def sample_population_variance(samples: Sequence[float], mean_value: float | None = None) -> float:
    if not samples:
        raise ValueError("Sample must contain at least one element.")
    mu = sample_mean(samples) if mean_value is None else mean_value
    return sum((x - mu) ** 2 for x in samples) / len(samples)


def relative_error_percent(estimate: float, reference: float) -> float:
    if math.isclose(reference, 0.0, abs_tol=1e-12):
        return 0.0 if math.isclose(estimate, 0.0, abs_tol=1e-12) else math.inf
    return abs((estimate - reference) / reference) * 100.0


def chi_square_critical_value(df: int, alpha: float = 0.05) -> float:
    if df < 1:
        raise ValueError("Degrees of freedom must be >= 1.")
    if not math.isclose(alpha, 0.05, rel_tol=0.0, abs_tol=1e-12):
        raise ValueError("Only alpha = 0.05 is supported in this implementation.")

    known = CHI_SQUARE_CRITICAL_0_05.get(df)
    if known is not None:
        return known

    z = NormalDist().inv_cdf(1.0 - alpha)
    term = 1.0 - (2.0 / (9.0 * df)) + z * math.sqrt(2.0 / (9.0 * df))
    return df * (term ** 3)


def run_discrete_once(
    values: Sequence[float],
    probabilities: Sequence[float],
    n: int,
    rng: random.Random,
    mean_ref: float,
    variance_ref: float,
) -> DiscreteRunResult:
    if n <= 0:
        raise ValueError("Sample size must be positive.")

    samples = rng.choices(values, weights=probabilities, k=n)
    counts = [0] * len(values)
    index_map = {value: idx for idx, value in enumerate(values)}
    for value in samples:
        counts[index_map[value]] += 1

    empirical_probs = [count / n for count in counts]
    mu = sample_mean(samples)
    var = sample_population_variance(samples, mu)

    chi_square = 0.0
    for observed, probability in zip(counts, probabilities):
        expected = n * probability
        chi_square += ((observed - expected) ** 2) / expected

    df = len(values) - 1
    chi_critical = chi_square_critical_value(df)

    return DiscreteRunResult(
        n=n,
        counts=counts,
        empirical_probabilities=empirical_probs,
        sample_mean=mu,
        sample_variance=var,
        mean_relative_error_pct=relative_error_percent(mu, mean_ref),
        variance_relative_error_pct=relative_error_percent(var, variance_ref),
        chi_square=chi_square,
        chi_square_critical=chi_critical,
        chi_square_passed=chi_square < chi_critical,
    )


def run_discrete_experiment(
    values: Sequence[float],
    probabilities: Sequence[float],
    sample_sizes: Iterable[int],
    seed: int | None = None,
) -> DiscreteExperimentResult:
    vals, probs = prepare_distribution(values, probabilities)
    mu_ref = theoretical_mean(vals, probs)
    var_ref = theoretical_variance(vals, probs, mu_ref)

    rng = random.Random(seed)
    runs = [run_discrete_once(vals, probs, n, rng, mu_ref, var_ref) for n in sample_sizes]

    return DiscreteExperimentResult(
        values=vals,
        probabilities=probs,
        theoretical_mean=mu_ref,
        theoretical_variance=var_ref,
        runs=runs,
    )


def generate_normal_samples(mean_value: float, variance_value: float, n: int, rng: random.Random) -> list[float]:
    if variance_value <= 0:
        raise ValueError("Variance must be positive.")
    if n <= 0:
        raise ValueError("Sample size must be positive.")

    sigma = math.sqrt(variance_value)
    result: list[float] = []

    while len(result) < n:
        u1 = max(rng.random(), 1e-12)
        u2 = rng.random()
        magnitude = math.sqrt(-2.0 * math.log(u1))
        z1 = magnitude * math.cos(2.0 * math.pi * u2)
        z2 = magnitude * math.sin(2.0 * math.pi * u2)

        result.append(mean_value + sigma * z1)
        if len(result) < n:
            result.append(mean_value + sigma * z2)

    return result


def normal_pdf(x: float, mean_value: float, sigma: float) -> float:
    coefficient = 1.0 / (sigma * math.sqrt(2.0 * math.pi))
    exponent = -((x - mean_value) ** 2) / (2.0 * sigma * sigma)
    return coefficient * math.exp(exponent)


def choose_bin_count(n: int) -> int:
    raw = min(12, max(2, round(math.sqrt(n))))
    limited_by_expected = max(2, n // 5)
    return max(2, min(raw, limited_by_expected))


def normal_chi_square_test(samples: Sequence[float], mean_value: float, variance_value: float) -> tuple[float, float, bool]:
    n = len(samples)
    if n < 2:
        raise ValueError("At least two observations are required for chi-square test.")

    sigma = math.sqrt(variance_value)
    dist = NormalDist(mean_value, sigma)

    bin_count = choose_bin_count(n)
    thresholds = [dist.inv_cdf(i / bin_count) for i in range(1, bin_count)]

    observed = [0] * bin_count
    for x in samples:
        idx = bisect_right(thresholds, x)
        observed[idx] += 1

    expected = n / bin_count
    chi_square = sum(((obs - expected) ** 2) / expected for obs in observed)
    df = bin_count - 1
    critical = chi_square_critical_value(df)
    return chi_square, critical, chi_square < critical


def run_normal_once(
    target_mean: float,
    target_variance: float,
    n: int,
    rng: random.Random,
) -> NormalRunResult:
    samples = generate_normal_samples(target_mean, target_variance, n, rng)
    mu = sample_mean(samples)
    var = sample_population_variance(samples, mu)
    chi_square, chi_critical, chi_passed = normal_chi_square_test(samples, target_mean, target_variance)

    return NormalRunResult(
        n=n,
        samples=samples,
        sample_mean=mu,
        sample_variance=var,
        mean_relative_error_pct=relative_error_percent(mu, target_mean),
        variance_relative_error_pct=relative_error_percent(var, target_variance),
        chi_square=chi_square,
        chi_square_critical=chi_critical,
        chi_square_passed=chi_passed,
        histogram_bin_count=max(8, min(40, int(round(math.sqrt(n))))),
    )


def run_normal_experiment(
    target_mean: float,
    target_variance: float,
    sample_sizes: Iterable[int],
    seed: int | None = None,
) -> NormalExperimentResult:
    if target_variance <= 0:
        raise ValueError("Variance must be positive.")

    rng = random.Random(seed)
    runs = [run_normal_once(target_mean, target_variance, n, rng) for n in sample_sizes]

    return NormalExperimentResult(
        target_mean=target_mean,
        target_variance=target_variance,
        runs=runs,
    )


def format_bool_flag(value: bool) -> str:
    return "passed" if value else "failed"
