namespace KReversi
{
    partial class FormTestDynamicMenu
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recently01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recently02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentyl03ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.recently01ToolStripMenuItem,
            this.recently02ToolStripMenuItem,
            this.recentyl03ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // recently01ToolStripMenuItem
            // 
            this.recently01ToolStripMenuItem.Name = "recently01ToolStripMenuItem";
            this.recently01ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.recently01ToolStripMenuItem.Text = "Recently01";
            // 
            // recently02ToolStripMenuItem
            // 
            this.recently02ToolStripMenuItem.Name = "recently02ToolStripMenuItem";
            this.recently02ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.recently02ToolStripMenuItem.Text = "Recently02";
            // 
            // recentyl03ToolStripMenuItem
            // 
            this.recentyl03ToolStripMenuItem.Name = "recentyl03ToolStripMenuItem";
            this.recentyl03ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.recentyl03ToolStripMenuItem.Text = "Recentyl03";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 389);
            this.textBox1.TabIndex = 2;
            // 
            // FormTestDynamicMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTestDynamicMenu";
            this.Text = "FormTestDynamicMenu";
            this.Load += new System.EventHandler(this.FormTestDynamicMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem recently01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recently02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentyl03ToolStripMenuItem;
    }
}