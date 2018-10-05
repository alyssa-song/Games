using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Block
    {
        Brush myBrush;
        Pen myPen = new Pen(Color.White);


        public Block(Brush myBrush)
        {
            this.myBrush = myBrush;

        }

        public void Draw(Graphics g, int curRow, int curCol, int width, int height)
        {
            g.FillRectangle(myBrush, new Rectangle(curCol + 1, curRow + 1, width - 1, height - 1));
        }

        public void Outline(Graphics g, int curRow, int curCol, int width, int height)
        {
            g.DrawRectangle(myPen, new Rectangle(curCol, curRow, width, height));
        }
    }
}
