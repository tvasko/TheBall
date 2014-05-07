using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            FallStart fallStart = new FallStart();
            fallStart.ShowDialog(); 
        }

        private void btnFlappy_Click(object sender, EventArgs e)
        {
            FlappyStart flappyStart = new FlappyStart();
            flappyStart.ShowDialog();
        }

        private void btnCatchTheBall_Click(object sender, EventArgs e)
        {
            CatchStart  catchStart = new CatchStart();
            catchStart.ShowDialog();
        }
    }
}
