using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    
    class Piece: TetrisBoard
    {
        int blockType;
 
        public Piece(int xOffset, int yOffset, int numCols, int numRows, int gridWidth, int gridHeight, int blockType, int blockRotation) : base(xOffset, yOffset, numCols, numRows, gridWidth, gridHeight)
        {
            this.blockType = blockType;

            if (blockType == 1)
            {
                if (blockRotation % 4 == 1 || blockRotation % 4 == 3)
                {
                    // straight block original position
                    this.AddBlock(new Block(Brushes.Cyan), 0, 0);
                    this.AddBlock(new Block(Brushes.Cyan), 0, 1);
                    this.AddBlock(new Block(Brushes.Cyan), 0, 2);
                    this.AddBlock(new Block(Brushes.Cyan), 0, 3);
                }

                if (blockRotation % 4 == 2 || blockRotation % 4 == 0)
                {
                    // straight block alternate position
                    this.AddBlock(new Block(Brushes.Cyan), 0, 2);
                    this.AddBlock(new Block(Brushes.Cyan), 1, 2);
                    this.AddBlock(new Block(Brushes.Cyan), 2, 2);
                    this.AddBlock(new Block(Brushes.Cyan), 3, 2);
                }
            }

            if (blockType == 2)
            {
                // square block only osition
                this.AddBlock(new Block(Brushes.Yellow), 0, 1);
                this.AddBlock(new Block(Brushes.Yellow), 1, 1);
                this.AddBlock(new Block(Brushes.Yellow), 0, 2);
                this.AddBlock(new Block(Brushes.Yellow), 1, 2);
            }

            if (blockType == 3)
            {
                // 's' block original position
                if (blockRotation%4==1)
                {
                    this.AddBlock(new Block(Brushes.Red), 0, 1);
                    this.AddBlock(new Block(Brushes.Red), 0, 2);
                    this.AddBlock(new Block(Brushes.Red), 1, 1);
                    this.AddBlock(new Block(Brushes.Red), 1, 0);
                }

                if (blockRotation % 4 == 2)
                {
                    this.AddBlock(new Block(Brushes.Red), 0, 1);
                    this.AddBlock(new Block(Brushes.Red), 1, 1);
                    this.AddBlock(new Block(Brushes.Red), 1, 2);
                    this.AddBlock(new Block(Brushes.Red), 2, 2);
                }

                if (blockRotation % 4 == 3)
                {
                    this.AddBlock(new Block(Brushes.Red), 1, 1);
                    this.AddBlock(new Block(Brushes.Red), 1, 2);
                    this.AddBlock(new Block(Brushes.Red), 2, 0);
                    this.AddBlock(new Block(Brushes.Red), 2, 1);
                }

                if (blockRotation % 4 == 0)
                {
                    this.AddBlock(new Block(Brushes.Red), 0, 0);
                    this.AddBlock(new Block(Brushes.Red), 1, 0);
                    this.AddBlock(new Block(Brushes.Red), 1, 1);
                    this.AddBlock(new Block(Brushes.Red), 2, 1);
                }
            }

            if (blockType == 4)
            {
                // 'z' block original position
                if (blockRotation % 4 == 1|| blockRotation % 4 == 3)
                {
                    this.AddBlock(new Block(Brushes.Green), 0, 0);
                    this.AddBlock(new Block(Brushes.Green), 0, 1);
                    this.AddBlock(new Block(Brushes.Green), 1, 1);
                    this.AddBlock(new Block(Brushes.Green), 1, 2);
                }

                if (blockRotation % 4 == 2|| blockRotation % 4 == 0)
                {
                    this.AddBlock(new Block(Brushes.Green), 1, 0);
                    this.AddBlock(new Block(Brushes.Green), 1, 1);
                    this.AddBlock(new Block(Brushes.Green), 0, 1);
                    this.AddBlock(new Block(Brushes.Green), 2, 0);
                }
            }

            if (blockType == 5)
            {
                // 'L' block original position
                if (blockRotation % 4 == 1)
                {
                    this.AddBlock(new Block(Brushes.Orange), 0, 2);
                    this.AddBlock(new Block(Brushes.Orange), 1, 0);
                    this.AddBlock(new Block(Brushes.Orange), 1, 1);
                    this.AddBlock(new Block(Brushes.Orange), 1, 2);
                }

                if (blockRotation % 4 == 2)
                {
                    this.AddBlock(new Block(Brushes.Orange), 0, 1);
                    this.AddBlock(new Block(Brushes.Orange), 1, 1);
                    this.AddBlock(new Block(Brushes.Orange), 2, 1);
                    this.AddBlock(new Block(Brushes.Orange), 2, 2);
                }

                if (blockRotation % 4 == 3)
                {
                    this.AddBlock(new Block(Brushes.Orange), 2, 0);
                    this.AddBlock(new Block(Brushes.Orange), 1, 0);
                    this.AddBlock(new Block(Brushes.Orange), 1, 1);
                    this.AddBlock(new Block(Brushes.Orange), 1, 2);
                }

                if (blockRotation % 4 == 0)
                {
                    this.AddBlock(new Block(Brushes.Orange), 0, 1);
                    this.AddBlock(new Block(Brushes.Orange), 1, 1);
                    this.AddBlock(new Block(Brushes.Orange), 2, 1);
                    this.AddBlock(new Block(Brushes.Orange), 0, 0);
                }
            }

            if (blockType == 6)
            {
                // backwards 'L' block original position
                if (blockRotation % 4 == 1)
                {
                    this.AddBlock(new Block(Brushes.Blue), 0, 0);
                    this.AddBlock(new Block(Brushes.Blue), 1, 0);
                    this.AddBlock(new Block(Brushes.Blue), 1, 1);
                    this.AddBlock(new Block(Brushes.Blue), 1, 2);
                }

                if (blockRotation % 4 == 2)
                {
                    this.AddBlock(new Block(Brushes.Blue), 0, 1);
                    this.AddBlock(new Block(Brushes.Blue), 1, 1);
                    this.AddBlock(new Block(Brushes.Blue), 2, 1);
                    this.AddBlock(new Block(Brushes.Blue), 0, 2);
                }

                if (blockRotation % 4 == 3)
                {
                    this.AddBlock(new Block(Brushes.Blue), 2, 2);
                    this.AddBlock(new Block(Brushes.Blue), 1, 0);
                    this.AddBlock(new Block(Brushes.Blue), 1, 1);
                    this.AddBlock(new Block(Brushes.Blue), 1, 2);
                }

                if (blockRotation % 4 == 0)
                {
                    this.AddBlock(new Block(Brushes.Blue), 0, 1);
                    this.AddBlock(new Block(Brushes.Blue), 1, 1);
                    this.AddBlock(new Block(Brushes.Blue), 2, 1);
                    this.AddBlock(new Block(Brushes.Blue), 2, 0);
                }
            }

            if (blockType == 7)
            {
                // hill block original position
                if (blockRotation % 4 == 1)
                {
                    this.AddBlock(new Block(Brushes.Purple), 1, 0);
                    this.AddBlock(new Block(Brushes.Purple), 1, 1);
                    this.AddBlock(new Block(Brushes.Purple), 0, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 2);
                }

                if (blockRotation % 4 == 2)
                {
                    this.AddBlock(new Block(Brushes.Purple), 2, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 1);
                    this.AddBlock(new Block(Brushes.Purple), 0, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 2);
                }

                if (blockRotation % 4 == 3)
                {
                    this.AddBlock(new Block(Brushes.Purple), 1, 0);
                    this.AddBlock(new Block(Brushes.Purple), 1, 1);
                    this.AddBlock(new Block(Brushes.Purple), 2, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 2);
                }

                if (blockRotation % 4 == 0)
                {
                    this.AddBlock(new Block(Brushes.Purple), 2, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 1);
                    this.AddBlock(new Block(Brushes.Purple), 0, 1);
                    this.AddBlock(new Block(Brushes.Purple), 1, 0);
                }
            }
        }

        public int GetBlockType()
        {
            return blockType;
        }

        private void AddBlock(Block toAdd, int curRow, int curCol)
        {
            myBlocks[curRow][curCol] = toAdd;
        }

        public void SetX(int x)
        {
            xOffset = x;
        }

        public void SetY(int y)
        {
            yOffset = y;
        }

        public void ShiftX(int x)
        {
            xOffset += x;
        }

        public void ShiftY(int y)
        {
            yOffset += y;
        }
    }
}
