using System;

namespace Rhythmicdote
{
    public class GlobalFunctions
    {
        public const int PIXELS_PER_UNIT = 40;
        public const int TILE_SIZE = 360;
        public static float Snap(double val)
        {
            return (float)Math.Round(val * PIXELS_PER_UNIT) / PIXELS_PER_UNIT;
        }
    }
}