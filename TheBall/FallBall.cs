using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace TheBall
{
    public partial class FallBall : Form
    {
        Ball ball;
        SoundPlayer pauseSound;
        SoundPlayer mainSound;
        Shelf shelf;
        Player player;
        bool exitGameBtn;
        int width = 430, heigh = 450, Score = 0, intervalScore = 0, t = 1;
        Bitmap doubleBuffer;
        Graphics graphics;
        List<Shelf> shelfList;
        List<Player> playersScore;
        bool left, right,pause=false;
        Rectangle kvadrat = new Rectangle(0, 40, 430, 450);
        Random rand = new Random();
        StreamWriter sw;
        public FallBall(int d)
        {
            InitializeComponent();
            pauseSound = new SoundPlayer(TheBall.Properties.Resources.Pause);
            mainSound = new SoundPlayer(TheBall.Properties.Resources.MainMelodyFall);
            timer1.Interval = d;
            runGame();
            if (d == 20)
            {
                String filePath = System.IO.Path.GetFullPath("FallScoreEasy.txt");
                StreamReader reader = new StreamReader(filePath);
                String s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    string[] strings={" ","0"};
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
            else if (d == 15)
            {
                String filePath = System.IO.Path.GetFullPath("FallScoreMedium.txt");
                StreamReader reader = new StreamReader(filePath);
                String s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    string[] strings = s.Split(',');
                    playersScore.Add(new Player(strings[0], int.Parse(strings[1])));
                }
                reader.Close();
                sw = new StreamWriter(filePath);
            }
            else if (d == 13)
            {
                String filePath = System.IO.Path.GetFullPath("FallScoreHard.txt");
                StreamReader reader = new StreamReader(filePath);
                String s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    string[] strings = s.Split(',');
                    playersScore.Add(new Player(strings[0], int.Parse(strings[1])));
                }
                reader.Close();
                sw = new StreamWriter(filePath);
            }
           
            
            
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.Khaki);
            ball.Draw(g);
            foreach (Shelf sh in shelfList)
            {
                sh.Draw(g);
            }
            graphics.DrawImageUnscaled(doubleBuffer, 0, 38);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!pause)
            {
                if (!ball.endGame())
                {
                    bool polica = true;
                    intervalScore++;
                    if (intervalScore == 50)
                    {
                        intervalScore = 0;
                        Score++;
                    }
                    for (int i = 0; i < shelfList.Count(); i++)
                    {
                        if (i % 2 == 0)
                            shelfList[i].Move(3, heigh, shelfList[i].width, shelfList[i].x);
                        else
                            shelfList[i].Move(3, heigh, width - shelfList[i - 1].width - 50, shelfList[i - 1].width + 50);
                        if (ball.naPolica(shelfList[i]) && polica)
                        {
                            t = i;
                            polica = false;
                            ball.Move(5, width, heigh, left, right, shelfList[i]);
                        }

                    }
                    if (polica)
                    {
                        if (t % 2 != 0)
                            ball.Move(5, width, heigh, left, right, shelfList[t - 1]);
                        else
                            ball.Move(5, width, heigh, left, right, shelfList[t + 1]);

                    }
                    label2.Text = Score.ToString();
                    panel1.Invalidate(kvadrat, true);
                }
                else
                {
                    endGame();
                }
            }
            else
            {
                timer1.Stop();
            }
        }
        public void endGame()
        {
            exitGameBtn = false;
            timer1.Stop();
            mainSound.Stop();
            EndGame form = new EndGame();
            form.ShowDialog();
            player = new Player(form.NameP, Score);
            playersScore.Add(player);
            writeFile();
            if (form.End == 0)
            {
                Score = 0;
                runGame();

            }
            else if (form.End == 1)
            {
                this.Close();
                sw.Close();
            }
        }
        private void FallBall_Load(object sender, EventArgs e)
        {

        }

        private void FallBall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.P)
            {
                pauseSound.Play();

                if (pause)
                {
                    pause = false;
                    timer1.Start();
                    mainSound.PlayLooping();
                }
                else
                {
                    pause = true;
                }
            }
        }

        private void FallBall_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }
        public void runGame()
        {
            pause = false;
            exitGameBtn = true;
            playersScore = new List<Player>();
            timer1.Start();
            mainSound.PlayLooping();
            right = false;
            left = false;
            this.DoubleBuffered = true;
            panel1.DoubleBuffered = true;
            doubleBuffer = new Bitmap(width, heigh);
            graphics = this.CreateGraphics();
            shelfList = new List<Shelf>();
            ball = new Ball(width / 2 - 13, width - 25);
            shelf = new Shelf(0, heigh - 25, 230);
            shelfList.Add(shelf);
            shelf = new Shelf(270, heigh - 25, width - 270);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 80, 100);
            shelfList.Add(shelf);
            shelf = new Shelf(140, heigh - 80, width - 140);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 135, 160);
            shelfList.Add(shelf);
            shelf = new Shelf(200, heigh - 135, width - 200);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 190, 120);
            shelfList.Add(shelf);
            shelf = new Shelf(160, heigh - 190, width - 160);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 245, 220);
            shelfList.Add(shelf);
            shelf = new Shelf(260, heigh - 245, width - 260);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 300, 160);
            shelfList.Add(shelf);
            shelf = new Shelf(200, heigh - 300, width - 200);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 355, 200);
            shelfList.Add(shelf);
            shelf = new Shelf(240, heigh - 355, width - 240);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 410, 80);
            shelfList.Add(shelf);
            shelf = new Shelf(120, heigh - 410, width - 120);
            shelfList.Add(shelf);

            shelf = new Shelf(0, heigh - 465, 80);
            shelfList.Add(shelf);
            shelf = new Shelf(120, heigh - 465, width - 120);
            shelfList.Add(shelf);
        }

        private void FallBall_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void FallBall_FormClosing(object sender, FormClosingEventArgs e)
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
