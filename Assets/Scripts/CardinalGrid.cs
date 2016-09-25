using UnityEngine;
using System.Collections;

namespace Rhythmicdote
{
    public class CardinalGrid
    {
        Chunk[,] cardinalGrid;
        int scale;
        int indexX, indexY;
        Allocator allocator;
        public CardinalGrid(int posX, int posY, int scale, Allocator alloc)
        {
            this.scale = scale;
            cardinalGrid = new Chunk[5, 5];
            allocate(posX, posY, scale);
        }
        private void allocate(int posX, int posY, int scale)
        {
            indexX = (int)Mathf.Floor(posX / (scale * GlobalFunctions.TILE_SIZE));
            indexY = (int)Mathf.Floor(posY / (scale * GlobalFunctions.TILE_SIZE));
            for(int i=1;i<4;i++)
            {
                for(int j=1;j<4;j++)
                {
                    cardinalGrid[i, j] = new Chunk(i + indexX - 2, j + indexY - 2, scale);
                }
            }
        }

        public void update(int posX, int posY)
        {
            int oldX = indexX;
            int oldY = indexY;
            indexX = (int)Mathf.Floor(posX / (scale * GlobalFunctions.TILE_SIZE));
            indexY = (int)Mathf.Floor(posY / (scale * GlobalFunctions.TILE_SIZE));
            if(indexX > oldX)
            {
                shiftEast();
            }
            else if(indexX < oldX)
            {
                shiftWest();
            }
            if(indexY > oldY)
            {
                shiftSouth();
            }
            else if(indexY < oldY)
            {
                shiftNorth();
            }
        }

        private void shiftEast()
        {
            for(int j=0; j<5; j++)
            {
                allocatorcardinalGrid[0,j]
            }
        }
    }
}