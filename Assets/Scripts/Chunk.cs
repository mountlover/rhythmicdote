using System.Collections.Generic;
using UnityEngine;

namespace Rhythmicdote
{
    public class Chunk
    {
        float size_units;
        int references;
        public int Horizontal { get; private set; }
        public int Vertical { get; private set; }
        List<Sprite> spriteRefs;
        public Chunk(int indexX, int indexY, int scale, List<Sprite> spriteRefs)
        {
            this.spriteRefs = spriteRefs;
            Horizontal = indexX;
            Vertical = indexY;
            size_units = scale * GlobalFunctions.TILE_SIZE / GlobalFunctions.PIXELS_PER_UNIT;
            references = 1;
        }
        public void AddReference()
        {
            references++;
        }
        public bool Dereference()
        {
            if (--references <= 0)
                return true;
            return false;
        }
        public void Destroy()
        {
            foreach (Sprite s in spriteRefs)
            {
                Object.Destroy(s);
            }
        }
    }
}