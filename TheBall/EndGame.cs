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
    public partial class EndGame : Form
    {
        public int End { get; set; }
        public String NameP { get; set; }
        public EndGame()
        {
            InitializeComponent();
            End = -1;
            NameP = "Player";
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            End = 0;
            NameP = txtName.Text;
            this.Close();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            End = 1;
            NameP = txtName.Text;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim().Count() == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, "Please enter your name!");
            }
            else{
                e.Cancel = false;
                errorProvider1.SetError(txtName, null);
            }
        }

        private void EndGame_Load(object sender, EventArgs e)
        {

        }

        private void EndGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            //End = 1;
        }
    }
}
