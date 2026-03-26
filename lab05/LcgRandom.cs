using System;

namespace RandomGames
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

        public LcgRandom(long seed)
        {
            _state = seed % _m;
        }

        public double NextDouble()
        {
            _state = (_a * _state + _c) % _m;
            return (double)_state / _m;
        }

        /// <summary>
        /// Возвращает случайное целое в диапазоне [0, max).
        /// </summary>
        public int NextInt(int max)
        {
            return (int)(NextDouble() * max);
        }
    }
}