namespace KReversi
{
    partial class FormNewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewGame));
            this.panelPicboard = new System.Windows.Forms.Panel();
            this.cboMap = new System.Windows.Forms.ComboBox();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.cboPlayer1 = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.cboPlayer2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPicboard
            // 
            this.panelPicboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPicboard.Location = new System.Drawing.Point(12, 12);
            this.panelPicboard.Name = "panelPicboard";
            this.panelPicboard.Size = new System.Drawing.Size(320, 320);
            this.panelPicboard.TabIndex = 0;
            // 
            // cboMap
            // 
            this.cboMap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMap.FormattingEnabled = true;
            this.cboMap.Location = new System.Drawing.Point(12, 338);
            this.cboMap.Name = "cboMap";
            this.cboMap.Size = new System.Drawing.Size(320, 29);
            this.cboMap.TabIndex = 1;
            // 
            // picPlayer1
            // 
            this.picPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer1.Location = new System.Drawing.Point(18, 28);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(90, 90);
            this.picPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer1.TabIndex = 9;
            this.picPlayer1.TabStop = false;
            // 
            // cboPlayer1
            // 
            this.cboPlayer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayer1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlayer1.FormattingEnabled = true;
            this.cboPlayer1.Location = new System.Drawing.Point(18, 126);
            this.cboPlayer1.Name = "cboPlayer1";
            this.cboPlayer1.Size = new System.Drawing.Size(237, 29);
            this.cboPlayer1.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DimGray;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(389, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 44);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(512, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 44);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.picPlayer1);
            this.groupBox1.Controls.Add(this.cboPlayer1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(359, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 180);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(195, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 60);
            this.label1.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.picPlayer2);
            this.groupBox2.Controls.Add(this.cboPlayer2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(359, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 180);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player2";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(195, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 60);
            this.label2.TabIndex = 20;
            // 
            // picPlayer2
            // 
            this.picPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPlayer2.Location = new System.Drawing.Point(18, 28);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(90, 90);
            this.picPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer2.TabIndex = 9;
            this.picPlayer2.TabStop = false;
            // 
            // cboPlayer2
            // 
            this.cboPlayer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayer2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlayer2.FormattingEnabled = true;
            this.cboPlayer2.Location = new System.Drawing.Point(18, 126);
            this.cboPlayer2.Name = "cboPlayer2";
            this.cboPlayer2.Size = new System.Drawing.Size(237, 29);
            this.cboPlayer2.TabIndex = 12;
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(636, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboMap);
            this.Controls.Add(this.panelPicboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KReversi New Game";
            this.Load += new System.EventHandler(this.FormNewGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPicboard;
        private System.Windows.Forms.ComboBox cboMap;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.ComboBox cboPlayer1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.ComboBox cboPlayer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}