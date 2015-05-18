using System;

namespace Gladkih.Nsudotnet.Perlin
{
    class Grid
    {
        private readonly Color[,] _resultColors;
        public Grid(int size, int n)
        {
            Random random = new Random();

            var gridColors = new Color[n + 3, n + 3];
            for (int i = 0; i < n + 3; i++)
            {
                for (int j = 0; j < n + 3; j++)
                {
                    gridColors[i, j] = new Color(random.Next(50, 255), random.Next(50, 255), random.Next(50, 255));
                }
            }
            _resultColors = new Color[size, size];

            double step = (double)size/n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Color[,] p = new Color[4, 4];

                    for (int k = 0; k < 4; k++)
                    {
                        for (int m = 0; m < 4; m++)
                        {
                            p[k, m] = gridColors[i + k, j + m];
                        }
                    }

                    CachedBicubicInterpolator interpolator = new CachedBicubicInterpolator(p);

                    for (int x = 0; x <= step; x++)
                    {
                        for (int y = 0; y <= step; y++)
                        {
                            _resultColors[(int)(i*step + x), (int)(j*step + y)] = interpolator.GetValue(x / step, y / step);
                        }
                    }
                }
            }
        }
        public Color GetColor(int x, int y)
        {
            return _resultColors[x, y];
        }
    }
}
