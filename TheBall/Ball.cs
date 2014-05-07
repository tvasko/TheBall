using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheBall
{
    class Ball
    {
        public int x {get;set;}
        public int y { get; set; }
        Bitmap topka;
        public Ball(int x, int y)
        {
            this.x = x;
            this.y = y;
            topka = TheBall.Properties.Resources.ball;
        }
        public void Move(int t)
        {
            y += t;
        }
        public bool TouchUP(Wall wall)
        {
            if (x + 25>=wall.x && y<=wall.y+wall.height  && x<wall.x+54)
            {
                return true;
            }
            return false;
        }
        public bool TouchDown(Wall wall)
        {
            if (x + 25 >= wall.x && y + 25 >= wall.y && x<wall.x+54)
            {
                return true;
            }
            return false;
        }
        public void Move(int speed, int width, int height, bool left, bool right, Shelf shelf)
        {
            if (x + 10 >= shelf.x && x <= (shelf.x + shelf.width - 10) && (shelf.y - (y + 25)) <= 5 && (shelf.y - (y + 25)) >= -5)
            {
                y -= 3;
            }
            else if (y + 25 + speed <= height)
            {
                y += speed;
            }
            if (y + 25 != height)
            {
                if (left == true && x - 15 > 0 && !leftShelf(shelf))
                {

                    for (int i = 0; i < 11; i += 1)
                        x -= 1;

                }
                if (right == true && x + 15 + 25 < width && !rightShelf(shelf))
                {
                    for (int i = 0; i < 11; i += 1)
                        x += 1;
                }

            }
        }
        public bool poklopuvanje(Shelf shelf)
        {
            if (x > shelf.x && x + 25 < shelf.x + shelf.width && y > shelf.y && y + 25 < shelf.y + 25)
                return true;
            return false;
        }
        public bool leftShelf(Shelf shelf) 
        {
            if (x > shelf.x + shelf.width-2 && x<shelf.x+shelf.width+8  && y + 26 > shelf.y && y < shelf.y + 15)
                return true;
            return false;
        }
        public bool rightShelf(Shelf shelf)
        {
            if (x + 25 < shelf.x+2 && x + 25 > shelf.x - 8 && y + 26 > shelf.y && y < shelf.y + 15)
            {
                return true;
            }
            return false;
        }
        public bool naPolica(Shelf shelf)
        {
            if (x >= shelf.x && x <= (shelf.x + shelf.width) && (shelf.y - (y + 25)) <= 4 && (shelf.y - (y + 25)) >= -4)
            {
                return true;
            }
            else
                return false;
        }
        public bool endGame()
        {
            if (y <= 0)
            {
                return true;
            }
            return false;
        }
        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(topka, x, y);
        }


    }
}
