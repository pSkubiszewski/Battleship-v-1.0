namespace Battleship_v_1._0
{
    partial class GameForm
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
            this.MyPanel = new System.Windows.Forms.Panel();
            this.OpPanel = new System.Windows.Forms.Panel();
            this.MyLabel = new System.Windows.Forms.Label();
            this.WhoNowLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.OpLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MyPanel
            // 
            this.MyPanel.Location = new System.Drawing.Point(22, 36);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(400, 400);
            this.MyPanel.TabIndex = 0;
            // 
            // OpPanel
            // 
            this.OpPanel.Location = new System.Drawing.Point(542, 36);
            this.OpPanel.Name = "OpPanel";
            this.OpPanel.Size = new System.Drawing.Size(400, 400);
            this.OpPanel.TabIndex = 1;
            // 
            // MyLabel
            // 
            this.MyLabel.AutoSize = true;
            this.MyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MyLabel.Location = new System.Drawing.Point(16, 2);
            this.MyLabel.Name = "MyLabel";
            this.MyLabel.Size = new System.Drawing.Size(144, 31);
            this.MyLabel.TabIndex = 2;
            this.MyLabel.Text = "Moje statki";
            // 
            // WhoNowLabel
            // 
            this.WhoNowLabel.AutoSize = true;
            this.WhoNowLabel.Location = new System.Drawing.Point(408, 0);
            this.WhoNowLabel.Name = "WhoNowLabel";
            this.WhoNowLabel.Size = new System.Drawing.Size(0, 13);
            this.WhoNowLabel.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Graj!!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // OpLabel
            // 
            this.OpLabel.AutoSize = true;
            this.OpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpLabel.Location = new System.Drawing.Point(894, 8);
            this.OpLabel.Name = "OpLabel";
            this.OpLabel.Size = new System.Drawing.Size(115, 25);
            this.OpLabel.TabIndex = 5;
            this.OpLabel.Text = "Przeciwnik";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoLabel.Location = new System.Drawing.Point(450, 8);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(47, 25);
            this.InfoLabel.TabIndex = 6;
            this.InfoLabel.Text = "Info";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 441);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.OpLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WhoNowLabel);
            this.Controls.Add(this.MyLabel);
            this.Controls.Add(this.OpPanel);
            this.Controls.Add(this.MyPanel);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.Panel OpPanel;
        private System.Windows.Forms.Label MyLabel;
        private System.Windows.Forms.Label WhoNowLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label OpLabel;
        private System.Windows.Forms.Label InfoLabel;
    }
}