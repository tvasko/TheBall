using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace TheBall
{
    public partial class FlappyBall : Form
    {
        
        SoundPlayer ScoreUpSound;
        SoundPlayer gameOverS;
        bool exitGameBtn;
        Ball ball;
        Player player;
        List<Player> playersScore;
        List<Wall> upWalls;
        List<Wall> downWalls;
        Wall wall;
        int Force;
        int G=14;
        int Score;
        int interval = 0, timeStart;
        StreamWriter sw;
        bool jump=false;
        Random rand;
        public FlappyBall()
        {
            InitializeComponent();
            gameOverS = new SoundPlayer(TheBall.Properties.Resources.FlappyDie);
            newGame();
            String filePath = System.IO.Path.GetFullPath("FlappyScore.txt");
            StreamReader reader = new StreamReader(filePath);
            String s = "";
            while ((s = reader.ReadLine()) != null)
            {
                string[] strings = { " ", "0" };
                if (s.Contains(','))
                {
                    strings = s.Split(',');
                }
                if (strings.Count() == 2)
                {
                    playersScore.Add(new Player(strings[0], int.Parse(strings[1])));
                }
            }
            reader.Close();
            sw = new StreamWriter(filePath);

            ScoreUpSound = new SoundPlayer(TheBall.Properties.Resources.ScoreUp);
            DoubleBuffered = true;
            rand = new Random();
           
        }
        int yy = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            interval++;
            label2.Text = Score.ToString();
            lblTimeStart.Text = timeStart.ToString();
            if (interval == 50)
            {
                timeStart--;
                interval = 0;
            }
            if (timeStart == 0)
            {
                lblTimeStart.Visible = false;
                lblgameStartin.Visible = false;
                interval = -100;
                if (ball.y + 65 >= this.Height)
                {
                    gameOver();
                }
                else
                {
                    if (jump == true)
                    {
                        ball.y -= Force;
                        Force -= 1;
                    }
                    if (ball.y >= yy)
                    {
                        jump = false;
                    }
                    else
                    {
                        ball.y += 3;
                    }
                    if (ball.y + 65 > this.Height)
                    {
                        ball.y = this.Height - 65;
                    }
                    yy = ball.y + 1;
                    int newHeight = rand.Next(50, 220);
                    int newHeight2 = 450 - 125 - newHeight;
                    foreach (Wall w in upWalls)
                    {
                        if (ball.x == w.x)
                        {
                            Score++;
                            ScoreUpSound.Play();
                        }
                        w.Move(this.Height, this.Width);
                        if (ball.TouchUP(w))
                        {
                            gameOver();
                        }
                        if (w.isGone())
                        {
                            w.height = newHeight;
                        }
                    }
                    foreach (Wall w in downWalls)
                    {
                        w.Move(this.Height, this.Width);
                        if (ball.TouchDown(w))
                        {
                            gameOver();
                        }
                        if (w.isGone())
                        {
                            w.y = newHeight + 125;
                            w.height = newHeight2;
                        }
                    }
                    
                }
            }
            Invalidate();
        }
        public void gameOver()
        {
            timer1.Stop();
            exitGameBtn = false;
            gameOverS.Play();
            EndGame form = new EndGame();
            form.ShowDialog();
            player = new Player(form.NameP, Score);
            playersScore.Add(player);
            writeFile();
            if (form.End == 0)
            {
                Score = 0;
                newGame();
                sw.Flush();

            }
            else if (form.End == 1)
            {
                this.Close();
                sw.Close();
            }

        }
        private void FlappyBall_Paint(object sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
            foreach (Wall w in upWalls)
            {
                w.Draw(e.Graphics);
            }
            foreach (Wall w in downWalls)
            {
                w.Draw(e.Graphics);
            }
           
        }
        public void newGame()
        {
            exitGameBtn = true;
            timeStart = 3;
            timer1.Start();
            lblTimeStart.Visible = true;
            lblgameStartin.Visible = true;
            Score = 0;
            upWalls = new List<Wall>();
            downWalls = new List<Wall>();
            playersScore = new List<Player>();
            ball = new Ball(250, 200);
            wall = new Wall(600, 0, 200);
            upWalls.Add(wall);
            wall = new Wall(600, 325, this.Height - 65 - 200);
            downWalls.Add(wall);

            wall = new Wall(750, 0, 100);
            upWalls.Add(wall);
            wall = new Wall(750, 225, this.Height - 65 - 100);
            downWalls.Add(wall);

            wall = new Wall(900, 0, 220);
            upWalls.Add(wall);
            wall = new Wall(900, 345, this.Height - 65 - 220);
            downWalls.Add(wall);

            wall = new Wall(1050, 0, 80);
            upWalls.Add(wall);
            wall = new Wall(1050, 205, this.Height - 65 - 80);
            downWalls.Add(wall);
        }
        private void FlappyBall_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                   // jumpBall.Play();
                    jump = true;
                    Force = G;
                    
                }
            }
        }

        private void FlappyBall_KeyUp(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Space)
                {
                    jump = false;

                }
        }

        private void FlappyBall_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (exitGameBtn)
            {
                writeFile();
            }
            sw.Close();
        }
        private void writeFile()
        {
            playersScore = playersScore.OrderByDescending(x => x.Score).ToList();
            int pom = 0;
            if (playersScore.Count >= 15) { pom = 15; }
            else pom = playersScore.Count;
            for (int i = 0; i < pom; i++)
            {
                sw.WriteLine(String.Format("{0},{1}", playersScore[i].Name, playersScore[i].Score));
            }
        }

    }
}
