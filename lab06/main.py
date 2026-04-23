from __future__ import annotations

import math
import tkinter as tk
from tkinter import messagebox, ttk

from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.figure import Figure

from simulation_core import (
    MANDATORY_SAMPLE_SIZES,
    format_bool_flag,
    normal_pdf,
    parse_numeric_list,
    run_discrete_experiment,
    run_normal_experiment,
)

DEFAULT_DISCRETE_VALUES = "1, 2, 3, 4, 5"
DEFAULT_DISCRETE_PROBABILITIES = "0.26, 0.13, 0.23, 0.21"
DEFAULT_DISCRETE_N = "1000"
DEFAULT_NORMAL_MEAN = "3"
DEFAULT_NORMAL_VARIANCE = "2"
DEFAULT_NORMAL_N = "1000"
DEFAULT_SEED = "42"


class Lab06App:
    def __init__(self, root: tk.Tk) -> None:
        self.root = root
        self.root.title("Lab 06 - Simulation Modeling")
        self.root.geometry("1280x800")
        self.root.minsize(1080, 720)

        style = ttk.Style(self.root)
        style.configure("Treeview", rowheight=26)

        self.notebook = ttk.Notebook(self.root)
        self.notebook.pack(fill="both", expand=True)

        self._build_discrete_tab()
        self._build_normal_tab()

    @staticmethod
    def _parse_seed(seed_text: str) -> int | None:
        seed_text = seed_text.strip()
        if not seed_text:
            return None
        return int(seed_text)

    @staticmethod
    def _fmt(value: float, digits: int = 6) -> str:
        if math.isinf(value):
            return "inf"
        return f"{value:.{digits}f}"

    def _build_discrete_tab(self) -> None:
        tab = ttk.Frame(self.notebook, padding=12)
        self.notebook.add(tab, text="lab06-1: Discrete RV")

        tab.columnconfigure(0, weight=0, minsize=360)
        tab.columnconfigure(1, weight=1)
        tab.rowconfigure(0, weight=1)

        left_panel = ttk.Frame(tab)
        left_panel.grid(row=0, column=0, sticky="nsew", padx=(0, 12))

        right_panel = ttk.Frame(tab)
        right_panel.grid(row=0, column=1, sticky="nsew")
        right_panel.columnconfigure(0, weight=1)
        right_panel.rowconfigure(0, weight=2)
        right_panel.rowconfigure(1, weight=1)

        input_frame = ttk.LabelFrame(left_panel, text="Input data", padding=10)
        input_frame.pack(fill="x")

        self.discrete_values_var = tk.StringVar(value=DEFAULT_DISCRETE_VALUES)
        self.discrete_probs_var = tk.StringVar(value=DEFAULT_DISCRETE_PROBABILITIES)
        self.discrete_n_var = tk.StringVar(value=DEFAULT_DISCRETE_N)
        self.discrete_seed_var = tk.StringVar(value=DEFAULT_SEED)

        ttk.Label(input_frame, text="Values (x_i)").grid(row=0, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.discrete_values_var).grid(row=0, column=1, sticky="ew", pady=4)

        ttk.Label(input_frame, text="Probabilities (p_i)").grid(row=1, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.discrete_probs_var).grid(row=1, column=1, sticky="ew", pady=4)

        hint = "If one probability is missing, it is auto-computed as 1 - sum(other p_i)."
        ttk.Label(input_frame, text=hint, wraplength=320, foreground="#444").grid(
            row=2, column=0, columnspan=2, sticky="w", pady=(0, 8)
        )

        ttk.Label(input_frame, text="Custom sample size N").grid(row=3, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.discrete_n_var).grid(row=3, column=1, sticky="ew", pady=4)

        ttk.Label(input_frame, text="Random seed (optional)").grid(row=4, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.discrete_seed_var).grid(row=4, column=1, sticky="ew", pady=4)

        input_frame.columnconfigure(1, weight=1)

        button_frame = ttk.Frame(left_panel)
        button_frame.pack(fill="x", pady=10)

        ttk.Button(button_frame, text="Run custom N", command=self.run_discrete_custom).pack(fill="x", pady=(0, 6))
        ttk.Button(
            button_frame,
            text="Run N = 10, 100, 1000, 10000",
            command=self.run_discrete_mandatory,
        ).pack(fill="x")

        metric_frame = ttk.LabelFrame(left_panel, text="Current run metrics", padding=10)
        metric_frame.pack(fill="both", expand=True)

        self.discrete_theory_var = tk.StringVar(value="Theoretical: m = -, D = -")
        self.discrete_sample_var = tk.StringVar(value="Sample: m* = -, D* = -")
        self.discrete_error_var = tk.StringVar(value="Relative error: m = -, D = -")
        self.discrete_chi_var = tk.StringVar(value="Chi-square: -")

        ttk.Label(metric_frame, textvariable=self.discrete_theory_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.discrete_sample_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.discrete_error_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.discrete_chi_var, wraplength=320).pack(anchor="w", pady=3)

        chart_frame = ttk.LabelFrame(right_panel, text="Probability comparison", padding=6)
        chart_frame.grid(row=0, column=0, sticky="nsew")
        chart_frame.columnconfigure(0, weight=1)
        chart_frame.rowconfigure(0, weight=1)

        self.discrete_figure = Figure(figsize=(7, 4), dpi=100)
        self.discrete_ax = self.discrete_figure.add_subplot(111)
        self.discrete_canvas = FigureCanvasTkAgg(self.discrete_figure, master=chart_frame)
        self.discrete_canvas.get_tk_widget().grid(row=0, column=0, sticky="nsew")

        table_frame = ttk.LabelFrame(right_panel, text="Series results", padding=6)
        table_frame.grid(row=1, column=0, sticky="nsew", pady=(10, 0))
        table_frame.columnconfigure(0, weight=1)
        table_frame.rowconfigure(0, weight=1)

        columns = ("N", "mean", "var", "err_m", "err_d", "chi2", "chi2_crit", "decision")
        self.discrete_table = ttk.Treeview(table_frame, columns=columns, show="headings")
        self.discrete_table.grid(row=0, column=0, sticky="nsew")

        headers = {
            "N": "N",
            "mean": "m*",
            "var": "D*",
            "err_m": "err m, %",
            "err_d": "err D, %",
            "chi2": "chi2",
            "chi2_crit": "chi2 crit",
            "decision": "Result",
        }
        widths = {"N": 85, "mean": 90, "var": 90, "err_m": 95, "err_d": 95, "chi2": 95, "chi2_crit": 95, "decision": 85}

        for col in columns:
            self.discrete_table.heading(col, text=headers[col])
            self.discrete_table.column(col, width=widths[col], anchor="center")

        scroll = ttk.Scrollbar(table_frame, orient="vertical", command=self.discrete_table.yview)
        self.discrete_table.configure(yscrollcommand=scroll.set)
        scroll.grid(row=0, column=1, sticky="ns")

        self.run_discrete_mandatory()

    def _build_normal_tab(self) -> None:
        tab = ttk.Frame(self.notebook, padding=12)
        self.notebook.add(tab, text="lab06-2: Normal RV")

        tab.columnconfigure(0, weight=0, minsize=360)
        tab.columnconfigure(1, weight=1)
        tab.rowconfigure(0, weight=1)

        left_panel = ttk.Frame(tab)
        left_panel.grid(row=0, column=0, sticky="nsew", padx=(0, 12))

        right_panel = ttk.Frame(tab)
        right_panel.grid(row=0, column=1, sticky="nsew")
        right_panel.columnconfigure(0, weight=1)
        right_panel.rowconfigure(0, weight=2)
        right_panel.rowconfigure(1, weight=1)

        input_frame = ttk.LabelFrame(left_panel, text="Input data", padding=10)
        input_frame.pack(fill="x")

        self.normal_mean_var = tk.StringVar(value=DEFAULT_NORMAL_MEAN)
        self.normal_variance_var = tk.StringVar(value=DEFAULT_NORMAL_VARIANCE)
        self.normal_n_var = tk.StringVar(value=DEFAULT_NORMAL_N)
        self.normal_seed_var = tk.StringVar(value=DEFAULT_SEED)

        ttk.Label(input_frame, text="Mean m").grid(row=0, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.normal_mean_var).grid(row=0, column=1, sticky="ew", pady=4)

        ttk.Label(input_frame, text="Variance D").grid(row=1, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.normal_variance_var).grid(row=1, column=1, sticky="ew", pady=4)

        ttk.Label(input_frame, text="Custom sample size N").grid(row=2, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.normal_n_var).grid(row=2, column=1, sticky="ew", pady=4)

        ttk.Label(input_frame, text="Random seed (optional)").grid(row=3, column=0, sticky="w", pady=4)
        ttk.Entry(input_frame, textvariable=self.normal_seed_var).grid(row=3, column=1, sticky="ew", pady=4)

        input_frame.columnconfigure(1, weight=1)

        button_frame = ttk.Frame(left_panel)
        button_frame.pack(fill="x", pady=10)

        ttk.Button(button_frame, text="Run custom N", command=self.run_normal_custom).pack(fill="x", pady=(0, 6))
        ttk.Button(
            button_frame,
            text="Run N = 10, 100, 1000, 10000",
            command=self.run_normal_mandatory,
        ).pack(fill="x")

        metric_frame = ttk.LabelFrame(left_panel, text="Current run metrics", padding=10)
        metric_frame.pack(fill="both", expand=True)

        self.normal_target_var = tk.StringVar(value="Target: m = -, D = -")
        self.normal_sample_var = tk.StringVar(value="Sample: m* = -, D* = -")
        self.normal_error_var = tk.StringVar(value="Relative error: m = -, D = -")
        self.normal_chi_var = tk.StringVar(value="Chi-square: -")

        ttk.Label(metric_frame, textvariable=self.normal_target_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.normal_sample_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.normal_error_var, wraplength=320).pack(anchor="w", pady=3)
        ttk.Label(metric_frame, textvariable=self.normal_chi_var, wraplength=320).pack(anchor="w", pady=3)

        chart_frame = ttk.LabelFrame(right_panel, text="Histogram and PDF", padding=6)
        chart_frame.grid(row=0, column=0, sticky="nsew")
        chart_frame.columnconfigure(0, weight=1)
        chart_frame.rowconfigure(0, weight=1)

        self.normal_figure = Figure(figsize=(7, 4), dpi=100)
        self.normal_ax = self.normal_figure.add_subplot(111)
        self.normal_canvas = FigureCanvasTkAgg(self.normal_figure, master=chart_frame)
        self.normal_canvas.get_tk_widget().grid(row=0, column=0, sticky="nsew")

        table_frame = ttk.LabelFrame(right_panel, text="Series results", padding=6)
        table_frame.grid(row=1, column=0, sticky="nsew", pady=(10, 0))
        table_frame.columnconfigure(0, weight=1)
        table_frame.rowconfigure(0, weight=1)

        columns = ("N", "mean", "var", "err_m", "err_d", "chi2", "chi2_crit", "decision")
        self.normal_table = ttk.Treeview(table_frame, columns=columns, show="headings")
        self.normal_table.grid(row=0, column=0, sticky="nsew")

        headers = {
            "N": "N",
            "mean": "m*",
            "var": "D*",
            "err_m": "err m, %",
            "err_d": "err D, %",
            "chi2": "chi2",
            "chi2_crit": "chi2 crit",
            "decision": "Result",
        }
        widths = {"N": 85, "mean": 90, "var": 90, "err_m": 95, "err_d": 95, "chi2": 95, "chi2_crit": 95, "decision": 85}

        for col in columns:
            self.normal_table.heading(col, text=headers[col])
            self.normal_table.column(col, width=widths[col], anchor="center")

        scroll = ttk.Scrollbar(table_frame, orient="vertical", command=self.normal_table.yview)
        self.normal_table.configure(yscrollcommand=scroll.set)
        scroll.grid(row=0, column=1, sticky="ns")

        self.run_normal_mandatory()

    def run_discrete_custom(self) -> None:
        try:
            values = parse_numeric_list(self.discrete_values_var.get())
            probabilities = parse_numeric_list(self.discrete_probs_var.get())
            n = int(self.discrete_n_var.get())
            seed = self._parse_seed(self.discrete_seed_var.get())

            result = run_discrete_experiment(values, probabilities, [n], seed)
            run = result.runs[0]
            self._update_discrete_metrics(result.theoretical_mean, result.theoretical_variance, run)
            self._update_discrete_plot(result.values, result.probabilities, run.empirical_probabilities)
        except Exception as exc:
            messagebox.showerror("Error", str(exc))

    def run_discrete_mandatory(self) -> None:
        try:
            values = parse_numeric_list(self.discrete_values_var.get())
            probabilities = parse_numeric_list(self.discrete_probs_var.get())
            seed = self._parse_seed(self.discrete_seed_var.get())

            result = run_discrete_experiment(values, probabilities, MANDATORY_SAMPLE_SIZES, seed)
            self._fill_discrete_table(result)
            last_run = result.runs[-1]
            self._update_discrete_metrics(result.theoretical_mean, result.theoretical_variance, last_run)
            self._update_discrete_plot(result.values, result.probabilities, last_run.empirical_probabilities)
        except Exception as exc:
            messagebox.showerror("Error", str(exc))

    def _fill_discrete_table(self, result) -> None:
        for row in self.discrete_table.get_children():
            self.discrete_table.delete(row)

        for run in result.runs:
            self.discrete_table.insert(
                "",
                "end",
                values=(
                    run.n,
                    self._fmt(run.sample_mean, 4),
                    self._fmt(run.sample_variance, 4),
                    self._fmt(run.mean_relative_error_pct, 2),
                    self._fmt(run.variance_relative_error_pct, 2),
                    self._fmt(run.chi_square, 3),
                    self._fmt(run.chi_square_critical, 3),
                    format_bool_flag(run.chi_square_passed),
                ),
            )

    def _update_discrete_metrics(self, theoretical_mean: float, theoretical_variance: float, run) -> None:
        self.discrete_theory_var.set(
            f"Theoretical: m = {self._fmt(theoretical_mean, 5)}, D = {self._fmt(theoretical_variance, 5)}"
        )
        self.discrete_sample_var.set(
            f"Sample: m* = {self._fmt(run.sample_mean, 5)}, D* = {self._fmt(run.sample_variance, 5)}"
        )
        self.discrete_error_var.set(
            f"Relative error: m = {self._fmt(run.mean_relative_error_pct, 3)}%, D = {self._fmt(run.variance_relative_error_pct, 3)}%"
        )
        self.discrete_chi_var.set(
            f"Chi-square: {self._fmt(run.chi_square, 4)} < {self._fmt(run.chi_square_critical, 4)} -> {format_bool_flag(run.chi_square_passed)}"
        )

    def _update_discrete_plot(
        self,
        values: list[float],
        theoretical_probabilities: list[float],
        empirical_probabilities: list[float],
    ) -> None:
        self.discrete_ax.clear()

        positions = list(range(len(values)))
        width = 0.38
        left_positions = [x - width / 2 for x in positions]
        right_positions = [x + width / 2 for x in positions]

        self.discrete_ax.bar(left_positions, theoretical_probabilities, width=width, label="Theoretical", color="#4c78a8")
        self.discrete_ax.bar(right_positions, empirical_probabilities, width=width, label="Empirical", color="#f58518")

        self.discrete_ax.set_xticks(positions)
        self.discrete_ax.set_xticklabels([str(v) for v in values])
        self.discrete_ax.set_xlabel("x_i")
        self.discrete_ax.set_ylabel("Probability")
        self.discrete_ax.set_title("Discrete distribution: theoretical vs empirical")
        self.discrete_ax.grid(alpha=0.3, axis="y")
        self.discrete_ax.legend(loc="upper right")

        top = max(max(theoretical_probabilities), max(empirical_probabilities))
        self.discrete_ax.set_ylim(0, top * 1.25)
        self.discrete_canvas.draw_idle()

    def run_normal_custom(self) -> None:
        try:
            target_mean = float(self.normal_mean_var.get())
            target_variance = float(self.normal_variance_var.get())
            n = int(self.normal_n_var.get())
            seed = self._parse_seed(self.normal_seed_var.get())

            result = run_normal_experiment(target_mean, target_variance, [n], seed)
            run = result.runs[0]
            self._update_normal_metrics(result.target_mean, result.target_variance, run)
            self._update_normal_plot(result.target_mean, result.target_variance, run)
        except Exception as exc:
            messagebox.showerror("Error", str(exc))

    def run_normal_mandatory(self) -> None:
        try:
            target_mean = float(self.normal_mean_var.get())
            target_variance = float(self.normal_variance_var.get())
            seed = self._parse_seed(self.normal_seed_var.get())

            result = run_normal_experiment(target_mean, target_variance, MANDATORY_SAMPLE_SIZES, seed)
            self._fill_normal_table(result)
            last_run = result.runs[-1]
            self._update_normal_metrics(result.target_mean, result.target_variance, last_run)
            self._update_normal_plot(result.target_mean, result.target_variance, last_run)
        except Exception as exc:
            messagebox.showerror("Error", str(exc))

    def _fill_normal_table(self, result) -> None:
        for row in self.normal_table.get_children():
            self.normal_table.delete(row)

        for run in result.runs:
            self.normal_table.insert(
                "",
                "end",
                values=(
                    run.n,
                    self._fmt(run.sample_mean, 4),
                    self._fmt(run.sample_variance, 4),
                    self._fmt(run.mean_relative_error_pct, 2),
                    self._fmt(run.variance_relative_error_pct, 2),
                    self._fmt(run.chi_square, 3),
                    self._fmt(run.chi_square_critical, 3),
                    format_bool_flag(run.chi_square_passed),
                ),
            )

    def _update_normal_metrics(self, target_mean: float, target_variance: float, run) -> None:
        self.normal_target_var.set(f"Target: m = {self._fmt(target_mean, 5)}, D = {self._fmt(target_variance, 5)}")
        self.normal_sample_var.set(f"Sample: m* = {self._fmt(run.sample_mean, 5)}, D* = {self._fmt(run.sample_variance, 5)}")
        self.normal_error_var.set(
            f"Relative error: m = {self._fmt(run.mean_relative_error_pct, 3)}%, D = {self._fmt(run.variance_relative_error_pct, 3)}%"
        )
        self.normal_chi_var.set(
            f"Chi-square: {self._fmt(run.chi_square, 4)} < {self._fmt(run.chi_square_critical, 4)} -> {format_bool_flag(run.chi_square_passed)}"
        )

    def _update_normal_plot(self, target_mean: float, target_variance: float, run) -> None:
        samples = run.samples
        sigma = math.sqrt(target_variance)

        self.normal_ax.clear()
        self.normal_ax.hist(
            samples,
            bins=run.histogram_bin_count,
            density=True,
            color="#4c78a8",
            alpha=0.55,
            edgecolor="#1f1f1f",
            linewidth=0.5,
            label="Empirical histogram",
        )

        x_min = min(samples)
        x_max = max(samples)
        if math.isclose(x_min, x_max):
            x_min -= 1.0
            x_max += 1.0

        margin = 0.08 * (x_max - x_min)
        x_min -= margin
        x_max += margin

        step_count = 260
        step = (x_max - x_min) / step_count
        x_values = [x_min + i * step for i in range(step_count + 1)]
        y_values = [normal_pdf(x, target_mean, sigma) for x in x_values]

        self.normal_ax.plot(x_values, y_values, color="#e45756", linewidth=2.2, label="Theoretical PDF")
        self.normal_ax.set_title("Normal distribution modeling")
        self.normal_ax.set_xlabel("x")
        self.normal_ax.set_ylabel("Density")
        self.normal_ax.grid(alpha=0.3)
        self.normal_ax.legend(loc="upper right")

        self.normal_canvas.draw_idle()


def main() -> None:
    root = tk.Tk()
    app = Lab06App(root)
    root.mainloop()


if __name__ == "__main__":
    main()
