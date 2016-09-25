using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rhythmicdote
{
    // The Allocator is for keeping track of when it's okay to deallocate tiles. Important for multiplayer.
    public class Allocator
    {
        Dictionary<string, Chunk> chunkRefs = new Dictionary<string, Chunk>();
        public Allocator()
        {

        }

        public void deallocate(Chunk chunk)
        {
            if(!chunkRefs.ContainsKey(chunk))
            {
                throw new InvalidChunkException();
            }
            chunkRefs.chunkRefs.TryGetValue(chunk)
        }

        public Chunk allocate()
        {
            
        }

    }

    public class Chunk
    {
        float size_units;
        int references;
        private Chunk(int indexX, int indexY, int scale)
        {
            size_units = scale * GlobalFunctions.TILE_SIZE / GlobalFunctions.PIXELS_PER_UNIT;
            references = 1;
        }
        public void addRef()
        {
            references++;
        }
        public bool dereference()
        {
            if (--references <= 0)
                return true;
            return false;
        }
    }
}
