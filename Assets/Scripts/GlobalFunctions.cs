using UnityEngine;
using System.Collections;

namespace Rhythmicdote
{
    public class GlobalFunctions
    {
        public const int PIXELS_PER_UNIT = 60;
        public const int TILE_SIZE = 360;
        public static float snap(float val)
        {
            return Mathf.Round(val * PIXELS_PER_UNIT) / PIXELS_PER_UNIT;
        }
    }
}