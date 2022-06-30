namespace Csharp_Login_And_Register
{
    partial class MainFormAdmin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.obsługaUżytkownikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodawanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuwanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetHasłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obsługaWydarzeńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodawanieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuwanieToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modyfikacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obsługaZapisówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obsługaUżytkownikówToolStripMenuItem,
            this.obsługaWydarzeńToolStripMenuItem,
            this.obsługaZapisówToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // obsługaUżytkownikówToolStripMenuItem
            // 
            this.obsługaUżytkownikówToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodawanieToolStripMenuItem,
            this.usuwanieToolStripMenuItem,
            this.resetHasłaToolStripMenuItem});
            this.obsługaUżytkownikówToolStripMenuItem.Name = "obsługaUżytkownikówToolStripMenuItem";
            this.obsługaUżytkownikówToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.obsługaUżytkownikówToolStripMenuItem.Text = "Obsługa użytkowników";
            // 
            // dodawanieToolStripMenuItem
            // 
            this.dodawanieToolStripMenuItem.Name = "dodawanieToolStripMenuItem";
            this.dodawanieToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.dodawanieToolStripMenuItem.Text = "Dodawanie";
            this.dodawanieToolStripMenuItem.Click += new System.EventHandler(this.dodawanieToolStripMenuItem_Click);
            // 
            // usuwanieToolStripMenuItem
            // 
            this.usuwanieToolStripMenuItem.Name = "usuwanieToolStripMenuItem";
            this.usuwanieToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.usuwanieToolStripMenuItem.Text = "Usuwanie";
            this.usuwanieToolStripMenuItem.Click += new System.EventHandler(this.usuwanieToolStripMenuItem_Click);
            // 
            // resetHasłaToolStripMenuItem
            // 
            this.resetHasłaToolStripMenuItem.Name = "resetHasłaToolStripMenuItem";
            this.resetHasłaToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.resetHasłaToolStripMenuItem.Text = "Reset hasła";
            this.resetHasłaToolStripMenuItem.Click += new System.EventHandler(this.resetHasłaToolStripMenuItem_Click);
            // 
            // obsługaWydarzeńToolStripMenuItem
            // 
            this.obsługaWydarzeńToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodawanieToolStripMenuItem1,
            this.usuwanieToolStripMenuItem1,
            this.modyfikacjaToolStripMenuItem});
            this.obsługaWydarzeńToolStripMenuItem.Name = "obsługaWydarzeńToolStripMenuItem";
            this.obsługaWydarzeńToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.obsługaWydarzeńToolStripMenuItem.Text = "Obsługa wydarzeń";
            // 
            // dodawanieToolStripMenuItem1
            // 
            this.dodawanieToolStripMenuItem1.Name = "dodawanieToolStripMenuItem1";
            this.dodawanieToolStripMenuItem1.Size = new System.Drawing.Size(173, 26);
            this.dodawanieToolStripMenuItem1.Text = "Dodawanie";
            this.dodawanieToolStripMenuItem1.Click += new System.EventHandler(this.dodawanieToolStripMenuItem1_Click);
            // 
            // usuwanieToolStripMenuItem1
            // 
            this.usuwanieToolStripMenuItem1.Name = "usuwanieToolStripMenuItem1";
            this.usuwanieToolStripMenuItem1.Size = new System.Drawing.Size(173, 26);
            this.usuwanieToolStripMenuItem1.Text = "Usuwanie";
            this.usuwanieToolStripMenuItem1.Click += new System.EventHandler(this.usuwanieToolStripMenuItem1_Click);
            // 
            // modyfikacjaToolStripMenuItem
            // 
            this.modyfikacjaToolStripMenuItem.Name = "modyfikacjaToolStripMenuItem";
            this.modyfikacjaToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.modyfikacjaToolStripMenuItem.Text = "Modyfikacja";
            this.modyfikacjaToolStripMenuItem.Click += new System.EventHandler(this.modyfikacjaToolStripMenuItem_Click);
            // 
            // obsługaZapisówToolStripMenuItem
            // 
            this.obsługaZapisówToolStripMenuItem.Name = "obsługaZapisówToolStripMenuItem";
            this.obsługaZapisówToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.obsługaZapisówToolStripMenuItem.Text = "Obsługa zapisów";
            this.obsługaZapisówToolStripMenuItem.Click += new System.EventHandler(this.obsługaZapisówToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 400);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFormAdmin";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem obsługaUżytkownikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodawanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuwanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetHasłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obsługaWydarzeńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodawanieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuwanieToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modyfikacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obsługaZapisówToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}