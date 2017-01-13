using System;
using UnityEngine;

namespace Rhythmicdote
{
    public class CardinalGrid
    {
        Chunk[,] cardinalGrid;
        int scale;
        public int IndexHorizontal { get; private set; }
        public int IndexVertical { get; private set; }
        public CardinalGrid(GameState state)
        {
            cardinalGrid = new Chunk[5, 5];
            scale = Settings.GetScale();
            populate(state);
        }
        private void populate(GameState state)
        {
            calculateIndex(state);
            for(int i=1;i<4;i++)
            {
                for(int j=1;j<4;j++)
                {
                    cardinalGrid[i, j] = Allocator.Allocate(i + IndexHorizontal - 2, j + IndexVertical - 2, scale);
                }
            }
        }
        private void calculateIndex(GameState state)
        {
            IndexHorizontal = (int)Math.Floor(state.Horizontal_Coord * GlobalFunctions.PIXELS_PER_UNIT / (scale * GlobalFunctions.TILE_SIZE));
            IndexVertical = (int)Math.Floor(state.Vertical_Coord * GlobalFunctions.PIXELS_PER_UNIT / (scale * GlobalFunctions.TILE_SIZE));
        }
        public void Update(GameState state)
        {
            int oldIndexHorizontal = IndexHorizontal;
            int oldIndexVertical = IndexVertical;
            calculateIndex(state);
            if(IndexHorizontal > oldIndexHorizontal)
            {
                moveEast();
            }
            else if(IndexHorizontal < oldIndexHorizontal)
            {
                moveWest();
            }
            if(IndexVertical > oldIndexVertical)
            {
                moveSouth();
            }
            else if(IndexVertical < oldIndexVertical)
            {
                moveNorth();
            }
        }

        private void moveEast()
        {
            for (int j=0; j<5; j++)
            {
                Allocator.Deallocate(cardinalGrid[0, j]);
                for(int i=0; i<4; i++)
                {
                    cardinalGrid[i, j] = cardinalGrid[i + 1, j];
                }
                cardinalGrid[4, j] = null;
            }
            if (cardinalGrid[3, 2] == null)
                cardinalGrid[3, 2] = Allocator.Allocate(IndexHorizontal + 1, IndexVertical, scale);
            if (cardinalGrid[3, 1] == null)
                cardinalGrid[3, 1] = Allocator.Allocate(IndexHorizontal + 1, IndexVertical - 1, scale);
            if (cardinalGrid[3, 3] == null)
                cardinalGrid[3, 3] = Allocator.Allocate(IndexHorizontal + 1, IndexVertical + 1, scale);
        }

        private void moveWest()
        {
            for (int j = 0; j < 5; j++)
            {
                Allocator.Deallocate(cardinalGrid[4, j]);
                for (int i = 4; i > 0; i--)
                {
                    cardinalGrid[i, j] = cardinalGrid[i - 1, j];
                }
                cardinalGrid[0, j] = null;
            }
            if (cardinalGrid[1, 2] == null)
                cardinalGrid[1, 2] = Allocator.Allocate(IndexHorizontal - 1, IndexVertical, scale);
            if (cardinalGrid[1, 1] == null)
                cardinalGrid[1, 1] = Allocator.Allocate(IndexHorizontal - 1, IndexVertical - 1, scale);
            if (cardinalGrid[1, 3] == null)
                cardinalGrid[1, 3] = Allocator.Allocate(IndexHorizontal - 1, IndexVertical + 1, scale);
        }

        private void moveSouth()
        {
            for (int i = 0; i < 5; i++)
            {
                Allocator.Deallocate(cardinalGrid[i, 0]);
                for (int j = 0; j < 4; j++)
                {
                    cardinalGrid[i, j] = cardinalGrid[i, j+1];
                }
                cardinalGrid[i, 4] = null;
            }
            if (cardinalGrid[2, 3] == null)
                cardinalGrid[2, 3] = Allocator.Allocate(IndexHorizontal, IndexVertical + 1, scale);
            if (cardinalGrid[1, 3] == null)
                cardinalGrid[1, 3] = Allocator.Allocate(IndexHorizontal - 1, IndexVertical + 1, scale);
            if (cardinalGrid[3, 3] == null)
                cardinalGrid[3, 3] = Allocator.Allocate(IndexHorizontal + 1, IndexVertical + 1, scale);
        }

        private void moveNorth()
        {
            for (int i = 0; i < 5; i++)
            {
                Allocator.Deallocate(cardinalGrid[i, 4]);
                for (int j = 4; j > 0; j--)
                {
                    cardinalGrid[i, j] = cardinalGrid[i, j - 1];
                }
                cardinalGrid[i, 0] = null;
            }
            if (cardinalGrid[2, 1] == null)
                cardinalGrid[2, 1] = Allocator.Allocate(IndexHorizontal, IndexVertical - 1, scale);
            if (cardinalGrid[1, 1] == null)
                cardinalGrid[1, 1] = Allocator.Allocate(IndexHorizontal - 1, IndexVertical - 1, scale);
            if (cardinalGrid[3, 1] == null)
                cardinalGrid[3, 1] = Allocator.Allocate(IndexHorizontal + 1, IndexVertical - 1, scale);
        }

        public string Display()
        {
            string ret = "";
            for (int j = 4; j >= 0; j--)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (cardinalGrid[i, j] == null)
                        ret += "( null )\t\t";
                    else
                        ret += "(" + cardinalGrid[i,j].Horizontal + "," + cardinalGrid[i, j].Vertical + ")\t\t";
                }
                ret += "\n";
            }
            return ret;
        }
    }
}