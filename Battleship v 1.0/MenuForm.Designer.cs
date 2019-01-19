namespace Battleship_v_1._0
{
    partial class MenuForm
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
            this.CreateServerButton = new System.Windows.Forms.Button();
            this.FindServerButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateServerButton
            // 
            this.CreateServerButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CreateServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CreateServerButton.Location = new System.Drawing.Point(52, 70);
            this.CreateServerButton.Name = "CreateServerButton";
            this.CreateServerButton.Size = new System.Drawing.Size(155, 76);
            this.CreateServerButton.TabIndex = 0;
            this.CreateServerButton.Text = "Stwórz serwer";
            this.CreateServerButton.UseVisualStyleBackColor = false;
            this.CreateServerButton.Click += new System.EventHandler(this.CreateServerButton_Click);
            // 
            // FindServerButton
            // 
            this.FindServerButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FindServerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FindServerButton.Location = new System.Drawing.Point(52, 166);
            this.FindServerButton.Name = "FindServerButton";
            this.FindServerButton.Size = new System.Drawing.Size(155, 76);
            this.FindServerButton.TabIndex = 1;
            this.FindServerButton.Text = "Znajdź serwer";
            this.FindServerButton.UseVisualStyleBackColor = false;
            this.FindServerButton.Click += new System.EventHandler(this.FindServerButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitButton.Location = new System.Drawing.Point(52, 263);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(155, 76);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(272, 401);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.FindServerButton);
            this.Controls.Add(this.CreateServerButton);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateServerButton;
        private System.Windows.Forms.Button FindServerButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

