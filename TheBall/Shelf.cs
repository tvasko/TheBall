using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheBall
{
    class Shelf
    {
        public int x {get;set;}
        public int y {get;set;} 
        public int width {get;set;}
        Random rand;
        Bitmap shelf;
        public Shelf(int x,int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            shelf= TheBall.Properties.Resources.shelf;
            
        }
        public void Move(int speed, int height, int width, int x)
        {
            
            if (y - speed < -15)
            {
                rand = new Random();
                this.y = height + 20;
                this.width = rand.Next(50, 380);
                this.x = x;
            }
            else
            {
                y -= speed;
                this.width = width;
                this.x = x;
            }
        }
        
        public void Draw(Graphics g)
        {
            g.DrawImage(shelf, x, y,width,15);
        }
    }
}
