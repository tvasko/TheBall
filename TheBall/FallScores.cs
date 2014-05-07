using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TheBall
{
    public partial class FallScores : Form
    {
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);
        private SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.LightGray);
        public FallScores(String st) 
        {
            InitializeComponent();
            String filePath = System.IO.Path.GetFullPath("CatchScore.txt");
            StreamReader sr = new StreamReader(filePath);
            String s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] strings = { " ", "0" };
                Player p = new Player(strings[0], int.Parse(strings[1]));
                if (s.Contains(','))
                {
                    strings = s.Split(',');
                }
                if (strings.Count() == 2)
                {
                    p = new Player(strings[0], int.Parse(strings[1]));
                }
                lstScores.Items.Add(p);
                lstScores.Items.Add("");
            }
            sr.Close();
        }
        public FallScores()
        {
            InitializeComponent();
            String filePath = System.IO.Path.GetFullPath("FlappyScore.txt");
            StreamReader sr = new StreamReader(filePath);
            String s = "";
            while ((s = sr.ReadLine()) != null)
            {
                string[] strings = { " ", "0" };
                Player p = new Player(strings[0], int.Parse(strings[1]));
                if (s.Contains(','))
                {
                    strings = s.Split(',');
                }
                if (strings.Count() == 2)
                {
                    p = new Player(strings[0], int.Parse(strings[1]));
                }
                lstScores.Items.Add(p);
                lstScores.Items.Add("");
            }
            sr.Close();
        }
        public FallScores(int t)
        {
            InitializeComponent();
            if(t==1){
                String filePath = System.IO.Path.GetFullPath("FallScoreEasy.txt");
                StreamReader sr = new StreamReader(filePath);
                String s="";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] strings = { " ", "0" };
                    Player p = new Player(strings[0], int.Parse(strings[1]));
                    if (s.Contains(','))
                    {
                        strings = s.Split(',');
                    }
                    if (strings.Count() == 2)
                    {
                        p = new Player(strings[0], int.Parse(strings[1]));
                    }
                    lstScores.Items.Add(p);
                    lstScores.Items.Add("");
                }
                sr.Close();
            }
            else if(t==2){
                String filePath = System.IO.Path.GetFullPath("FallScoreMedium.txt");
                StreamReader sr = new StreamReader(filePath);
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] strings = { " ", "0" };
                    Player p = new Player(strings[0], int.Parse(strings[1]));
                    if (s.Contains(','))
                    {
                        strings = s.Split(',');
                    }
                    if (strings.Count() == 2)
                    {
                        p = new Player(strings[0], int.Parse(strings[1]));
                    }
                    lstScores.Items.Add(p);
                    lstScores.Items.Add("");
                }
                sr.Close();
            }
            else if(t==3){
                String filePath = System.IO.Path.GetFullPath("FallScoreHard.txt");
                StreamReader sr = new StreamReader(filePath);
                String s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] strings = { " ", "0" };
                    Player p = new Player(strings[0], int.Parse(strings[1]));
                    if (s.Contains(','))
                    {
                        strings = s.Split(',');
                    }
                    if (strings.Count() == 2)
                    {
                        p = new Player(strings[0], int.Parse(strings[1]));
                    }
                    lstScores.Items.Add(p);
                    lstScores.Items.Add("");
                }
                sr.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstScores_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lstScores_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < lstScores.Items.Count)
            {
                string text = lstScores.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if ((index % 2) == 0)
                    backgroundBrush = reportsBackgroundBrush1;
                else
                    backgroundBrush = reportsBackgroundBrush2;
                g.FillRectangle(backgroundBrush, e.Bounds);
                g.DrawString(text, e.Font, reportsForegroundBrush, lstScores.GetItemRectangle(index).Location);
            }

            e.DrawFocusRectangle();
        }
    }
}
