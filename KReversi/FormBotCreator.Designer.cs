namespace KReversi
{
    partial class FormBotCreator
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtBotName = new System.Windows.Forms.TextBox();
            this.lblBotName = new System.Windows.Forms.Label();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecentlyLine = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.numTimeLimitPerMove = new System.Windows.Forms.NumericUpDown();
            this.numStableDiskScore = new System.Windows.Forms.NumericUpDown();
            this.lblStableDiskscore = new System.Windows.Forms.Label();
            this.numericForcePassScore = new System.Windows.Forms.NumericUpDown();
            this.lblFOrcePassScore = new System.Windows.Forms.Label();
            this.pictureboxBotPhoto = new System.Windows.Forms.PictureBox();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkPositionScore = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRecently1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecentlyEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLimitPerMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableDiskScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericForcePassScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(330, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(629, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Openning";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(629, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Middle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(629, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "End Game";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtBotName
            // 
            this.txtBotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBotName.Location = new System.Drawing.Point(40, 180);
            this.txtBotName.Name = "txtBotName";
            this.txtBotName.Size = new System.Drawing.Size(273, 26);
            this.txtBotName.TabIndex = 2;
            // 
            // lblBotName
            // 
            this.lblBotName.AutoSize = true;
            this.lblBotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBotName.Location = new System.Drawing.Point(36, 158);
            this.lblBotName.Name = "lblBotName";
            this.lblBotName.Size = new System.Drawing.Size(84, 20);
            this.lblBotName.TabIndex = 3;
            this.lblBotName.Text = "Bot Name:";
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoosePhoto.Location = new System.Drawing.Point(136, 92);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(123, 40);
            this.btnChoosePhoto.TabIndex = 4;
            this.btnChoosePhoto.Text = "Choose Photo";
            this.btnChoosePhoto.UseVisualStyleBackColor = true;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.openToolStripMenuItem,
            this.SavetoolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItemRecentlyLine,
            this.toolStripMenuItemRecently1,
            this.toolStripMenuItemRecently2,
            this.toolStripMenuItemRecently3,
            this.toolStripMenuItemRecently4,
            this.toolStripMenuItemRecently5,
            this.toolStripMenuItemRecently6,
            this.toolStripMenuItemRecentlyEmpty,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.newToolStripMenuItem.Text = "Menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem1.Text = "New";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.NewStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // SavetoolStripMenuItem
            // 
            this.SavetoolStripMenuItem.Name = "SavetoolStripMenuItem";
            this.SavetoolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.SavetoolStripMenuItem.Text = "Save";
            this.SavetoolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuSave_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem3.Text = "Save As...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuSaveAs_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemRecentlyLine
            // 
            this.toolStripMenuItemRecentlyLine.Name = "toolStripMenuItemRecentlyLine";
            this.toolStripMenuItemRecentlyLine.Size = new System.Drawing.Size(200, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.exitToolStripMenuItem.Text = "Close Bot Creator";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblTimeLimit
            // 
            this.lblTimeLimit.AutoSize = true;
            this.lblTimeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLimit.Location = new System.Drawing.Point(36, 227);
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(221, 20);
            this.lblTimeLimit.TabIndex = 6;
            this.lblTimeLimit.Text = "Time limit per move (seconds):";
            // 
            // numTimeLimitPerMove
            // 
            this.numTimeLimitPerMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeLimitPerMove.Location = new System.Drawing.Point(40, 254);
            this.numTimeLimitPerMove.Margin = new System.Windows.Forms.Padding(2);
            this.numTimeLimitPerMove.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTimeLimitPerMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeLimitPerMove.Name = "numTimeLimitPerMove";
            this.numTimeLimitPerMove.Size = new System.Drawing.Size(271, 26);
            this.numTimeLimitPerMove.TabIndex = 8;
            this.numTimeLimitPerMove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeLimitPerMove.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStableDiskScore
            // 
            this.numStableDiskScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numStableDiskScore.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStableDiskScore.Location = new System.Drawing.Point(40, 319);
            this.numStableDiskScore.Margin = new System.Windows.Forms.Padding(2);
            this.numStableDiskScore.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numStableDiskScore.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
            this.numStableDiskScore.Name = "numStableDiskScore";
            this.numStableDiskScore.Size = new System.Drawing.Size(271, 26);
            this.numStableDiskScore.TabIndex = 12;
            this.numStableDiskScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStableDiskScore.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblStableDiskscore
            // 
            this.lblStableDiskscore.AutoSize = true;
            this.lblStableDiskscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStableDiskscore.Location = new System.Drawing.Point(37, 291);
            this.lblStableDiskscore.Name = "lblStableDiskscore";
            this.lblStableDiskscore.Size = new System.Drawing.Size(130, 20);
            this.lblStableDiskscore.TabIndex = 11;
            this.lblStableDiskscore.Text = "Stable disk score";
            // 
            // numericForcePassScore
            // 
            this.numericForcePassScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericForcePassScore.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericForcePassScore.Location = new System.Drawing.Point(40, 382);
            this.numericForcePassScore.Margin = new System.Windows.Forms.Padding(2);
            this.numericForcePassScore.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericForcePassScore.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.numericForcePassScore.Name = "numericForcePassScore";
            this.numericForcePassScore.Size = new System.Drawing.Size(271, 26);
            this.numericForcePassScore.TabIndex = 14;
            this.numericForcePassScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericForcePassScore.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblFOrcePassScore
            // 
            this.lblFOrcePassScore.AutoSize = true;
            this.lblFOrcePassScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFOrcePassScore.Location = new System.Drawing.Point(37, 354);
            this.lblFOrcePassScore.Name = "lblFOrcePassScore";
            this.lblFOrcePassScore.Size = new System.Drawing.Size(131, 20);
            this.lblFOrcePassScore.TabIndex = 13;
            this.lblFOrcePassScore.Text = "Force pass score";
            // 
            // pictureboxBotPhoto
            // 
            this.pictureboxBotPhoto.BackColor = System.Drawing.Color.White;
            this.pictureboxBotPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureboxBotPhoto.Location = new System.Drawing.Point(40, 42);
            this.pictureboxBotPhoto.Name = "pictureboxBotPhoto";
            this.pictureboxBotPhoto.Size = new System.Drawing.Size(90, 90);
            this.pictureboxBotPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxBotPhoto.TabIndex = 1;
            this.pictureboxBotPhoto.TabStop = false;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // chkPositionScore
            // 
            this.chkPositionScore.AutoSize = true;
            this.chkPositionScore.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkPositionScore.Location = new System.Drawing.Point(40, 428);
            this.chkPositionScore.Margin = new System.Windows.Forms.Padding(2);
            this.chkPositionScore.Name = "chkPositionScore";
            this.chkPositionScore.Size = new System.Drawing.Size(186, 29);
            this.chkPositionScore.TabIndex = 15;
            this.chkPositionScore.Text = "Use Position Score";
            this.chkPositionScore.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkPositionScore.UseVisualStyleBackColor = true;
            this.chkPositionScore.CheckedChanged += new System.EventHandler(this.chkPositionScore_CheckedChanged);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(35, 584);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(498, 20);
            this.lblWarning.TabIndex = 16;
            this.lblWarning.Text = "*The change in this form will be affected after you create a new game.";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripMenuItemRecently1
            // 
            this.toolStripMenuItemRecently1.Name = "toolStripMenuItemRecently1";
            this.toolStripMenuItemRecently1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently1.Text = "1.";
            // 
            // toolStripMenuItemRecently2
            // 
            this.toolStripMenuItemRecently2.Name = "toolStripMenuItemRecently2";
            this.toolStripMenuItemRecently2.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently2.Text = "2.";
            // 
            // toolStripMenuItemRecently3
            // 
            this.toolStripMenuItemRecently3.Name = "toolStripMenuItemRecently3";
            this.toolStripMenuItemRecently3.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently3.Text = "3.";
            // 
            // toolStripMenuItemRecently4
            // 
            this.toolStripMenuItemRecently4.Name = "toolStripMenuItemRecently4";
            this.toolStripMenuItemRecently4.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently4.Text = "4.";
            // 
            // toolStripMenuItemRecently5
            // 
            this.toolStripMenuItemRecently5.Name = "toolStripMenuItemRecently5";
            this.toolStripMenuItemRecently5.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently5.Text = "5.";
            // 
            // toolStripMenuItemRecently6
            // 
            this.toolStripMenuItemRecently6.Name = "toolStripMenuItemRecently6";
            this.toolStripMenuItemRecently6.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecently6.Text = "6.";
            // 
            // toolStripMenuItemRecentlyEmpty
            // 
            this.toolStripMenuItemRecentlyEmpty.Name = "toolStripMenuItemRecentlyEmpty";
            this.toolStripMenuItemRecentlyEmpty.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItemRecentlyEmpty.Text = "Empty Bot Recently Files";
            // 
            // FormBotCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 632);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.chkPositionScore);
            this.Controls.Add(this.numericForcePassScore);
            this.Controls.Add(this.lblFOrcePassScore);
            this.Controls.Add(this.numStableDiskScore);
            this.Controls.Add(this.lblStableDiskscore);
            this.Controls.Add(this.numTimeLimitPerMove);
            this.Controls.Add(this.lblTimeLimit);
            this.Controls.Add(this.btnChoosePhoto);
            this.Controls.Add(this.lblBotName);
            this.Controls.Add(this.txtBotName);
            this.Controls.Add(this.pictureboxBotPhoto);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormBotCreator";
            this.Text = "Bot Creator";
            this.Load += new System.EventHandler(this.FormBotCreator_Load);
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLimitPerMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableDiskScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericForcePassScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureboxBotPhoto;
        private System.Windows.Forms.TextBox txtBotName;
        private System.Windows.Forms.Label lblBotName;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemRecentlyLine;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SavetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label lblTimeLimit;
        private System.Windows.Forms.NumericUpDown numTimeLimitPerMove;
        private System.Windows.Forms.NumericUpDown numStableDiskScore;
        private System.Windows.Forms.Label lblStableDiskscore;
        private System.Windows.Forms.NumericUpDown numericForcePassScore;
        private System.Windows.Forms.Label lblFOrcePassScore;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkPositionScore;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecentlyEmpty;
    }
}