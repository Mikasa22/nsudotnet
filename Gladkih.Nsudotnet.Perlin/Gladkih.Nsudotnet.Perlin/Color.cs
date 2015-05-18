namespace Gladkih.Nsudotnet.Perlin
{
    class Color
    {
        private readonly double _r;
        private readonly double _g;
        private readonly double _b;

        public Color(double r = 0, double g = 0, double b = 0)
        {
            _r = r;
            _g = g;
            _b = b;
        }
        public int R
        {
            get { return RoundColor(_r); }
        }

        public int G
        {
            get { return RoundColor(_g); }
        }

        public int B
        {
            get { return RoundColor(_b); }
        }

        private static int RoundColor(double color)
        {
            if (0 > color)
                return 0;
            if (255 < color)
                return 255;
            return (int) color;
        }

        public static Color operator *(Color color, double k)
        {

            return new Color(color._r * k, color._g * k, color._b * k);
        }

        public static Color operator *(double k, Color color)
        {
            return color * k;
        }

        public static Color operator +(Color color1, Color color2)
        {
            return new Color(color1._r + color2._r, color1._g + color2._g, color1._b + color2._b);
        }

        public static Color operator -(Color color1, Color color2)
        {
            return new Color(color1._r - color2._r, color1._g - color2._g, color1._b - color2._b);
        }
    }
}
