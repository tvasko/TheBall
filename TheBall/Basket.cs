using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TheBall
{
    class Basket
    {
        public int x { get; set; }
        Bitmap basket;
        public Basket()
        {
            x = 0;
            basket = new Bitmap(TheBall.Properties.Resources.basketball_net);
        }
        public void Move(int x)
        {
            if(x+75<=450)
            this.x = x;
        }
        public void Draw(Graphics g)
        {
            g.DrawImageUnscaled(basket, x, 440, 75, 53);
        }
    }
}
