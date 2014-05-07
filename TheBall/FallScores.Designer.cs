namespace TheBall
{
    partial class FallScores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FallScores));
            this.lstScores = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstScores
            // 
            this.lstScores.ColumnWidth = 150;
            this.lstScores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstScores.FormattingEnabled = true;
            this.lstScores.Location = new System.Drawing.Point(12, 12);
            this.lstScores.Name = "lstScores";
            this.lstScores.ScrollAlwaysVisible = true;
            this.lstScores.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstScores.Size = new System.Drawing.Size(332, 225);
            this.lstScores.TabIndex = 0;
            this.lstScores.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstScores_DrawItem);
            this.lstScores.SelectedIndexChanged += new System.EventHandler(this.lstScores_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(218, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FallScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(358, 288);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FallScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Scores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstScores;
        private System.Windows.Forms.Button btnClose;
    }
}