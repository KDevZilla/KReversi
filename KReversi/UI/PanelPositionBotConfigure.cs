using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi.UI
{
    public class PanelPositionBotConfigure : Panel
    {
        private TextBox[,] arrTextBox = null;

        public int[,] arrValue { get; private set; } = {
            { 100, -20, 20, 5, 5, 20, -20, 100 },
            { -20, -30, -5, -5, -5, -5, -30, -20 },
            { 20, -5, 15, 3, 3, 15, -5, 20 },
            { 5, -5, 3, 3, 3, 3, -5, 5 },
            { 5, -5, 3, 3, 3, 3, -5, 5 },
            { 20, -5, 15, 3, 3, 15, -5, 20 },
            { -20, -30, -5, -5, -5, -5, -30, -20 },
            { 100, -20, 20, 5, 5, 20, -20, 100 }
        };
        public int CellWidth { get; set; } = 40;
        public bool IsConfigureOnlyTopLeftPart = false;
        public void SetArrValue(int[,] pArrValue)
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    arrValue[i, j] = pArrValue[i, j];
                    arrTextBox[i, j].Text = arrValue[i, j].ToString();
                }
            }

        }
        public Color ControlForeColor { get; set; } = Color.Black;
        public void UpdateRenderPosition()
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {


                    arrTextBox[i, j].Text = arrValue[i, j].ToString(); //OpenGamePostionScore[i, j].ToString();

                }
            }
        }
        public void Initial()
        {
            int i;
            int j;
            //listTextbox

            arrTextBox = new TextBox[8, 8];
            this.Controls.Clear();

            for (i = 0; i <= 7; i++)
            {
                Label LabelRow = new Label();
                Label LabelCol = new Label();

                LabelRow.AutoSize = false;
                LabelRow.Height = CellWidth;
                LabelRow.Width = CellWidth;
                LabelRow.Top = (i + 1) * CellWidth;
                LabelRow.Left = 0;
                LabelRow.Font = new Font(LabelRow.Font.Name, 13f);
                LabelRow.TextAlign = ContentAlignment.MiddleCenter;

                // LabelCol.BackColor = Color.Green;
                LabelCol.AutoSize = false;
                LabelCol.Height = CellWidth;
                LabelCol.Width = CellWidth;
                LabelCol.Top = 0;
                LabelCol.Left = (i + 1) * CellWidth;
                LabelCol.Font = new Font(LabelRow.Font.Name, 13f);
                LabelCol.TextAlign = ContentAlignment.MiddleCenter;

                int iValue = i + 1;// NoofRow  - i;

                int unicode = 65 + i;
                char character = (char)unicode;
                LabelRow.Text = iValue.ToString();
                LabelCol.Text = character.ToString();

                LabelRow.ForeColor = this.ControlForeColor;
                LabelCol.ForeColor = this.ControlForeColor;
                this.Controls.Add(LabelRow);
                this.Controls.Add(LabelCol);

            }
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    TextBox tb = new TextBox();
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.Multiline = true;
                    tb.Width = CellWidth;
                    tb.Height = CellWidth;
                    tb.TextAlign = HorizontalAlignment.Center;
                    tb.Font = new Font(tb.Font.Name, 12);
                    tb.Top = (i + 1) * tb.Height;
                    tb.Left = (j + 1) * tb.Width;

                    tb.Tag = i.ToString("00") + "_" + j.ToString("00");
                    tb.KeyDown += Tb_KeyDown;

                    tb.LostFocus += Tb_LostFocus;
                    //listTextbox.Add(tb);
                    arrTextBox[i, j] = tb;
                    arrTextBox[i, j].Text = arrValue[i, j].ToString(); //OpenGamePostionScore[i, j].ToString();
                    SetTextColor(tb);
                    if (i <= 3 && j <= 3)
                    {
                        arrTextBox[i, j].TextChanged += Tb_TextChanged;
                        // continue;
                    }
                    this.Controls.Add(tb);
                }
            }
            this.Height = CellWidth * 9;
            this.Width = CellWidth * 9;

            HasfinishedRenderTextBox = true;
            if (IsConfigureOnlyTopLeftPart)
            {
                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {
                        if (i <= 3 && j <= 3)
                        {
                            arrTextBox[i, j].TextChanged += Tb_TextChanged;
                            continue;
                        }
                        arrTextBox[i, j].Visible = false;
                    }
                }
            }
        }
        public void ShowValuefromarr()
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    arrTextBox[i, j].Text = arrValue[i, j].ToString();
                }
            }
        }
        public Boolean IsTextBoxValueValid(int MinValueValid, int MaxValueValid)
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    if (!Utility.Utility.IsInt(this.arrTextBox[i, j].Text))
                    {
                        return false;
                    }
                    int Value = int.Parse(this.arrTextBox[i, j].Text);
                    if (Value < MinValueValid ||
                        Value > MaxValueValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void UpdateValuefromTextbox()
        {
            int i;
            int j;
            for (i = 0; i <= 7; i++)
            {
                for (j = 0; j <= 7; j++)
                {
                    arrValue[i, j] = int.Parse(arrTextBox[i, j].Text);
                }
            }
        }

        private Boolean HasfinishedRenderTextBox = false;
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            if (!HasfinishedRenderTextBox)
            {
                return;
            }

            TextBox textbox = (TextBox)sender;
            if (!Utility.Utility.IsInt(textbox.Text))
            {
                return;
            }

            if (!this.IsConfigureOnlyTopLeftPart)
            {
                return;
            }

            int SetValue = int.Parse(textbox.Text);
            int Row = int.Parse(textbox.Tag.ToString().Substring(0, 2));
            int Col = int.Parse(textbox.Tag.ToString().Substring(3, 2));
            int RowonRight = Row;
            int ColonRight = 7 - Col;
            int RowonBottomLeft = 7 - Row;
            int ColonBottomLeft = Col;
            int RowonBottomRight = 7 - Row;
            int ColonBottomRight = 7 - Col;

            arrTextBox[RowonRight, ColonRight].Text = SetValue.ToString();
            arrTextBox[RowonBottomLeft, ColonBottomLeft].Text = SetValue.ToString();
            arrTextBox[RowonBottomRight, ColonBottomRight].Text = SetValue.ToString();
            SetTextColor(textbox);
            SetTextColor(arrTextBox[RowonRight, ColonRight]);
            SetTextColor(arrTextBox[RowonBottomLeft, ColonBottomLeft]);
            SetTextColor(arrTextBox[RowonBottomRight, ColonBottomRight]);

        }

        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Down &&
                 e.KeyCode != Keys.Up &&
                 e.KeyCode != Keys.Left &&
                 e.KeyCode != Keys.Right)
            {
                return;
            }
            TextBox textSender = (TextBox)sender;
            int Row = int.Parse(textSender.Tag.ToString().Substring(0, 2));
            int Col = int.Parse(textSender.Tag.ToString().Substring(3, 2));

            switch (e.KeyCode)
            {
                case Keys.Down:
                    Row++;
                    break;
                case Keys.Up:
                    Row--;
                    break;
                case Keys.Left:
                    Col--;
                    break;
                case Keys.Right:
                    Col++;
                    break;
            }
            if (IsConfigureOnlyTopLeftPart)
            {
                if (Row < 0 ||
                    Row > 3 ||
                    Col < 0 ||
                    Col > 3)
                {
                    return;
                }
            }
            else
            {
                if (Row < 0 ||
                    Row > 7 ||
                    Col < 0 ||
                    Col > 7)
                {
                    return;
                }
            }

            arrTextBox[Row, Col].Focus();
            e.Handled = true;

        }


        private void SetTextColor(TextBox textbox)
        {
            int Value = int.Parse(textbox.Text);
            Color backColor = Color.White;
            Color ForeColor = Color.Black;

            Color Red1 = Color.FromArgb(247, 153, 157);
            Color Red2 = Color.FromArgb(242, 96, 103);
            Color Red3 = Color.FromArgb(239, 52, 62);
            Color Red4 = Color.FromArgb(197, 16, 26);

            Color Green1 = Color.FromArgb(180, 252, 208);
            Color Green2 = Color.FromArgb(105, 250, 163);
            Color Green3 = Color.FromArgb(43, 247, 124);
            Color Green4 = Color.FromArgb(7, 190, 81);

            if (Value < -60)
            {
                backColor = Red4;
                ForeColor = Color.White;
            }
            else if (Value < -40)
            {
                backColor = Red3;
                ForeColor = Color.White;
            }
            else if (Value < -20)
            {
                backColor = Red2;
                ForeColor = Color.White;
            }
            else if (Value < 0)
            {
                backColor = Red1;
                ForeColor = Color.White;
            }
            else if (Value > 60)
            {
                backColor = Green4;
            }
            else if (Value > 15)
            {
                backColor = Green3;
            }
            else if (Value > 5)
            {
                backColor = Green2;
            }
            else if (Value > 0)
            {
                backColor = Green1;
            }
            textbox.BackColor = backColor;
            textbox.ForeColor = ForeColor;
        }
        private void Tb_LostFocus(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            TextBox textSender = (TextBox)sender;
            if (!Utility.Utility.IsInt(textSender.Text))
            {
                return;
            }
            SetTextColor(textSender);


        }
    }
}
