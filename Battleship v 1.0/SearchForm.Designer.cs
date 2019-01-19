namespace Battleship_v_1._0
{
    partial class SearchForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.ServerList = new System.Windows.Forms.ListView();
            this.ServerNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerIpColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(37, 59);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(179, 45);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Odśwież";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click_1);
            // 
            // ServerList
            // 
            this.ServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerNameColumn,
            this.ServerIpColumn,
            this.PlayerColumn});
            this.ServerList.Location = new System.Drawing.Point(37, 128);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(496, 218);
            this.ServerList.TabIndex = 1;
            this.ServerList.UseCompatibleStateImageBehavior = false;
            this.ServerList.View = System.Windows.Forms.View.Details;
            this.ServerList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ServerList_ItemCheck);
            this.ServerList.SelectedIndexChanged += new System.EventHandler(this.ServerList_SelectedIndexChanged);
            // 
            // ServerNameColumn
            // 
            this.ServerNameColumn.Text = "Nazwa serwera";
            this.ServerNameColumn.Width = 144;
            // 
            // ServerIpColumn
            // 
            this.ServerIpColumn.Text = "Ip";
            this.ServerIpColumn.Width = 88;
            // 
            // PlayerColumn
            // 
            this.PlayerColumn.Text = "Gracz";
            this.PlayerColumn.Width = 251;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(367, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Połącz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 392);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ServerList);
            this.Controls.Add(this.SearchButton);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Znajdz serwer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListView ServerList;
        private System.Windows.Forms.ColumnHeader ServerNameColumn;
        private System.Windows.Forms.ColumnHeader ServerIpColumn;
        private System.Windows.Forms.ColumnHeader PlayerColumn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}