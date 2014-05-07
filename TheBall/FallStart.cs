using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBall
{
    public partial class FallStart : Form
    {
        public int difficulty { get; set; }
        public FallStart()
        {
            InitializeComponent();
            String filePath = System.IO.Path.GetFullPath("FallScoreEasy.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, String.Empty);
            }
            filePath = System.IO.Path.GetFullPath("FallScoreMedium.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, String.Empty);
            }
            filePath = System.IO.Path.GetFullPath("FallScoreHard.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, String.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbEasy.Checked)
            {
                difficulty = 20;
            }
            else if (rbMedium.Checked)
            {
                difficulty = 15;
            }
            else
            {
                difficulty = 13;
            }
            FallBall fb = new FallBall(difficulty);
            fb.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("How to play:\n\n");

            sb.Append("First choose difficulty of the game, than press Start Game button\n");
            sb.Append("Press right arrow to move the ball to the Right\n");
            sb.Append("Press left arrow to move the ball to the Left\n");
            sb.Append("Don't let the ball touch the top of the screen and make as much score as you can\n\n");

            sb.Append("Press P for Pause\n\n");

            sb.Append("To see highscores, choose difficulty and press High Scores button\n\n");

            sb.Append("Enjoy!!\n");
            MessageBox.Show(sb.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            int difficulty = -1;
            if (rbEasy.Checked)
            {
                difficulty = 1;
            }
            else if (rbMedium.Checked)
            {
                difficulty = 2;
            }
            else
            {
                difficulty = 3;
            }
            FallScores f = new FallScores(difficulty);
            f.ShowDialog();
        }
    }
}
