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
    public partial class CatchStart : Form
    {
        public CatchStart()
        {
            InitializeComponent();
            String filePath = System.IO.Path.GetFullPath("CatchScore.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, String.Empty);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            CatchBall catchBall = new CatchBall();
            catchBall.ShowDialog();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            FallScores f = new FallScores("");
            f.ShowDialog();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("How to play:\n\n");

            sb.Append("Press Start Game button and the game will start\n");
            sb.Append("Move the basket with your mouse and catch as much balls as you can\n");
            sb.Append("On every 15 catched ball, the game speed up and balls are falling more frequently\n\n");
            sb.Append("If you lose 5 balls, the game over\n\n");

            sb.Append("To see highscores, press High Scores button\n\n");

            sb.Append("Enjoy!!\n");
            MessageBox.Show(sb.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
