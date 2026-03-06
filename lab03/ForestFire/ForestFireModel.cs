using System;

namespace ForestFire
{
    public enum CellState
    {
        Empty,
        Tree,
        Fire
    }

    public class ForestFireModel
    {
        private readonly Random _rand = new();
        private CellState[,] _grid;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public double ProbTreeStart { get; set; } = 0.5;
        public double LightningProb { get; set; } = 0.001;
        public double RegrowthProb { get; set; } = 0.01;

        public bool WindEnabled { get; set; } = false;
        public int WindDirection { get; set; } = 2;
        public double WindStrength { get; set; } = 0.5;

        public bool HumidityEnabled { get; set; } = false;
        public double HumidityLevel { get; set; } = 0.5;

        public bool TemperatureEnabled { get; set; } = false;
        public double TemperatureFactor { get; set; } = 0.5;

        private static readonly (int dx, int dy)[] Neighbors = new[]
        {
            (-1, -1), (0, -1), (1, -1),
            (-1, 0),           (1, 0),
            (-1, 1),  (0, 1),  (1, 1)
        };

        private static readonly (int dx, int dy)[] WindVectors = new[]
        {
            (0, -1), (1, -1), (1, 0), (1, 1),
            (0, 1), (-1, 1), (-1, 0), (-1, -1)
        };

        public ForestFireModel(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new CellState[height, width];
        }

        public void Randomize()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    _grid[y, x] = _rand.NextDouble() < ProbTreeStart ? CellState.Tree : CellState.Empty;
        }

        public void Clear()
        {
            Array.Clear(_grid, 0, _grid.Length);
        }

        public void Resize(int newWidth, int newHeight)
        {
            Width = newWidth;
            Height = newHeight;
            _grid = new CellState[Height, Width];
        }

        public CellState GetCell(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return _grid[y, x];
            return CellState.Empty;
        }

        public void SetCell(int x, int y, CellState state)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                _grid[y, x] = state;
        }

        public void Step()
        {
            var newGrid = (CellState[,])_grid.Clone();

            (int dx, int dy) windVec = (0, 0);
            if (WindEnabled)
                windVec = WindVectors[WindDirection];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var state = _grid[y, x];

                    if (state == CellState.Fire)
                    {
                        newGrid[y, x] = CellState.Empty;
                    }
                    else if (state == CellState.Tree)
                    {
                        double catchProb = 0.0;

                        for (int i = 0; i < Neighbors.Length; i++)
                        {
                            int nx = x + Neighbors[i].dx;
                            int ny = y + Neighbors[i].dy;
                            if (nx >= 0 && nx < Width && ny >= 0 && ny < Height && _grid[ny, nx] == CellState.Fire)
                            {
                                double p = 1.0;

                                if (HumidityEnabled)
                                    p *= (1.0 - HumidityLevel);

                                if (TemperatureEnabled)
                                    p *= (1.0 + TemperatureFactor);

                                if (WindEnabled)
                                {
                                    if (-Neighbors[i].dx == windVec.dx && -Neighbors[i].dy == windVec.dy)
                                        p *= (1.0 + WindStrength);
                                    else p *= (1.0 - WindStrength);
                                }

                                p = Math.Clamp(p, 0.0, 1.0);
                                catchProb = 1.0 - (1.0 - catchProb) * (1.0 - p);
                                if (catchProb >= 1.0) break;
                            }
                        }

                        if (catchProb < 1.0 && _rand.NextDouble() < LightningProb)
                            catchProb = 1.0;

                        if (_rand.NextDouble() < catchProb)
                            newGrid[y, x] = CellState.Fire;
                        else
                            newGrid[y, x] = CellState.Tree;
                    }
                    else
                    {
                        if (_rand.NextDouble() < RegrowthProb)
                            newGrid[y, x] = CellState.Tree;
                        else
                            newGrid[y, x] = CellState.Empty;
                    }
                }
            }

            _grid = newGrid;
        }
    }
}