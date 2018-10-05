namespace Tetris
{
    partial class FrmTetris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrPiece = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLines = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblHold = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrPiece
            // 
            this.tmrPiece.Enabled = true;
            this.tmrPiece.Tick += new System.EventHandler(this.tmrPiece_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLevel.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblLevel.Location = new System.Drawing.Point(36, 200);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(120, 70);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblLevel.Click += new System.EventHandler(this.lblLevel_Click);
            // 
            // lblLines
            // 
            this.lblLines.BackColor = System.Drawing.Color.Transparent;
            this.lblLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLines.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblLines.Location = new System.Drawing.Point(36, 290);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(120, 70);
            this.lblLines.TabIndex = 5;
            this.lblLines.Text = "Lines";
            this.lblLines.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNext
            // 
            this.lblNext.BackColor = System.Drawing.Color.Transparent;
            this.lblNext.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNext.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblNext.Location = new System.Drawing.Point(428, 50);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(120, 130);
            this.lblNext.TabIndex = 6;
            this.lblNext.Text = "Next";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimer.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTimer.Location = new System.Drawing.Point(428, 200);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(120, 50);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // lblHold
            // 
            this.lblHold.AccessibleName = "lblHold";
            this.lblHold.BackColor = System.Drawing.Color.Transparent;
            this.lblHold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHold.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHold.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblHold.Location = new System.Drawing.Point(36, 50);
            this.lblHold.Name = "lblHold";
            this.lblHold.Size = new System.Drawing.Size(120, 130);
            this.lblHold.TabIndex = 10;
            this.lblHold.Text = "Hold";
            this.lblHold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHold.Click += new System.EventHandler(this.lblHold_Click);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblScore.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblScore.Location = new System.Drawing.Point(36, 381);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(120, 70);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Score";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblScore.Click += new System.EventHandler(this.lblScore_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Image = global::Tetris.Properties.Resources.pause_play;
            this.pictureBox1.Location = new System.Drawing.Point(458, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Enabled = true;
            this.tmrMusic.Interval = 1000;
            this.tmrMusic.Tick += new System.EventHandler(this.tmrMusic_Tick);
            // 
            // FrmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblHold);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblLines);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FrmTetris";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.FrmTetris_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmTetris_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTetris_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrPiece;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblHold;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer tmrMusic;
    }
}

