using UnityEngine;
using System.Collections.Generic;

namespace Rhythmicdote
{
    // The Allocator is for keeping track of when it's okay to deallocate tiles. Important for multiplayer.
    public class Allocator : MonoBehaviour
    {
        static Dictionary<string, Chunk> chunkRefs;
        static Queue<Chunk> drawQueue;
        bool loaded = false;
        void Start()
        {
            chunkRefs = new Dictionary<string, Chunk>();
            drawQueue = new Queue<Chunk>();
            loaded = true;
        }
        void Update()
        {
            if (!loaded) return;
            while (drawQueue.Count != 0)
            {
                draw(drawQueue.Dequeue());
            }
        }

        private void draw(Chunk chunk)
        {
            // TODO look up chunk, create associated sprites, and pass references into chunk object
        }

        public static void Deallocate(int x, int y)
        {
            Chunk val;
            if (!chunkRefs.TryGetValue(x + "," + y, out val))
            {
                throw new InvalidChunkException();
            }
            if(val.Dereference())
            {
                val.Destroy();
                chunkRefs.Remove(x + "," + y);
            }
        }

        public static void Deallocate(Chunk c)
        {
            if (c == null) return;
            Deallocate(c.Horizontal, c.Vertical);
        }

        public static Chunk Allocate(int indexX, int indexY, int scale)
        {
            Chunk val;
            // if this chunk has already been drawn, add one to the references counter and return it
            if (chunkRefs.TryGetValue(indexX + "," + indexY, out val))
            {
                val.AddReference();
                return val;
            }
            List<Sprite> spriteRefs = new List<Sprite>();
            val = new Chunk(indexX, indexY, scale, spriteRefs);
            chunkRefs.Add(indexX + "," + indexY, val);
            drawQueue.Enqueue(val);
            return val;
        }
    }
}
