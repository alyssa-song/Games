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
    public partial class FrmFront : Form
    {
        public FrmFront()
        {
            InitializeComponent();
        }

        private void FrmFront_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show instructions
            MessageBox.Show("Use arrow keys to rotate Tetris blocks and move them left and right.\n" +
                "Press space bar to drop Tetris block immediately.\n" +
                "Press “C” key to place upcoming block in the hold area.\n" +
                "Try to get Tetris blocks to form an entire row in order to clear lines and level up.\n" +
                "Each time you level up, the timer speeds up and the difficulty increases.\n");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            // Hide and close current form, open tetris form
            this.Hide();
            FrmTetris myGame = new FrmTetris();
            myGame.ShowDialog();
            this.Close();
        }
    }
}
