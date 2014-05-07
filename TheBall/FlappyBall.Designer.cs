namespace TheBall
{
    partial class FlappyBall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlappyBall));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimeStart = new System.Windows.Forms.Label();
            this.lblgameStartin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(241, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lblTimeStart
            // 
            this.lblTimeStart.AutoSize = true;
            this.lblTimeStart.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeStart.ForeColor = System.Drawing.Color.Maroon;
            this.lblTimeStart.Location = new System.Drawing.Point(358, 71);
            this.lblTimeStart.Name = "lblTimeStart";
            this.lblTimeStart.Size = new System.Drawing.Size(132, 46);
            this.lblTimeStart.TabIndex = 2;
            this.lblTimeStart.Text = "label1";
            // 
            // lblgameStartin
            // 
            this.lblgameStartin.AutoSize = true;
            this.lblgameStartin.BackColor = System.Drawing.Color.Transparent;
            this.lblgameStartin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblgameStartin.Location = new System.Drawing.Point(74, 71);
            this.lblgameStartin.Name = "lblgameStartin";
            this.lblgameStartin.Size = new System.Drawing.Size(278, 46);
            this.lblgameStartin.TabIndex = 3;
            this.lblgameStartin.Text = "Game Start in";
            // 
            // FlappyBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheBall.Properties.Resources.backFlappy1;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.lblgameStartin);
            this.Controls.Add(this.lblTimeStart);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FlappyBall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLAPPY BALL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlappyBall_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlappyBall_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlappyBall_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FlappyBall_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTimeStart;
        private System.Windows.Forms.Label lblgameStartin;
    }
}