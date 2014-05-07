namespace TheBall
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCatchTheBall = new System.Windows.Forms.Button();
            this.btnFall = new System.Windows.Forms.Button();
            this.btnFlappy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(125, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Game";
            // 
            // btnCatchTheBall
            // 
            this.btnCatchTheBall.BackgroundImage = global::TheBall.Properties.Resources.CatchBtn;
            this.btnCatchTheBall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatchTheBall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatchTheBall.ForeColor = System.Drawing.Color.Yellow;
            this.btnCatchTheBall.Location = new System.Drawing.Point(366, 97);
            this.btnCatchTheBall.Name = "btnCatchTheBall";
            this.btnCatchTheBall.Size = new System.Drawing.Size(135, 141);
            this.btnCatchTheBall.TabIndex = 3;
            this.btnCatchTheBall.UseVisualStyleBackColor = true;
            this.btnCatchTheBall.Click += new System.EventHandler(this.btnCatchTheBall_Click);
            // 
            // btnFall
            // 
            this.btnFall.BackgroundImage = global::TheBall.Properties.Resources.FallBallBtn;
            this.btnFall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFall.ForeColor = System.Drawing.Color.Yellow;
            this.btnFall.Location = new System.Drawing.Point(189, 97);
            this.btnFall.Name = "btnFall";
            this.btnFall.Size = new System.Drawing.Size(135, 141);
            this.btnFall.TabIndex = 1;
            this.btnFall.UseVisualStyleBackColor = true;
            this.btnFall.Click += new System.EventHandler(this.btnFall_Click);
            // 
            // btnFlappy
            // 
            this.btnFlappy.BackgroundImage = global::TheBall.Properties.Resources.FlappyBtn;
            this.btnFlappy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlappy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFlappy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFlappy.Location = new System.Drawing.Point(12, 97);
            this.btnFlappy.Name = "btnFlappy";
            this.btnFlappy.Size = new System.Drawing.Size(135, 141);
            this.btnFlappy.TabIndex = 0;
            this.btnFlappy.UseVisualStyleBackColor = true;
            this.btnFlappy.Click += new System.EventHandler(this.btnFlappy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(513, 261);
            this.Controls.Add(this.btnCatchTheBall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFall);
            this.Controls.Add(this.btnFlappy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " THE BALL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFlappy;
        private System.Windows.Forms.Button btnFall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCatchTheBall;
    }
}

