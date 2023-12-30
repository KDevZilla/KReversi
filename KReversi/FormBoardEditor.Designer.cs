namespace KReversi
{
    partial class FormBoardEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoardEditor));
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnBlank = new System.Windows.Forms.Button();
            this.grpChooseCellType = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRecently1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecently6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecentlyEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRecentlyLine = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearBoard = new System.Windows.Forms.Button();
            this.lblSideToMove = new System.Windows.Forms.Label();
            this.comboSideToMove = new System.Windows.Forms.ComboBox();
            this.lblNumberofWhiteDisk = new System.Windows.Forms.Label();
            this.lblNumberofBlackDisk = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpNumberDisk = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.grpChooseCellType.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpNumberDisk.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBlack
            // 
            this.btnBlack.Location = new System.Drawing.Point(10, 32);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(60, 60);
            this.btnBlack.TabIndex = 4;
            this.btnBlack.UseVisualStyleBackColor = true;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.Location = new System.Drawing.Point(76, 32);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(60, 60);
            this.btnWhite.TabIndex = 5;
            this.btnWhite.UseVisualStyleBackColor = true;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnBlank
            // 
            this.btnBlank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBlank.Location = new System.Drawing.Point(142, 32);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(60, 60);
            this.btnBlank.TabIndex = 5;
            this.btnBlank.UseVisualStyleBackColor = false;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // grpChooseCellType
            // 
            this.grpChooseCellType.Controls.Add(this.btnBlank);
            this.grpChooseCellType.Controls.Add(this.btnWhite);
            this.grpChooseCellType.Controls.Add(this.btnBlack);
            this.grpChooseCellType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChooseCellType.Location = new System.Drawing.Point(590, 40);
            this.grpChooseCellType.Name = "grpChooseCellType";
            this.grpChooseCellType.Size = new System.Drawing.Size(211, 106);
            this.grpChooseCellType.TabIndex = 4;
            this.grpChooseCellType.TabStop = false;
            this.grpChooseCellType.Text = "Choose Cell type";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemRecently1,
            this.toolStripMenuItemRecently2,
            this.toolStripMenuItemRecently3,
            this.toolStripMenuItemRecently4,
            this.toolStripMenuItemRecently5,
            this.toolStripMenuItemRecently6,
            this.toolStripMenuItemRecentlyEmpty,
            this.toolStripMenuItemRecentlyLine,
            this.exitToolStripMenuItem,
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // toolStripMenuItemRecently1
            // 
            this.toolStripMenuItemRecently1.Name = "toolStripMenuItemRecently1";
            this.toolStripMenuItemRecently1.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently1.Text = "1.";
            // 
            // toolStripMenuItemRecently2
            // 
            this.toolStripMenuItemRecently2.Name = "toolStripMenuItemRecently2";
            this.toolStripMenuItemRecently2.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently2.Text = "2.";
            // 
            // toolStripMenuItemRecently3
            // 
            this.toolStripMenuItemRecently3.Name = "toolStripMenuItemRecently3";
            this.toolStripMenuItemRecently3.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently3.Text = "3.";
            // 
            // toolStripMenuItemRecently4
            // 
            this.toolStripMenuItemRecently4.Name = "toolStripMenuItemRecently4";
            this.toolStripMenuItemRecently4.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently4.Text = "4.";
            // 
            // toolStripMenuItemRecently5
            // 
            this.toolStripMenuItemRecently5.Name = "toolStripMenuItemRecently5";
            this.toolStripMenuItemRecently5.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently5.Text = "5.";
            // 
            // toolStripMenuItemRecently6
            // 
            this.toolStripMenuItemRecently6.Name = "toolStripMenuItemRecently6";
            this.toolStripMenuItemRecently6.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecently6.Text = "6.";
            // 
            // toolStripMenuItemRecentlyEmpty
            // 
            this.toolStripMenuItemRecentlyEmpty.Name = "toolStripMenuItemRecentlyEmpty";
            this.toolStripMenuItemRecentlyEmpty.Size = new System.Drawing.Size(304, 22);
            this.toolStripMenuItemRecentlyEmpty.Text = "Empty Board Recently Files";
            // 
            // toolStripMenuItemRecentlyLine
            // 
            this.toolStripMenuItemRecentlyLine.Name = "toolStripMenuItemRecentlyLine";
            this.toolStripMenuItemRecentlyLine.Size = new System.Drawing.Size(301, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.exitToolStripMenuItem.Text = "Close Board Editor";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // closeBoardEditorAndPlayFromThisBoardToolStripMenuItem
            // 
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem.Name = "closeBoardEditorAndPlayFromThisBoardToolStripMenuItem";
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem.Text = "Close Board Editor and Play from this board";
            this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem.Click += new System.EventHandler(this.closeBoardEditorAndPlayFromThisBoardToolStripMenuItem_Click);
            // 
            // btnClearBoard
            // 
            this.btnClearBoard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBoard.Location = new System.Drawing.Point(600, 152);
            this.btnClearBoard.Name = "btnClearBoard";
            this.btnClearBoard.Size = new System.Drawing.Size(110, 50);
            this.btnClearBoard.TabIndex = 6;
            this.btnClearBoard.Text = "Clear Board";
            this.btnClearBoard.UseVisualStyleBackColor = true;
            this.btnClearBoard.Click += new System.EventHandler(this.btnClearBoard_Click);
            // 
            // lblSideToMove
            // 
            this.lblSideToMove.AutoSize = true;
            this.lblSideToMove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideToMove.Location = new System.Drawing.Point(596, 272);
            this.lblSideToMove.Name = "lblSideToMove";
            this.lblSideToMove.Size = new System.Drawing.Size(104, 21);
            this.lblSideToMove.TabIndex = 7;
            this.lblSideToMove.Text = "Side to move:";
            // 
            // comboSideToMove
            // 
            this.comboSideToMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSideToMove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSideToMove.FormattingEnabled = true;
            this.comboSideToMove.Items.AddRange(new object[] {
            "Black",
            "White"});
            this.comboSideToMove.Location = new System.Drawing.Point(599, 305);
            this.comboSideToMove.Name = "comboSideToMove";
            this.comboSideToMove.Size = new System.Drawing.Size(182, 29);
            this.comboSideToMove.TabIndex = 8;
            this.comboSideToMove.SelectedIndexChanged += new System.EventHandler(this.comboSideToMove_SelectedIndexChanged);
            // 
            // lblNumberofWhiteDisk
            // 
            this.lblNumberofWhiteDisk.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberofWhiteDisk.Location = new System.Drawing.Point(87, 100);
            this.lblNumberofWhiteDisk.Name = "lblNumberofWhiteDisk";
            this.lblNumberofWhiteDisk.Size = new System.Drawing.Size(65, 60);
            this.lblNumberofWhiteDisk.TabIndex = 13;
            this.lblNumberofWhiteDisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumberofBlackDisk
            // 
            this.lblNumberofBlackDisk.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberofBlackDisk.Location = new System.Drawing.Point(87, 21);
            this.lblNumberofBlackDisk.Name = "lblNumberofBlackDisk";
            this.lblNumberofBlackDisk.Size = new System.Drawing.Size(65, 60);
            this.lblNumberofBlackDisk.TabIndex = 12;
            this.lblNumberofBlackDisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(21, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(21, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // grpNumberDisk
            // 
            this.grpNumberDisk.Controls.Add(this.button1);
            this.grpNumberDisk.Controls.Add(this.lblNumberofWhiteDisk);
            this.grpNumberDisk.Controls.Add(this.button3);
            this.grpNumberDisk.Controls.Add(this.lblNumberofBlackDisk);
            this.grpNumberDisk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNumberDisk.Location = new System.Drawing.Point(599, 352);
            this.grpNumberDisk.Name = "grpNumberDisk";
            this.grpNumberDisk.Size = new System.Drawing.Size(180, 178);
            this.grpNumberDisk.TabIndex = 14;
            this.grpNumberDisk.TabStop = false;
            this.grpNumberDisk.Text = "Number Disks";
            // 
            // btnSwap
            // 
            this.btnSwap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwap.Location = new System.Drawing.Point(599, 208);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(110, 50);
            this.btnSwap.TabIndex = 15;
            this.btnSwap.Text = "Swap Black and White";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormBoardEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 653);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.grpNumberDisk);
            this.Controls.Add(this.comboSideToMove);
            this.Controls.Add(this.lblSideToMove);
            this.Controls.Add(this.btnClearBoard);
            this.Controls.Add(this.grpChooseCellType);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormBoardEditor";
            this.Text = "Board Editor";
            this.Load += new System.EventHandler(this.FormTestBoardPictureBox_Load);
            this.grpChooseCellType.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpNumberDisk.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnBlank;
        private System.Windows.Forms.GroupBox grpChooseCellType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnClearBoard;
        private System.Windows.Forms.Label lblSideToMove;
        private System.Windows.Forms.ComboBox comboSideToMove;
        private System.Windows.Forms.Label lblNumberofWhiteDisk;
        private System.Windows.Forms.Label lblNumberofBlackDisk;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpNumberDisk;
        private System.Windows.Forms.ToolStripMenuItem closeBoardEditorAndPlayFromThisBoardToolStripMenuItem;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecentlyEmpty;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemRecentlyLine;
    }
}