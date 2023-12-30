namespace KReversi
{
    partial class FormShowMinimax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowMinimax));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chkUserReversiNotation = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(-3, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(419, 611);
            this.treeView1.TabIndex = 0;
            // 
            // chkUserReversiNotation
            // 
            this.chkUserReversiNotation.AutoSize = true;
            this.chkUserReversiNotation.Checked = true;
            this.chkUserReversiNotation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserReversiNotation.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.chkUserReversiNotation.Location = new System.Drawing.Point(491, 583);
            this.chkUserReversiNotation.Margin = new System.Windows.Forms.Padding(2);
            this.chkUserReversiNotation.Name = "chkUserReversiNotation";
            this.chkUserReversiNotation.Size = new System.Drawing.Size(205, 29);
            this.chkUserReversiNotation.TabIndex = 12;
            this.chkUserReversiNotation.Text = "Use Reversi Notation";
            this.chkUserReversiNotation.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkUserReversiNotation.UseVisualStyleBackColor = true;
            this.chkUserReversiNotation.CheckedChanged += new System.EventHandler(this.chkUserReversiNotation_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(868, 573);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 39);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormShowMinimax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 618);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkUserReversiNotation);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormShowMinimax";
            this.Text = "FormShowMinimax";
            this.Load += new System.EventHandler(this.FormShowMinimax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox chkUserReversiNotation;
        private System.Windows.Forms.Button btnClose;
    }
}