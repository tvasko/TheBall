using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;


namespace TheBall
{
    public partial class CatchBall : Form
    {
        SoundPlayer mainSound;
        SoundPlayer gameOverS;
        Basket basket;
        bool exitGameBtn;
        Ball ball;
        int newBall,newBallInterval;
        Player player;
        List<Player> playersScore;
        int x;
        int speed = 1;
        bool prvPat = true;
        StreamWriter sw;
        BallCollection ballCollection;
        Random random;
        public CatchBall()
        {
            InitializeComponent();
            mainSound = new SoundPlayer(TheBall.Properties.Resources.CatchBallSound);
            gameOverS = new SoundPlayer(TheBall.Properties.Resources.gameOverCatch);
            DoubleBuffered = true;
            newGame();
            String filePath = System.IO.Path.GetFullPath("CatchScore.txt");
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
        }

        public void newGame()
        {
            random = new Random();
            exitGameBtn = true;
            playersScore = new List<Player>();
            newBall = 0;
            newBallInterval = 80;
            basket = new Basket();
            ballCollection = new BallCollection();
            x = 0;
            timer1.Start();
            mainSound.PlayLooping() ;
        }
        private void CatchBall_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.LightGreen);
            ballCollection.DrawBalls(e.Graphics);
            basket.Draw(e.Graphics) ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ballCollection.LostBalls < 5)
            {
                if (ballCollection.Score % 15 == 0 && ballCollection.Score > 0 && prvPat)
                {
                    speed++;
                    prvPat = false;
                    if(newBallInterval>=35)
                    newBallInterval-=5;

                }
                newBall++;
                if (newBall >= newBallInterval)
                {
                    newBall = 0;
                    ball = new Ball(random.Next(10, this.Width - 55), -25);
                    ballCollection.addBall(ball);
                }
                ballCollection.moveBalls(this.Height,speed);
                basket.Move(x);
                prvPat=ballCollection.ScoreUp(basket);
                lblScore.Text = ballCollection.Score.ToString();
                lblLostBalls.Text = ballCollection.LostBalls.ToString();
            }
            else
            {
                GameOver();
            }
            Invalidate();
        }
        public void GameOver()
        {
            timer1.Stop();
            exitGameBtn = false;
            mainSound.Stop();
            gameOverS.Play();
            EndGame form = new EndGame();
            form.ShowDialog();
            player = new Player(form.NameP, ballCollection.Score);
            playersScore.Add(player);
            writeFile();
            if (form.End == 0)
            {
                newGame();
                sw.Flush();
            }
            else if (form.End == 1)
            {
                this.Close();
                sw.Close();
            }
        }
        private void CatchBall_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X-37;
        }

        private void CatchBall_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer1.Stop();
            mainSound.Stop();
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
