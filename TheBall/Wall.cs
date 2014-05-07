using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TheBall
{
    class Wall
    {
        public int x { get; set; }
        public int y { get; set; }
        public int height { get; set; }
        Random rand;
        Bitmap wall;
        public Wall(int x, int y,int height)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            wall = TheBall.Properties.Resources.wall;
        }
        public void Move(int height, int width)
        {
            if (x +54 > 0)
            {
                x -= 2;
            }
            else
            {
                x = 546;
            }
        }
        public void Draw(Graphics g){
            g.DrawImage(wall, x, y,54,height);
        }
        public bool isGone()
        {
            if (x + 54 <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
