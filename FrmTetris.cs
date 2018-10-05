using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Tetris
{
    public partial class FrmTetris : Form
    {
        // Background music and sound effects for lines clearing
        // mp from https://archive.org/details/TetrisThemeMusic
        MediaPlayer.MediaPlayer mp = new MediaPlayer.MediaPlayer();
        SoundPlayer sndClear = new SoundPlayer(Properties.Resources.CLEAR);
       
        // Declare objects and variables
        TetrisBoard tb;
        DateTime startTime = DateTime.Now;
        int click = 0;
        bool pause = false;
        int seconds = 0;

        public FrmTetris()
        {
            // Create instance of TetrisBoard
            tb = new TetrisBoard(192, 50, 10, 20, 200, 400);

            tb.GenerateUpcoming();
            tb.GeneratePiece();
            InitializeComponent();
        }

        private void FrmTetris_Paint(object sender, PaintEventArgs e)
        {
            // Get a reference to the graphics object
            Graphics g = e.Graphics;

            // Draw the grid
            tb.DrawGrid(g);
        }

        private void tmrPiece_Tick(object sender, EventArgs e)
        {
            TimeSpan timer = DateTime.Now.Subtract(startTime);

            // Move the piece down
            tmrPiece.Interval = 120 - (tb.CheckLevel() - 1) * 10;
            tb.Update();

            // Update level, lines cleared, score and timer
            lblLevel.Text = "LEVEL\n" + Convert.ToString(tb.CheckLevel());
            lblLines.Text = "LINES\n" + Convert.ToString(tb.CheckLines());
            lblScore.Text = "SCORE\n" + Convert.ToString(tb.CheckScore());
            lblTimer.Text = string.Format("{0}:{1:00}", timer.Minutes, timer.Seconds);

            // If game is over
            if (tb.GameOver())
            {
                // Stop timers
                tmrPiece.Stop();
                tmrMusic.Stop();

                // Stop music, hide and close current form, open end form
                mp.Stop();
                this.Hide();
                this.Close();
                FrmEnd myGame = new FrmEnd(tb.CheckScore());
                myGame.ShowDialog();
            }

            // Check for line clears and play sound effect once
            if (tb.PlayEffect() == true)
            {
                sndClear.Play();
                tb.StopEffect();
            }

            // Redraw the game
            this.Invalidate();
        }

        private void tmrMusic_Tick(object sender, EventArgs e)
        {
            // Replay the song once it is finished
            if (seconds % 85 == 0)
            {
                mp.Open(@"Resources\Tetris.mp3");
                mp.Play();
            }

            seconds++;
        }

        private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            // Process key press only if game is not over or if game is not paused
            if (tb.GameOver() == false && !pause)
            {
                tb.ProcessKey(e.KeyCode);
            }

            // Redraw the game
            this.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            click++;

            // Stop timer if user clicks pause
            if (click % 2 == 1)
            {
                pause = true;
                tmrPiece.Stop();
            }
            // Start timer if user clicks pause again
            else
            {
                pause = false;
                tmrPiece.Start();
            }
        }

        private void FrmTetris_Load(object sender, EventArgs e)
        {

        }

        private void lblLevel_Click(object sender, EventArgs e)
        {

        }

        private void lblHold_Click(object sender, EventArgs e)
        { 

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }
    }
}
