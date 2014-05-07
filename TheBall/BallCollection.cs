using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TheBall
{
    class BallCollection
    {
        List<Ball> balls;
        public int Score { get; set; }
        public int LostBalls { get; set; }
        public BallCollection()
        {
            balls = new List<Ball>();
            Score = 0;
            LostBalls = 0;
        }
        public void addBall(Ball ball)
        {
            balls.Add(ball);
        }
        public void moveBalls(int height,int t)
        {
            foreach (Ball b in balls)
            {
                b.Move(t);
            }
            for (int i = balls.Count() - 1; i >= 0; i--)
            {
                if (balls[i].y >= height - 65)
                {
                    balls.RemoveAt(i);
                    LostBalls++;
                }
            }
        }
        public void DrawBalls(Graphics g)
        {
            foreach (Ball b in balls)
            {
                b.Draw(g);
            }
        }
        public bool ScoreUp(Basket basket)
        {
            for (int i = balls.Count() - 1; i >= 0; i--)
            {
                if (balls[i].x >= basket.x && balls[i].x + 25 <= basket.x + 75 && balls[i].y >= 450)
                {
                    Score++;
                    balls.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
