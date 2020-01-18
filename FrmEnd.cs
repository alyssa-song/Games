using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FrmEnd : Form
    {
        int myScore;

        public FrmEnd(int myScore)
        {
            InitializeComponent();

            // Display score
            this.myScore = myScore;
            lblScore.Text = "SCORE:   " + Convert.ToString(myScore);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // If player plays again, hide and close current form, open front form
            this.Hide();
            this.Close();
            FrmFront myGame = new FrmFront();
            myGame.ShowDialog();
        }

        private void lblScore_Click_1(object sender, EventArgs e)
        {

        }
    }
}
