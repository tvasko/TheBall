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
    public partial class FlappyStart : Form
    {
        public FlappyStart()
        {
            InitializeComponent();
            String filePath = System.IO.Path.GetFullPath("FlappyScore.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, String.Empty);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            FlappyBall fb = new FlappyBall();
            fb.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("How to play:\n\n");

            sb.Append("Press Start Game button and wait for 3 seconds until the game start\n");
            sb.Append("Press SPACE to jump with the ball\n");
            sb.Append("Don't let the ball fall down or touch any of the walls and make as much score as you can\n\n");

            sb.Append("To see highscores, press High Scores button\n\n");

            sb.Append("Enjoy!!\n");
            MessageBox.Show(sb.ToString());
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            FallScores fs = new FallScores();
            fs.ShowDialog();
        }
    }
}
