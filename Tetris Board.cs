using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class TetrisBoard
    {
        // Variables for tetris board grid
        static Random rand = new Random();
        protected int xOffset;
        protected int yOffset;
        protected int numCols;
        protected int numRows;
        protected int gridWidth;
        protected int gridHeight;

        // Variables for tetromino blocks
        protected Block[][] myBlocks;
        protected int blockWidth;
        protected int blockHeight;
        protected int blockType;
        protected int blockRotation;

        // Variable keeping track of whether or not hold has already been used during one "turn"
        protected bool hold;

        // Variables for features
        protected bool soundEffect;
        protected int linesCleared = 0;
        protected int linesCombo;
        protected int levels = 0;
        protected int score = 0;

        // Declare different tetromino pieces
        Piece activePiece;
        Piece upcomingPiece;
        Piece holdPiece;
        Piece inbetweenPiece;

        public TetrisBoard(int xOffset, int yOffset, int numCols, int numRows, int gridWidth, int gridHeight)
        {
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.numCols = numCols;
            this.numRows = numRows;
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            this.blockWidth = gridWidth / numCols;
            this.blockHeight = gridHeight / numRows;

            myBlocks = new Block[numRows][];

            // These are block references they are null 
            for (int i = 0; i < numRows; i++) myBlocks[i] = new Block[numCols];
        }

        // Generate upcoming piece
        public void GenerateUpcoming()
        {
            // Generates random block type
            blockType = rand.Next(1, 8);
            blockRotation = 1;

            // If blockType 1 or 2, place in certain location (formatting)
            if (blockType == 1 || blockType == 2)
            {
                upcomingPiece = new Piece(445, 105, 4, 4, 4 * blockWidth, 4 * blockHeight, blockType, blockRotation);
            }
            // If other blockTypes, place in another location (formatting)
            else
            {
                upcomingPiece = new Piece(455, 105, 4, 4, 4 * blockWidth, 4 * blockHeight, blockType, blockRotation);
            }

        }

        // Generate active piece by moving upcoming piece onto tetris board
        public void GeneratePiece()
        {
            // make active piece equal upcoming piece, reset block rotation
            activePiece = upcomingPiece;
            blockRotation = 1;

            // place active piece in specific location
            int dropColumnOffset = (numCols - 4) / 2 * blockWidth;
            activePiece.SetX(dropColumnOffset + xOffset);
            activePiece.SetY(50);

            // Generate new upcoming to replace old one
            GenerateUpcoming();

            // make hold false so that the function hold can be used
            hold = false;
        }

        // Generate hold piece by swapping active piece with hold piece
        public void GenerateHold()
        {
            // First time holding a block, hold piece does not yet exist
            if (holdPiece == null)
            {
                blockRotation = 1;
                RotateBlock();

                holdPiece = activePiece;

                // Depending on block type, place hold piece in certain location
                if (holdPiece.GetBlockType() == 1 || holdPiece.GetBlockType() == 2)
                {
                    holdPiece.SetX(55);
                    holdPiece.SetY(105);
                }
                else
                {
                    holdPiece.SetX(65);
                    holdPiece.SetY(105);
                }

                // Generate new active piece to replace old
                GeneratePiece();
            }
            // hold piece already exists  
            else
            {
                blockRotation = 1;
                RotateBlock();

                // Use place holder inbetween piece to swap pieces
                inbetweenPiece = holdPiece;
                holdPiece = activePiece;

                // Depending on block type, place hold piece in certain location
                if (holdPiece.GetBlockType() == 1 || holdPiece.GetBlockType() == 2)
                {
                    holdPiece.SetX(55);
                    holdPiece.SetY(105);
                }
                else
                {
                    holdPiece.SetX(65);
                    holdPiece.SetY(105);
                }

                // Turn old hold piece into active piece and place in specific location
                int dropColumnOffset = (numCols - 4) / 2 * blockWidth;
                activePiece = inbetweenPiece;
                activePiece.SetX(dropColumnOffset + xOffset);
                activePiece.SetY(50);
            } 
        }

        // Update the position and situation of the piece
        public void Update()
        {
            // Shift active piece down slightly
            activePiece.ShiftY(5);

            // Check for a collision
            bool collides = this.CheckCollision(activePiece);

            // If piece collides, merge into tetris board and generate new active piece
            if (collides)
            {
                activePiece.ShiftY(-5);
                this.MergeInPlace(activePiece);

                GeneratePiece();
            }
        }

        public void DrawGrid(Graphics g, bool drawGrid = true)
        {
            // Draw the grid if requested
            if (drawGrid)
            {
                // Draw the vertical lines
                for (int curX = xOffset; curX <= xOffset + gridWidth; curX += gridWidth / numCols)
                {
                    g.DrawLine(Pens.White, new Point(curX, yOffset), new Point(curX, yOffset + gridHeight));
                }

                // Draw the horizontal lines
                for (int curY = yOffset; curY <= yOffset + gridHeight; curY += gridHeight / numRows)
                {
                    g.DrawLine(Pens.White, new Point(xOffset, curY), new Point(xOffset + gridWidth, curY));
                }
            }

            // Draw the visual of the piece
            DrawBlock(g);
        }

        private void DrawBlock(Graphics g)
        {
            // Draw folled in blocks with an outline
            for (int curRow = 0; curRow < numRows; curRow++)
            {
                for (int curCol = 0; curCol < numCols; curCol++)
                {
                    if (myBlocks[curRow][curCol] != null)
                    {
                        myBlocks[curRow][curCol].Draw(g, curRow * blockHeight + yOffset, curCol * blockWidth + xOffset, blockWidth, blockHeight);
                        myBlocks[curRow][curCol].Outline(g, curRow * blockHeight + yOffset, curCol * blockWidth + xOffset, blockWidth, blockHeight);
                    }
                }
            }

            // Draw active piece
            if (activePiece != null) activePiece.DrawBlock(g);

            if (upcomingPiece != null) upcomingPiece.DrawBlock(g);

            if (holdPiece != null) holdPiece.DrawBlock(g);
        }

        // Check for collision with edge of tetris board or other blocks
        public bool CheckCollision(TetrisBoard otherBoard)
        {
            // Map based on lower edge of blocks in otherBoard
            int thisRowStart = (otherBoard.yOffset - yOffset + blockHeight) / blockHeight;
            int thisColStart = (otherBoard.xOffset - xOffset) / blockWidth;
            int thisRowEnd = thisRowStart + 4;
            int thisColEnd = thisColStart + 4;

            for (int curRow = 0; curRow < otherBoard.numRows; curRow++)
            {
                for (int curCol = 0; curCol < otherBoard.numCols; curCol++)
                {
                    if (otherBoard.myBlocks[curRow][curCol] != null)
                    {   // otherBoard (active piece) has a block at this index

                        // Does not allow block to pass left edge of grid
                        if (thisColStart + curCol < 0 || thisColEnd + curCol > 13)
                        {
                            return true;
                        }

                        // Stops block at the bottom of grid
                        if (thisRowStart + curRow >= myBlocks.Length)
                        {
                            return true;
                        }

                        // otherBoard has a block at this index
                        if (myBlocks[thisRowStart + curRow][thisColStart + curCol] != null)
                        {
                            return true;
                        }
                    }      
                }
            }

            return false;
        }

        public void MergeInPlace(TetrisBoard otherBoard)
        {
            // Map based on lower edge of blocks in otherBoard (active piece)
            int thisRowStart = (otherBoard.yOffset - yOffset + blockHeight) / blockHeight;
            int thisColStart = (otherBoard.xOffset - xOffset) / blockWidth;

            for (int curRow = 0; curRow < otherBoard.numRows; curRow++)
            {
                for (int curCol = 0; curCol < otherBoard.numCols; curCol++)
                {
                    if (otherBoard.myBlocks[curRow][curCol] != null)
                    {   //otherBoard has a block at this index
                        myBlocks[thisRowStart + curRow][thisColStart + curCol] = otherBoard.myBlocks[curRow][curCol];
                    }
                }
            }

            // Check if lines need to be cleared and clear them
            ClearLine();
        }

        // Clear line once complete
        public void ClearLine()
        {
            // Keep track of lines cleared at once
            linesCombo = 0;

            for (int curRow = 0; curRow < 20; curRow++)
            {
                // Keep track of how many blocks exist in a row
                int blockInRow = 0;

                for (int curCol = 0; curCol < 10; curCol++)
                {
                    if (myBlocks[curRow][curCol] != null) 
                    {   // Add 1 to numbe rof blocks in a row
                        blockInRow++;
                    }
                }

                // If a row has ten blocks, it is complete, delete it
                if (blockInRow == 10)
                {
                    for(int curCol = 0; curCol < 10; curCol++)
                    {
                        myBlocks[curRow][curCol] = null;
                    }

                    // Add 1 to lines cleared in a row and 1 to overall lines cleared
                    linesCombo++;
                    linesCleared++; 

                    // Shift blocks above cleared row down and make sound effect true
                    ShiftDown(curRow);
                    soundEffect = true;
                }  
            }
            // Update score
            score = CalculateScore();
        }

        // Shift blocks above cleared line down
        public void ShiftDown(int deletedRow)
        {
            for (int curRow = deletedRow - 1; curRow > 0; curRow--)
            {
                for (int curCol = 0; curCol < 10; curCol++)
                {
                    if (myBlocks[curRow][curCol] != null)
                    {
                        myBlocks[curRow + 1][curCol] = myBlocks[curRow][curCol];
                        myBlocks[curRow][curCol] = null;
                    }
                }
            }
        }

        // Calculate score (add points depending on number of lines cleared at once and current level)
        public int CalculateScore()
        {
            if (linesCombo == 1)
            {
                score = score + 40 * levels;
            }
            else if (linesCombo == 2)
            {
                score = score + 100 * levels;
            }
            else if (linesCombo == 3)
            {
                score = score + 300 * levels;
            }
            else if (linesCombo == 4)
            {
                score = score + 1200 * levels;
            }

            return score;
        }

        // Check for score number
        public int CheckScore()
        {
            return score;
        }

        // Check for line clear
        public bool PlayEffect()
        {
            return soundEffect;
        }

        // Make play sound false
        public void StopEffect()
        {
            if (soundEffect == true) soundEffect = false;
        }

        // Check for level number
        public int CheckLevel()
        {
            levels = 1 + linesCleared / 10;
            return levels;
        }

        // Check for line number
        public int CheckLines()
        {
            return linesCleared;
        }

        // Rotates block
        private void RotateBlock()
        {
            activePiece.myBlocks = null;
            activePiece = new Piece(activePiece.xOffset, activePiece.yOffset, 4, 4, 4 * blockWidth, 4 * blockHeight, activePiece.GetBlockType(), blockRotation);
        }

        // Key controls
        public void ProcessKey(Keys k)
        {
            // Left key moves block left
            if (k == Keys.Left)
            {
                activePiece.ShiftX(-blockWidth);
                if (CheckCollision(activePiece)) activePiece.ShiftX(blockWidth);
            }

            // Right key moves block right
            if (k == Keys.Right)
            {
                activePiece.ShiftX(+blockWidth);
                if (CheckCollision(activePiece)) activePiece.ShiftX(-blockWidth);
            }

            // Down key moves block down slightly
            if (k==Keys.Down)
            {
                activePiece.ShiftY(+blockHeight/4);
                if (CheckCollision(activePiece)) activePiece.ShiftY(-blockHeight/4);
            }

            // Up key rotates block
            if (k==Keys.Up)
            {
                blockRotation++;
                RotateBlock();

                // Do not let block rotate if collision is detected for rotated block
                if (CheckCollision(activePiece))
                {
                    blockRotation--;
                    RotateBlock();
                }
            }

            // Space key moves block all the way down
            if (k==Keys.Space)
            {
                // Shift piece down until it collides
                do
                {
                    activePiece.ShiftY(+blockHeight);
                } while (CheckCollision(activePiece) != true);
                
                // Shift piece up until it is no longer in a collision
                do
                {
                    if (CheckCollision(activePiece)) activePiece.ShiftY(-1);
                } while (CheckCollision(activePiece) == true);
            }

            // C key initiates hold function
            if (k==Keys.C)
            {
                // If hold has not already been used, generate hold
                if (hold == false) GenerateHold();

                // Make hold true so that generate hold can not be used again until the "turn" ends
                hold = true;
            }
        }

        // Check for whether or not the game is over
        public bool GameOver()
        {
            int dropColumnOffset = (numCols - 4) / 2;

            // Game over
            for (int curRow = 0; curRow < 2; curRow++)
            {
                for (int curCol = dropColumnOffset - 1; curCol < dropColumnOffset + 3; curCol++)
                {
                    if (myBlocks[curRow][curCol] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
