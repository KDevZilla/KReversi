using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace KReversi.UI
{
    public class PanelBotConfigure : Panel
    {
        public PanelPositionBotConfigure panelposition { get; private set; }
        private Label labelBotDepthFrom = null;
        private Label labelBotDepthTo = null;
        private Label labelScoreMobilize = null;

        public Button btnCopyCellToOther1 = null;
        public Button btnCopyCellToOther2 = null;


        public NumericUpDown numScoreMobilize = null;
        public NumericUpDown numBotDepth = null;
        private CheckBox checkboxConfigureOnlyTopLeftPath = null;
        public int[,] arrValue
        {
            get { return this.panelposition.arrValue; }
            set { this.panelposition.SetArrValue(value); }
        }

        public Color ControlForeColor { get; set; } = Color.Black;
        public event EventHandler CopyCellToOther1Clicked = null;
        public event EventHandler CopyCellToOther2Clicked = null;
        public void UpdateRenderPosition()
        {
            panelposition.UpdateRenderPosition();
        }
        public void Initial()
        {

            if (this.Controls.Contains(panelposition))
            {
                this.Controls.Remove(panelposition);
                this.Controls.Remove(labelBotDepthFrom);
                this.Controls.Remove(labelBotDepthTo);
                this.Controls.Remove(labelScoreMobilize);
                this.Controls.Remove(numScoreMobilize);
                this.Controls.Remove(numBotDepth);
                this.Controls.Remove(checkboxConfigureOnlyTopLeftPath);
                this.Controls.Remove(btnCopyCellToOther1);
                this.Controls.Remove(btnCopyCellToOther2);

                this.checkboxConfigureOnlyTopLeftPath.CheckedChanged -= CheckboxConfigureOnlyTopLeftPath_CheckedChanged;
                this.btnCopyCellToOther1.Click -= BtnCopyCellToOther1_Click;
                this.btnCopyCellToOther2.Click -= BtnCopyCellToOther2_Click;
            }

            panelposition = new PanelPositionBotConfigure();
            labelBotDepthFrom = new Label();
            labelBotDepthTo = new Label();
            labelScoreMobilize = new Label();

            numBotDepth = new NumericUpDown();

            numScoreMobilize = new NumericUpDown();
            checkboxConfigureOnlyTopLeftPath = new CheckBox();
            btnCopyCellToOther1 = new Button();
            btnCopyCellToOther2 = new Button();

            this.labelBotDepthFrom.AutoSize = true;
            this.labelBotDepthFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBotDepthFrom.Location = new System.Drawing.Point(35, 466);
            this.labelBotDepthFrom.Name = "labelBotDepthFrom";
            this.labelBotDepthFrom.Size = new System.Drawing.Size(135, 20);
            this.labelBotDepthFrom.TabIndex = 0;
            this.labelBotDepthFrom.Text = "Depth Level";
            this.labelBotDepthFrom.Visible = true;

            // 
            // textBotDepthFrom
            // 

            this.numBotDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBotDepth.Location = new System.Drawing.Point(176, 463);
            this.numBotDepth.Name = "textBotDepthFrom";
            this.numBotDepth.Size = new System.Drawing.Size(84, 26);
            this.numBotDepth.TabIndex = 1;
            this.numBotDepth.Visible = true;
            this.numBotDepth.Minimum = 1;
            this.numBotDepth.Maximum = 10;
            this.numBotDepth.Increment = 1;
            this.numBotDepth.TextAlign = HorizontalAlignment.Right;

            // 
            // labelScoreAvilableMove
            // 
            this.labelScoreMobilize.AutoSize = true;
            this.labelScoreMobilize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreMobilize.Location = new System.Drawing.Point(19, 425);
            this.labelScoreMobilize.Name = "labelScoreMobilize";
            this.labelScoreMobilize.Size = new System.Drawing.Size(151, 20);
            this.labelScoreMobilize.TabIndex = 4;
            this.labelScoreMobilize.Text = "Score Mobilize";
            this.labelScoreMobilize.Visible = true;
            // 
            // textScoreAvilableMove
            // 

            this.numScoreMobilize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numScoreMobilize.Location = new System.Drawing.Point(176, 425);
            this.numScoreMobilize.Name = "numScoreMobilize";
            this.numScoreMobilize.Size = new System.Drawing.Size(84, 26);
            this.numScoreMobilize.TabIndex = 5;
            this.numScoreMobilize.Visible = true;
            this.numScoreMobilize.Minimum = -70;
            this.numScoreMobilize.Maximum = 70;
            this.numScoreMobilize.Increment = 10;
            this.numScoreMobilize.TextAlign = HorizontalAlignment.Right;
            // 
            // panelposition
            // 
            this.panelposition.Location = new System.Drawing.Point(14, 44);
            this.panelposition.Name = "panelposition";
            this.panelposition.Size = new System.Drawing.Size(360, 360);
            this.panelposition.TabIndex = 6;
            // 
            // checkboxConfigureOnlyTopLeftPath
            // 
            this.checkboxConfigureOnlyTopLeftPath.AutoSize = true;
            this.checkboxConfigureOnlyTopLeftPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxConfigureOnlyTopLeftPath.Location = new System.Drawing.Point(14, 20);
            this.checkboxConfigureOnlyTopLeftPath.Name = "checkboxConfigureOnlyTopLeftPath";
            this.checkboxConfigureOnlyTopLeftPath.Size = new System.Drawing.Size(223, 24);
            this.checkboxConfigureOnlyTopLeftPath.TabIndex = 7;
            this.checkboxConfigureOnlyTopLeftPath.Text = "Configure only cell A1 to D4";
            this.checkboxConfigureOnlyTopLeftPath.UseVisualStyleBackColor = true;
            this.checkboxConfigureOnlyTopLeftPath.Visible = true;

            int btnCopyHeight = (67 * 2) + 10;
            // btnCopyCellToOther1
            // 
            this.btnCopyCellToOther1.Location = new System.Drawing.Point(panelposition.Left + panelposition.Width + 20, panelposition.Top + panelposition.Height - btnCopyHeight);
            this.btnCopyCellToOther1.Name = "btnCopyCellToOther1";
            this.btnCopyCellToOther1.Size = new System.Drawing.Size(103, 67);
            this.btnCopyCellToOther1.TabIndex = 8;
            this.btnCopyCellToOther1.Text = "CopyCell to (1)";
            this.btnCopyCellToOther1.UseVisualStyleBackColor = true;
            this.btnCopyCellToOther1.Visible = true;
            // 
            // btnCopyCellToOther2
            // 
            this.btnCopyCellToOther2.Location = new System.Drawing.Point(panelposition.Left + panelposition.Width + 20, btnCopyCellToOther1.Top + btnCopyCellToOther1.Height + 10);
            this.btnCopyCellToOther2.Name = "btnCopyCellToOther2";
            this.btnCopyCellToOther2.Size = new System.Drawing.Size(103, 67);
            this.btnCopyCellToOther2.TabIndex = 9;
            this.btnCopyCellToOther2.Text = "CopyCell to (2)";
            this.btnCopyCellToOther2.UseVisualStyleBackColor = true;
            this.btnCopyCellToOther2.Visible = true;


            this.checkboxConfigureOnlyTopLeftPath.ForeColor = this.ControlForeColor;
            this.labelBotDepthFrom.ForeColor = this.ControlForeColor;
            this.labelScoreMobilize.ForeColor = this.ControlForeColor;
            this.panelposition.ControlForeColor = this.ControlForeColor;

            this.numBotDepth.Text = "1";

            this.numScoreMobilize.Text = "10";

            this.Controls.Add(panelposition);
            this.Controls.Add(labelBotDepthFrom);
            this.Controls.Add(labelBotDepthTo);
            this.Controls.Add(labelScoreMobilize);
            this.Controls.Add(numBotDepth);
            this.Controls.Add(numScoreMobilize);
            this.Controls.Add(checkboxConfigureOnlyTopLeftPath);
            this.Controls.Add(btnCopyCellToOther1);
            this.Controls.Add(btnCopyCellToOther2);

            panelposition.Initial();

            this.checkboxConfigureOnlyTopLeftPath.Checked = true;
            this.panelposition.IsConfigureOnlyTopLeftPart = true;
            this.checkboxConfigureOnlyTopLeftPath.CheckedChanged -= CheckboxConfigureOnlyTopLeftPath_CheckedChanged;

            this.checkboxConfigureOnlyTopLeftPath.CheckedChanged += CheckboxConfigureOnlyTopLeftPath_CheckedChanged;
            this.btnCopyCellToOther1.Click -= BtnCopyCellToOther1_Click;
            this.btnCopyCellToOther2.Click -= BtnCopyCellToOther2_Click;
            this.btnCopyCellToOther1.Click += BtnCopyCellToOther1_Click;
            this.btnCopyCellToOther2.Click += BtnCopyCellToOther2_Click;
        }

        private void BtnCopyCellToOther2_Click(object sender, EventArgs e)
        {

            CopyCellToOther2Clicked?.Invoke(this, null);
        }

        private void BtnCopyCellToOther1_Click(object sender, EventArgs e)
        {

            CopyCellToOther1Clicked?.Invoke(this, null);
        }

        private void CheckboxConfigureOnlyTopLeftPath_CheckedChanged(object sender, EventArgs e)
        {

            this.panelposition.IsConfigureOnlyTopLeftPart = this.checkboxConfigureOnlyTopLeftPath.Checked;
        }
    }
}
