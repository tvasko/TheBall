using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBall
{
    class Player
    {
        public String Name { get; set; }
        public int Score { get; set; }

        public Player(String name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int t = 0;
            for (int i = 0; i < Name.Count(); i++)
            {
                sb.Append(Name[i]);
                t++;
            }
            t= t / 13 + Convert.ToInt32(t%13>0);
           // t = (int)Math.Ceiling(((double)t) / 15);
            while (t < 7) { sb.Append("\t"); t++; }
            sb.Append(Score);
            return sb.ToString();
        }
    }
}
