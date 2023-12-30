namespace KReversi
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblNumberofWhiteDisk = new System.Windows.Forms.Label();
            this.btnContinuePlayingGamefromHere = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.lblNumberofBlackDisk = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.lblPlayer1Border = new System.Windows.Forms.Label();
            this.lblPlayer2Border = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setupBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.showMiniMaxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.botToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DimGray;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(118, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(51, 41);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "→ ";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.DimGray;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(62, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(51, 41);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "←";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(962, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(338, 563);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(330, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Player";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(330, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblNumberofWhiteDisk
            // 
            this.lblNumberofWhiteDisk.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberofWhiteDisk.ForeColor = System.Drawing.Color.White;
            this.lblNumberofWhiteDisk.Location = new System.Drawing.Point(186, 134);
            this.lblNumberofWhiteDisk.Name = "lblNumberofWhiteDisk";
            this.lblNumberofWhiteDisk.Size = new System.Drawing.Size(65, 60);
            this.lblNumberofWhiteDisk.TabIndex = 17;
            this.lblNumberofWhiteDisk.Text = "0";
            this.lblNumberofWhiteDisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinuePlayingGamefromHere
            // 
            this.btnContinuePlayingGamefromHere.BackColor = System.Drawing.Color.DarkOrange;
            this.btnContinuePlayingGamefromHere.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuePlayingGamefromHere.Location = new System.Drawing.Point(248, 483);
            this.btnContinuePlayingGamefromHere.Name = "btnContinuePlayingGamefromHere";
            this.btnContinuePlayingGamefromHere.Size = new System.Drawing.Size(46, 39);
            this.btnContinuePlayingGamefromHere.TabIndex = 16;
            this.btnContinuePlayingGamefromHere.Text = "Continue Playing Game ";
            this.btnContinuePlayingGamefromHere.UseVisualStyleBackColor = false;
            this.btnContinuePlayingGamefromHere.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(10, 232);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 241);
            this.panel1.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 32;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 640);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panelNavigator
            // 
            this.panelNavigator.Controls.Add(this.btnPrevious);
            this.panelNavigator.Controls.Add(this.btnFirst);
            this.panelNavigator.Controls.Add(this.btnNext);
            this.panelNavigator.Controls.Add(this.btnLast);
            this.panelNavigator.Location = new System.Drawing.Point(11, 479);
            this.panelNavigator.Name = "panelNavigator";
            this.panelNavigator.Size = new System.Drawing.Size(231, 57);
            this.panelNavigator.TabIndex = 5;
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.DimGray;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(4, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(51, 41);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.Text = "↞ ";
            this.btnFirst.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnFirst.UseVisualStyleBackColor = false;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.DimGray;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(175, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(51, 41);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = "↠";
            this.btnLast.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLast.UseVisualStyleBackColor = false;
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Name.Location = new System.Drawing.Point(128, 204);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(130, 25);
            this.lblPlayer2Name.TabIndex = 11;
            this.lblPlayer2Name.Text = "Player2Name";
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.AutoSize = true;
            this.lblPlayer1Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Name.Location = new System.Drawing.Point(128, 93);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(130, 25);
            this.lblPlayer1Name.TabIndex = 10;
            this.lblPlayer1Name.Text = "Player1Name";
            // 
            // lblNumberofBlackDisk
            // 
            this.lblNumberofBlackDisk.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberofBlackDisk.ForeColor = System.Drawing.Color.White;
            this.lblNumberofBlackDisk.Location = new System.Drawing.Point(186, 24);
            this.lblNumberofBlackDisk.Name = "lblNumberofBlackDisk";
            this.lblNumberofBlackDisk.Size = new System.Drawing.Size(65, 60);
            this.lblNumberofBlackDisk.TabIndex = 8;
            this.lblNumberofBlackDisk.Text = "0";
            this.lblNumberofBlackDisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumberofBlackDisk.Click += new System.EventHandler(this.lblNumberofBlackDisk_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(128, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.Enabled = false;
            this.btnBlack.Location = new System.Drawing.Point(128, 23);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(60, 60);
            this.btnBlack.TabIndex = 6;
            this.btnBlack.UseVisualStyleBackColor = false;
            // 
            // lblPlayer1Border
            // 
            this.lblPlayer1Border.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPlayer1Border.Location = new System.Drawing.Point(10, 19);
            this.lblPlayer1Border.Name = "lblPlayer1Border";
            this.lblPlayer1Border.Size = new System.Drawing.Size(100, 101);
            this.lblPlayer1Border.TabIndex = 12;
            // 
            // lblPlayer2Border
            // 
            this.lblPlayer2Border.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPlayer2Border.Location = new System.Drawing.Point(10, 130);
            this.lblPlayer2Border.Name = "lblPlayer2Border";
            this.lblPlayer2Border.Size = new System.Drawing.Size(100, 100);
            this.lblPlayer2Border.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.botToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveGameAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemRecently1,
            this.toolStripMenuItemRecently2,
            this.toolStripMenuItemRecently3,
            this.toolStripMenuItemRecently4,
            this.toolStripMenuItemRecently5,
            this.toolStripMenuItemRecently6,
            this.toolStripMenuItemRecentlyEmpty,
            this.toolStripMenuItemRecentlyLine,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.loadToolStripMenuItem.Text = "Load Game";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveGameAsToolStripMenuItem
            // 
            this.saveGameAsToolStripMenuItem.Name = "saveGameAsToolStripMenuItem";
            this.saveGameAsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveGameAsToolStripMenuItem.Text = "Save Game As";
            this.saveGameAsToolStripMenuItem.Click += new System.EventHandler(this.saveGameAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // toolStripMenuItemRecently1
            // 
            this.toolStripMenuItemRecently1.Name = "toolStripMenuItemRecently1";
            this.toolStripMenuItemRecently1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently1.Text = "1.";
            // 
            // toolStripMenuItemRecently2
            // 
            this.toolStripMenuItemRecently2.Name = "toolStripMenuItemRecently2";
            this.toolStripMenuItemRecently2.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently2.Text = "2.";
            // 
            // toolStripMenuItemRecently3
            // 
            this.toolStripMenuItemRecently3.Name = "toolStripMenuItemRecently3";
            this.toolStripMenuItemRecently3.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently3.Text = "3.";
            // 
            // toolStripMenuItemRecently4
            // 
            this.toolStripMenuItemRecently4.Name = "toolStripMenuItemRecently4";
            this.toolStripMenuItemRecently4.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently4.Text = "4.";
            // 
            // toolStripMenuItemRecently5
            // 
            this.toolStripMenuItemRecently5.Name = "toolStripMenuItemRecently5";
            this.toolStripMenuItemRecently5.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently5.Text = "5.";
            // 
            // toolStripMenuItemRecently6
            // 
            this.toolStripMenuItemRecently6.Name = "toolStripMenuItemRecently6";
            this.toolStripMenuItemRecently6.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecently6.Text = "6.";
            // 
            // toolStripMenuItemRecentlyEmpty
            // 
            this.toolStripMenuItemRecentlyEmpty.Name = "toolStripMenuItemRecentlyEmpty";
            this.toolStripMenuItemRecentlyEmpty.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemRecentlyEmpty.Text = "Empty Recently Game Files";
            // 
            // toolStripMenuItemRecentlyLine
            // 
            this.toolStripMenuItemRecentlyLine.Name = "toolStripMenuItemRecentlyLine";
            this.toolStripMenuItemRecentlyLine.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setupBoardToolStripMenuItem,
            this.saveCurrentBoardToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem3,
            this.showMiniMaxToolStripMenuItem1});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.toolStripMenuItem1.Text = "Open Board";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // setupBoardToolStripMenuItem
            // 
            this.setupBoardToolStripMenuItem.Name = "setupBoardToolStripMenuItem";
            this.setupBoardToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.setupBoardToolStripMenuItem.Text = "Setup Board";
            this.setupBoardToolStripMenuItem.Click += new System.EventHandler(this.setupBoardToolStripMenuItem_Click);
            // 
            // saveCurrentBoardToolStripMenuItem
            // 
            this.saveCurrentBoardToolStripMenuItem.Name = "saveCurrentBoardToolStripMenuItem";
            this.saveCurrentBoardToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.saveCurrentBoardToolStripMenuItem.Text = "Open Setup Board with Current Board";
            this.saveCurrentBoardToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentBoardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(270, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(273, 22);
            this.toolStripMenuItem3.Text = "Configure";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // showMiniMaxToolStripMenuItem1
            // 
            this.showMiniMaxToolStripMenuItem1.Name = "showMiniMaxToolStripMenuItem1";
            this.showMiniMaxToolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.showMiniMaxToolStripMenuItem1.Text = "Show MiniMax Latest Move";
            this.showMiniMaxToolStripMenuItem1.Click += new System.EventHandler(this.showMiniMaxToolStripMenuItem1_Click);
            // 
            // botToolStripMenuItem
            // 
            this.botToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botEditorToolStripMenuItem});
            this.botToolStripMenuItem.Name = "botToolStripMenuItem";
            this.botToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.botToolStripMenuItem.Text = "Bot";
            // 
            // botEditorToolStripMenuItem
            // 
            this.botEditorToolStripMenuItem.Name = "botEditorToolStripMenuItem";
            this.botEditorToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.botEditorToolStripMenuItem.Text = "Bot Editor";
            this.botEditorToolStripMenuItem.Click += new System.EventHandler(this.botEditorToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.btnBlack);
            this.panelInfo.Controls.Add(this.lblNumberofWhiteDisk);
            this.panelInfo.Controls.Add(this.button3);
            this.panelInfo.Controls.Add(this.btnContinuePlayingGamefromHere);
            this.panelInfo.Controls.Add(this.lblNumberofBlackDisk);
            this.panelInfo.Controls.Add(this.picPlayer2);
            this.panelInfo.Controls.Add(this.panel1);
            this.panelInfo.Controls.Add(this.lblPlayer1Name);
            this.panelInfo.Controls.Add(this.picPlayer1);
            this.panelInfo.Controls.Add(this.lblPlayer1Border);
            this.panelInfo.Controls.Add(this.panelNavigator);
            this.panelInfo.Controls.Add(this.lblPlayer2Name);
            this.panelInfo.Controls.Add(this.lblPlayer2Border);
            this.panelInfo.Location = new System.Drawing.Point(568, 26);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(299, 553);
            this.panelInfo.TabIndex = 18;
            this.panelInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInfo_Paint);
            // 
            // picPlayer2
            // 
            this.picPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer2.Location = new System.Drawing.Point(15, 135);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(90, 90);
            this.picPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer2.TabIndex = 4;
            this.picPlayer2.TabStop = false;
            // 
            // picPlayer1
            // 
            this.picPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer1.Location = new System.Drawing.Point(15, 24);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(90, 90);
            this.picPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer1.TabIndex = 5;
            this.picPlayer1.TabStop = false;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(868, 682);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KReversi";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Label lblNumberofBlackDisk;
        private System.Windows.Forms.Label lblPlayer2Name;
        private System.Windows.Forms.Label lblPlayer1Name;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setupBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblPlayer1Border;
        private System.Windows.Forms.Label lblPlayer2Border;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentBoardToolStripMenuItem;
        private System.Windows.Forms.Button btnContinuePlayingGamefromHere;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNumberofWhiteDisk;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showMiniMaxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecently6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemRecentlyLine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRecentlyEmpty;
    }
}