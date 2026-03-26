namespace RandomSensor.Core
{
    /// <summary>
    /// Линейный конгруэнтный генератор (LCG).
    /// </summary>
    public class LcgRandom
    {
        private long _state;
        private readonly long _a = 1103515245;
        private readonly long _c = 12345;
        private readonly long _m = 1L << 31;

        public LcgRandom(long seed) => _state = seed % _m;

        public double NextDouble()
        {
            _state = (_a * _state + _c) % _m;
            return (double)_state / _m;
        }
    }

    /// <summary>
    /// Накопление статистики для выборки.
    /// </summary>
    public class SampleStatistics
    {
        private long _count;
        private double _sum;
        private double _sumSq;

        public long Count => _count;
        public double Sum => _sum;
        public double SumSq => _sumSq;

        public void Add(double value)
        {
            _count++;
            _sum += value;
            _sumSq += value * value;
        }

        public void Reset()
        {
            _count = 0;
            _sum = 0;
            _sumSq = 0;
        }

        public double Mean => _count == 0 ? 0 : _sum / _count;
        public double Variance => _count == 0 ? 0 : (_sumSq / _count) - (Mean * Mean);
    }
}