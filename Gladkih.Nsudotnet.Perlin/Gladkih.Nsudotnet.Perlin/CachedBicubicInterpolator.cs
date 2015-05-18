using System;

namespace Gladkih.Nsudotnet.Perlin
{
    
    class CachedBicubicInterpolator
    {
        private readonly Color _a00;
        private readonly Color _a01;
        private readonly Color _a02;
        private readonly Color _a03;
        private readonly Color _a10;
        private readonly Color _a11;
        private readonly Color _a12;
        private readonly Color _a13;
        private readonly Color _a20;
        private readonly Color _a21;
        private readonly Color _a22;
        private readonly Color _a23;
        private readonly Color _a30;
        private readonly Color _a31;
        private readonly Color _a32;
        private readonly Color _a33;

        public CachedBicubicInterpolator(Color[,] p)
        {
            _a00 = p[1, 1];
            _a01 = -.5 * p[1, 0] + .5 * p[1, 2];
            _a02 = p[1, 0] - 2.5 * p[1, 1] + 2 * p[1, 2] - .5 * p[1, 3];
            _a03 = -.5 * p[1, 0] + 1.5 * p[1, 1] - 1.5 * p[1, 2] + .5 * p[1, 3];
            _a10 = -.5 * p[0, 1] + .5 * p[2, 1];
            _a11 = .25 * p[0, 0] - .25 * p[0, 2] - .25 * p[2, 0] + .25 * p[2, 2];
            _a12 = -.5 * p[0, 0] + 1.25 * p[0, 1] - p[0, 2] + .25 * p[0, 3]
                        + .5 * p[2, 0] - 1.25 * p[2, 1] + p[2, 2] - .25 * p[2, 3];
            _a13 = .25 * p[0, 0] - .75 * p[0, 1] + .75 * p[0, 2] - .25 * p[0, 3]
                        - .25 * p[2, 0] + .75 * p[2, 1] - .75 * p[2, 2] + .25 * p[2, 3];
            _a20 = p[0, 1] - 2.5 * p[1, 1] + 2 * p[2, 1] - .5 * p[3, 1];
            _a21 = -.5 * p[0, 0] + .5 * p[0, 2] + 1.25 * p[1, 0] - 1.25 * p[1, 2]
                        - p[2, 0] + p[2, 2] + .25 * p[3, 0] - .25 * p[3, 2];
            _a22 = p[0, 0] - 2.5 * p[0, 1] + 2 * p[0, 2] - .5 * p[0, 3] - 2.5 * p[1, 0]
                        + 6.25 * p[1, 1] - 5 * p[1, 2] + 1.25 * p[1, 3] + 2 * p[2, 0]
                        - 5 * p[2, 1] + 4 * p[2, 2] - p[2, 3] - .5 * p[3, 0]
                        + 1.25 * p[3, 1] - p[3, 2] + .25 * p[3, 3];
            _a23 = -.5 * p[0, 0] + 1.5 * p[0, 1] - 1.5 * p[0, 2] + .5 * p[0, 3]
                        + 1.25 * p[1, 0] - 3.75 * p[1, 1] + 3.75 * p[1, 2]
                        - 1.25 * p[1, 3] - p[2, 0] + 3 * p[2, 1] - 3 * p[2, 2] + p[2, 3]
                        + .25 * p[3, 0] - .75 * p[3, 1] + .75 * p[3, 2] - .25 * p[3, 3];
            _a30 = -.5 * p[0, 1] + 1.5 * p[1, 1] - 1.5 * p[2, 1] + .5 * p[3, 1];
            _a31 = .25 * p[0, 0] - .25 * p[0, 2] - .75 * p[1, 0] + .75 * p[1, 2]
                        + .75 * p[2, 0] - .75 * p[2, 2] - .25 * p[3, 0] + .25 * p[3, 2];
            _a32 = -.5 * p[0, 0] + 1.25 * p[0, 1] - p[0, 2] + .25 * p[0, 3]
                        + 1.5 * p[1, 0] - 3.75 * p[1, 1] + 3 * p[1, 2] - .75 * p[1, 3]
                        - 1.5 * p[2, 0] + 3.75 * p[2, 1] - 3 * p[2, 2] + .75 * p[2, 3]
                        + .5 * p[3, 0] - 1.25 * p[3, 1] + p[3, 2] - .25 * p[3, 3];
            _a33 = .25 * p[0, 0] - .75 * p[0, 1] + .75 * p[0, 2] - .25 * p[0, 3]
                        - .75 * p[1, 0] + 2.25 * p[1, 1] - 2.25 * p[1, 2] + .75 * p[1, 3]
                        + .75 * p[2, 0] - 2.25 * p[2, 1] + 2.25 * p[2, 2] - .75 * p[2, 3]
                        - .25 * p[3, 0] + .75 * p[3, 1] - .75 * p[3, 2] + .25 * p[3, 3];

        }
        public Color GetValue(double x, double y)
        {
            double x2 = Math.Pow(x, 2);
            double x3 = Math.Pow(x, 3);
            double y2 = Math.Pow(y, 2);
            double y3 = Math.Pow(y, 3);

            return (_a00 + _a01 * y + _a02 * y2 + _a03 * y3) +
                   (_a10 + _a11 * y + _a12 * y2 + _a13 * y3) * x +
                   (_a20 + _a21 * y + _a22 * y2 + _a23 * y3) * x2 +
                   (_a30 + _a31 * y + _a32 * y2 + _a33 * y3) * x3;
        }
    }
}
