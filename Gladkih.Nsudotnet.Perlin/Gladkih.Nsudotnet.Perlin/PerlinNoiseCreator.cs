using System;
using System.Drawing;

namespace Gladkih.Nsudotnet.Perlin
{
    class PerlinNoiseCreator
    {
        private const int NumberOfGrids = 3;
        private readonly Grid[] _grids = new Grid[NumberOfGrids];
        private readonly double[] _coefficients = new double[NumberOfGrids];
        private readonly int _size;
        public PerlinNoiseCreator(int size)
        {
            _size = size;
            for (int i = 0; i < NumberOfGrids; i++)
            {
                _grids[i] = new Grid(_size, 3 * (int)Math.Pow(2, i));
                _coefficients[i] = 0.5/Math.Pow(1.7, i);
            }
        }

        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(_size, _size);

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Color color = new Color();
                    for (int k = 0; k < NumberOfGrids; k++)
                    {
                        if (null != _grids[k].GetColor(i, j))
                        color += _coefficients[k]*_grids[k].GetColor(i, j);
                    }
                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb(color.R, color.G, color.B));
                }
            }

            return bitmap;
        }
    }
}
