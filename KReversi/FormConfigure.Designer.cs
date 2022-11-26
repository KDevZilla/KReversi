namespace KReversi
{
    partial class FormConfigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigure));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.chkCompactMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWriteDebugLog = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.chkWriteDebugLogL2 = new System.Windows.Forms.CheckBox();
            this.chkWriteLog = new System.Windows.Forms.CheckBox();
            this.lblLogfileLocation = new System.Windows.Forms.Label();
            this.tabPageAI = new System.Windows.Forms.TabPage();
            this.chkAllowRandomDecision = new System.Windows.Forms.CheckBox();
            this.lblRandomDecision = new System.Windows.Forms.Label();
            this.chkKeepLatestDecision = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseAlphaBetaPruning = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageHumanPlayer1 = new System.Windows.Forms.TabPage();
            this.pictureboxBotPhoto1 = new System.Windows.Forms.PictureBox();
            this.btnChoosePhoto1 = new System.Windows.Forms.Button();
            this.lblName1 = new System.Windows.Forms.Label();
            this.pictureboxBotPhoto2 = new System.Windows.Forms.PictureBox();
            this.txtHumanPlayer1Name = new System.Windows.Forms.TextBox();
            this.txtHumanPlayer2Name = new System.Windows.Forms.TextBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.btnChoosePhoto2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOthers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageAI.SuspendLayout();
            this.tabPageHumanPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(480, 619);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 49);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(583, 619);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 49);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.Controls.Add(this.groupBox1);
            this.tabPageOthers.Controls.Add(this.chkCompactMode);
            this.tabPageOthers.Controls.Add(this.chkDarkMode);
            this.tabPageOthers.Location = new System.Drawing.Point(4, 34);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Size = new System.Drawing.Size(664, 563);
            this.tabPageOthers.TabIndex = 2;
            this.tabPageOthers.Text = "Others";
            this.tabPageOthers.UseVisualStyleBackColor = true;
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Location = new System.Drawing.Point(64, 37);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(124, 29);
            this.chkDarkMode.TabIndex = 2;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // chkCompactMode
            // 
            this.chkCompactMode.AutoSize = true;
            this.chkCompactMode.Location = new System.Drawing.Point(64, 72);
            this.chkCompactMode.Name = "chkCompactMode";
            this.chkCompactMode.Size = new System.Drawing.Size(160, 29);
            this.chkCompactMode.TabIndex = 3;
            this.chkCompactMode.Text = "Compact Mode";
            this.chkCompactMode.UseVisualStyleBackColor = true;
            this.chkCompactMode.CheckedChanged += new System.EventHandler(this.chkCompactMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLogfileLocation);
            this.groupBox1.Controls.Add(this.chkWriteLog);
            this.groupBox1.Controls.Add(this.chkWriteDebugLogL2);
            this.groupBox1.Controls.Add(this.lblWarning);
            this.groupBox1.Controls.Add(this.chkWriteDebugLog);
            this.groupBox1.Location = new System.Drawing.Point(20, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 409);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // chkWriteDebugLog
            // 
            this.chkWriteDebugLog.AutoSize = true;
            this.chkWriteDebugLog.Location = new System.Drawing.Point(19, 67);
            this.chkWriteDebugLog.Name = "chkWriteDebugLog";
            this.chkWriteDebugLog.Size = new System.Drawing.Size(182, 29);
            this.chkWriteDebugLog.TabIndex = 4;
            this.chkWriteDebugLog.Text = "Write Debug Log*";
            this.chkWriteDebugLog.UseVisualStyleBackColor = true;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(14, 146);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(473, 150);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "*If you enable \r\nWrite Debug Log and \r\nWrite Debug Log Level2\r\nThe program will b" +
    "e ultra slow and \r\nthe log file might be very big, \r\nplease choose this option i" +
    "n case you need to debug it.\r\n";
            // 
            // chkWriteDebugLogL2
            // 
            this.chkWriteDebugLogL2.AutoSize = true;
            this.chkWriteDebugLogL2.Location = new System.Drawing.Point(19, 102);
            this.chkWriteDebugLogL2.Name = "chkWriteDebugLogL2";
            this.chkWriteDebugLogL2.Size = new System.Drawing.Size(240, 29);
            this.chkWriteDebugLogL2.TabIndex = 5;
            this.chkWriteDebugLogL2.Text = "Write Debug Log Level2*";
            this.chkWriteDebugLogL2.UseVisualStyleBackColor = true;
            // 
            // chkWriteLog
            // 
            this.chkWriteLog.AutoSize = true;
            this.chkWriteLog.Location = new System.Drawing.Point(19, 32);
            this.chkWriteLog.Name = "chkWriteLog";
            this.chkWriteLog.Size = new System.Drawing.Size(118, 29);
            this.chkWriteLog.TabIndex = 0;
            this.chkWriteLog.Text = "Write Log ";
            this.chkWriteLog.UseVisualStyleBackColor = true;
            // 
            // lblLogfileLocation
            // 
            this.lblLogfileLocation.AutoSize = true;
            this.lblLogfileLocation.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblLogfileLocation.Location = new System.Drawing.Point(17, 311);
            this.lblLogfileLocation.Name = "lblLogfileLocation";
            this.lblLogfileLocation.Size = new System.Drawing.Size(151, 25);
            this.lblLogfileLocation.TabIndex = 13;
            this.lblLogfileLocation.Text = "Log file location:";
            this.lblLogfileLocation.Click += new System.EventHandler(this.lblLogfileLocation_Click);
            // 
            // tabPageAI
            // 
            this.tabPageAI.Controls.Add(this.label4);
            this.tabPageAI.Controls.Add(this.label3);
            this.tabPageAI.Controls.Add(this.label2);
            this.tabPageAI.Controls.Add(this.chkUseAlphaBetaPruning);
            this.tabPageAI.Controls.Add(this.label1);
            this.tabPageAI.Controls.Add(this.chkKeepLatestDecision);
            this.tabPageAI.Controls.Add(this.lblRandomDecision);
            this.tabPageAI.Controls.Add(this.chkAllowRandomDecision);
            this.tabPageAI.Location = new System.Drawing.Point(4, 34);
            this.tabPageAI.Name = "tabPageAI";
            this.tabPageAI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAI.Size = new System.Drawing.Size(664, 563);
            this.tabPageAI.TabIndex = 3;
            this.tabPageAI.Text = "AI";
            this.tabPageAI.UseVisualStyleBackColor = true;
            // 
            // chkAllowRandomDecision
            // 
            this.chkAllowRandomDecision.AutoSize = true;
            this.chkAllowRandomDecision.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkAllowRandomDecision.Location = new System.Drawing.Point(43, 46);
            this.chkAllowRandomDecision.Margin = new System.Windows.Forms.Padding(2);
            this.chkAllowRandomDecision.Name = "chkAllowRandomDecision";
            this.chkAllowRandomDecision.Size = new System.Drawing.Size(233, 29);
            this.chkAllowRandomDecision.TabIndex = 11;
            this.chkAllowRandomDecision.Text = "Allow Random decision ";
            this.chkAllowRandomDecision.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkAllowRandomDecision.UseVisualStyleBackColor = true;
            // 
            // lblRandomDecision
            // 
            this.lblRandomDecision.AutoSize = true;
            this.lblRandomDecision.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblRandomDecision.Location = new System.Drawing.Point(62, 77);
            this.lblRandomDecision.Name = "lblRandomDecision";
            this.lblRandomDecision.Size = new System.Drawing.Size(425, 100);
            this.lblRandomDecision.TabIndex = 12;
            this.lblRandomDecision.Text = "If the node value is the same for the first 14 disks.\r\n(This option exists to pre" +
    "vent the situation that\r\nBot vs Bot play exactly the same\r\neverytime)";
            // 
            // chkKeepLatestDecision
            // 
            this.chkKeepLatestDecision.AutoSize = true;
            this.chkKeepLatestDecision.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkKeepLatestDecision.Location = new System.Drawing.Point(43, 219);
            this.chkKeepLatestDecision.Margin = new System.Windows.Forms.Padding(2);
            this.chkKeepLatestDecision.Name = "chkKeepLatestDecision";
            this.chkKeepLatestDecision.Size = new System.Drawing.Size(503, 29);
            this.chkKeepLatestDecision.TabIndex = 13;
            this.chkKeepLatestDecision.Text = "Keep the lastest decision tree to show on Show Minimax";
            this.chkKeepLatestDecision.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkKeepLatestDecision.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(62, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 150);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // chkUseAlphaBetaPruning
            // 
            this.chkUseAlphaBetaPruning.AutoSize = true;
            this.chkUseAlphaBetaPruning.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkUseAlphaBetaPruning.Location = new System.Drawing.Point(43, 435);
            this.chkUseAlphaBetaPruning.Margin = new System.Windows.Forms.Padding(2);
            this.chkUseAlphaBetaPruning.Name = "chkUseAlphaBetaPruning";
            this.chkUseAlphaBetaPruning.Size = new System.Drawing.Size(230, 29);
            this.chkUseAlphaBetaPruning.TabIndex = 15;
            this.chkUseAlphaBetaPruning.Text = "Use Alpha Beta Pruning";
            this.chkUseAlphaBetaPruning.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkUseAlphaBetaPruning.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(332, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label3.Location = new System.Drawing.Point(340, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label4.Location = new System.Drawing.Point(62, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(576, 75);
            this.label4.TabIndex = 18;
            this.label4.Text = "You should always user Alpha Beta Pruning for better performance.\r\nThe only time " +
    "you disable this feature is the time you would like \r\nto learn Minimax without A" +
    "lpha Beta Pruning works.";
            // 
            // tabPageHumanPlayer1
            // 
            this.tabPageHumanPlayer1.Controls.Add(this.btnChoosePhoto2);
            this.tabPageHumanPlayer1.Controls.Add(this.lblName2);
            this.tabPageHumanPlayer1.Controls.Add(this.txtHumanPlayer2Name);
            this.tabPageHumanPlayer1.Controls.Add(this.txtHumanPlayer1Name);
            this.tabPageHumanPlayer1.Controls.Add(this.pictureboxBotPhoto2);
            this.tabPageHumanPlayer1.Controls.Add(this.lblName1);
            this.tabPageHumanPlayer1.Controls.Add(this.btnChoosePhoto1);
            this.tabPageHumanPlayer1.Controls.Add(this.pictureboxBotPhoto1);
            this.tabPageHumanPlayer1.Location = new System.Drawing.Point(4, 34);
            this.tabPageHumanPlayer1.Name = "tabPageHumanPlayer1";
            this.tabPageHumanPlayer1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHumanPlayer1.Size = new System.Drawing.Size(664, 563);
            this.tabPageHumanPlayer1.TabIndex = 0;
            this.tabPageHumanPlayer1.Text = "Human Player ";
            this.tabPageHumanPlayer1.UseVisualStyleBackColor = true;
            // 
            // pictureboxBotPhoto1
            // 
            this.pictureboxBotPhoto1.Location = new System.Drawing.Point(417, 61);
            this.pictureboxBotPhoto1.Name = "pictureboxBotPhoto1";
            this.pictureboxBotPhoto1.Size = new System.Drawing.Size(86, 90);
            this.pictureboxBotPhoto1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxBotPhoto1.TabIndex = 5;
            this.pictureboxBotPhoto1.TabStop = false;
            // 
            // btnChoosePhoto1
            // 
            this.btnChoosePhoto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoosePhoto1.Location = new System.Drawing.Point(380, 157);
            this.btnChoosePhoto1.Name = "btnChoosePhoto1";
            this.btnChoosePhoto1.Size = new System.Drawing.Size(123, 40);
            this.btnChoosePhoto1.TabIndex = 6;
            this.btnChoosePhoto1.Text = "Choose Photo";
            this.btnChoosePhoto1.UseVisualStyleBackColor = true;
            this.btnChoosePhoto1.Click += new System.EventHandler(this.btnChoosePhoto1_Click);
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Location = new System.Drawing.Point(12, 22);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(138, 25);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Player 1 Name:";
            // 
            // pictureboxBotPhoto2
            // 
            this.pictureboxBotPhoto2.Location = new System.Drawing.Point(417, 346);
            this.pictureboxBotPhoto2.Name = "pictureboxBotPhoto2";
            this.pictureboxBotPhoto2.Size = new System.Drawing.Size(86, 90);
            this.pictureboxBotPhoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxBotPhoto2.TabIndex = 11;
            this.pictureboxBotPhoto2.TabStop = false;
            // 
            // txtHumanPlayer1Name
            // 
            this.txtHumanPlayer1Name.Location = new System.Drawing.Point(151, 22);
            this.txtHumanPlayer1Name.Name = "txtHumanPlayer1Name";
            this.txtHumanPlayer1Name.Size = new System.Drawing.Size(352, 33);
            this.txtHumanPlayer1Name.TabIndex = 2;
            // 
            // txtHumanPlayer2Name
            // 
            this.txtHumanPlayer2Name.Location = new System.Drawing.Point(151, 305);
            this.txtHumanPlayer2Name.Name = "txtHumanPlayer2Name";
            this.txtHumanPlayer2Name.Size = new System.Drawing.Size(352, 33);
            this.txtHumanPlayer2Name.TabIndex = 10;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Location = new System.Drawing.Point(12, 305);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(138, 25);
            this.lblName2.TabIndex = 9;
            this.lblName2.Text = "Player 2 Name:";
            // 
            // btnChoosePhoto2
            // 
            this.btnChoosePhoto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoosePhoto2.Location = new System.Drawing.Point(380, 442);
            this.btnChoosePhoto2.Name = "btnChoosePhoto2";
            this.btnChoosePhoto2.Size = new System.Drawing.Size(123, 40);
            this.btnChoosePhoto2.TabIndex = 12;
            this.btnChoosePhoto2.Text = "Choose Photo";
            this.btnChoosePhoto2.UseVisualStyleBackColor = true;
            this.btnChoosePhoto2.Click += new System.EventHandler(this.btnChoosePhoto2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHumanPlayer1);
            this.tabControl1.Controls.Add(this.tabPageAI);
            this.tabControl1.Controls.Add(this.tabPageOthers);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 601);
            this.tabControl1.TabIndex = 8;
            // 
            // FormConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 678);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormConfigure";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.FormConfigure_Load);
            this.tabPageOthers.ResumeLayout(false);
            this.tabPageOthers.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageAI.ResumeLayout(false);
            this.tabPageAI.PerformLayout();
            this.tabPageHumanPlayer1.ResumeLayout(false);
            this.tabPageHumanPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxBotPhoto2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLogfileLocation;
        private System.Windows.Forms.CheckBox chkWriteLog;
        private System.Windows.Forms.CheckBox chkWriteDebugLogL2;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.CheckBox chkWriteDebugLog;
        private System.Windows.Forms.CheckBox chkCompactMode;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.TabPage tabPageAI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUseAlphaBetaPruning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkKeepLatestDecision;
        private System.Windows.Forms.Label lblRandomDecision;
        private System.Windows.Forms.CheckBox chkAllowRandomDecision;
        private System.Windows.Forms.TabPage tabPageHumanPlayer1;
        private System.Windows.Forms.Button btnChoosePhoto2;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.TextBox txtHumanPlayer2Name;
        private System.Windows.Forms.TextBox txtHumanPlayer1Name;
        private System.Windows.Forms.PictureBox pictureboxBotPhoto2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Button btnChoosePhoto1;
        private System.Windows.Forms.PictureBox pictureboxBotPhoto1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}