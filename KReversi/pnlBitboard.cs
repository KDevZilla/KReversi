using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi
{
    class pnlBitboard:System.Windows.Forms.Panel 
    {
        int buttonWidth = 40;
        public pnlBitboard (int pbuttonWidth)
        {
            buttonWidth = pbuttonWidth;
            this.LoadPanel();
        }
        public event EventHandler  ValueChanged;

        public pnlBitboard(int pbuttonWidth,ulong pValue)
        {
            buttonWidth = pbuttonWidth;
            this.Value = pValue;
            this.LoadPanel();
        }
        public pnlBitboard()
        {
            this.LoadPanel();
        }
        private List<Button> lstB = new List<Button>();
        private List<int> lstBitValue = new List<int>();
        private void btnSetValueClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            int index = (int)b.Tag;
            System.Drawing.Point P = new System.Drawing.Point();
            P = IndexToPoint(index);
            int Bit = GetBitByPosition(P.Y, P.X);
            int UpdateBit = 0;
            if(Bit ==0)
            {
                UpdateBit = 1;
            }
            SetBitByPosition(index, UpdateBit);
            if (ValueChanged != null)
            {
                EventArgs eventArgs = new EventArgs();              
                ValueChanged(this, eventArgs);
            }

            Display();


        }
        private ulong _Value = 0;
        public ulong Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                UpdateLstBit();
            }
        }
        private void UpdateLstBit()
        {
            if(lstBitValue.Count !=64)
            {
                return;
            }

            string binary = Convert.ToString((long)_Value , 2);
            if(binary.Length < 64)
            {
                string leading0 = new string('0', 64- binary.Length );
                binary = leading0 + binary;
            }
            int i;
            int j;
            int iCount = 0;
            for (i = binary.Length - 1; i >= 0; i--)
            {
                lstBitValue[i] = int.Parse(binary[63-i].ToString ());
            }
        }
        private int GetBitByPosition(int Row, int Col)
        {

            int index = PointToIndex(Row, Col);
            return int.Parse (lstBitValue [63-index].ToString ()) ;
        }
        private void SetBitByPosition(int Row, int Col, int bitValue)
        {
            if(Row < 0 || Row > 7)
            {
                throw new Exception("Row parameter supposed to be betweetn 0 to 7");
            }
            if (Col < 0 || Col > 7)
            {
                throw new Exception("Col parameter supposed to be betweetn 0 to 7");
            }

            if (bitValue != 0 && bitValue != 1)
            {
                throw new Exception("bitValue supposed to be either 0 or 1");
            }

            int index = ((Row * 8) + Col);
            ulong Put = 1;

            ulong NewBig = Put << index;
            _Value = _Value | NewBig;

        }
        private void SetBitByPosition(int index, int bitValue)
        {
            if (bitValue != 0 && bitValue != 1)
            {
                throw new Exception("bitValue supposed to be either 0 or 1");
            }

            if(index < 0 || index > 63)
            {
                throw new Exception("index paramete supposed to be between 0 to 63");
            }
            //ulong Put = 1;
            if (bitValue == 1)
            {
                ulong NewBig = (ulong)bitValue << index;
                _Value = _Value | NewBig;
            }
            else
            {

                _Value &= ~((ulong)1 << index);
            }
            UpdateLstBit();


        }

        public void Display()
        {
            /*
            string binary = Convert.ToString((long)pl, 2);
           // StringBuilder strB = new StringBuilder();
            int i;
            int j;
            int iCount = 0;
            for (i = binary.Length - 1; i >= 0; i--)
            {
                iCount++;
             //   strB.Append(binary[i]).Append("\t");
                if (iCount == 8)
                {
                    iCount = 0;
                   // strB.Append(Environment.NewLine);
                }
                lstB[i].Text = binary[i].ToString();
            }
            //T.Text = pl.ToString();

            //this.textBox1.Text = strB.ToString();
            //this.Text = pl.ToString();
            */
            int i;
            for(i=0;i<lstBitValue.Count;i++)
            {
                lstB[i].Text = lstBitValue[63-i].ToString();
                lstB[i].ForeColor = System.Drawing.Color.Black;
                if(lstB[i].Text =="0")
                {
                    lstB[i].Text = "";
                   // lstB[i].ForeColor = System.Drawing.Color.Blue;
                }

            }
        }
        private int PointToIndex(int Row, int Col)
        {
            int index = 0;
            index = (Row * 8) + Col;
            return index;
        }
        private System.Drawing.Point IndexToPoint(int index)
        {
            System.Drawing.Point P = new System.Drawing.Point();
            int indexTemp = 63 - index;
            int iRow = indexTemp / 8;
            int iCol = (indexTemp % 8);
            P = new System.Drawing.Point(iCol, iRow);
            return P;
        }
        private void LoadPanel()
        {
            int i;
            lstB.Clear();

            this.Controls.Clear();
           

            for (i = 0; i <= 63; i++)
            {
                Button b = new Button();
                b.Height = buttonWidth;
                b.Width = buttonWidth;
                b.Text = "";
                b.Visible = true;
                b.Font = new System.Drawing.Font(this.Font.Name  , 13, System.Drawing.FontStyle.Bold);
                

                b.Click += btnSetValueClick;

                int iRow = i / 8;
                int iCol = (i % 8);
                b.Top = iRow * buttonWidth;
                b.Left = iCol * buttonWidth;
                b.Tag = 63- i;

                lstB.Add(b);
                lstBitValue.Add(0);

                this.Controls.Add(b);
            }
            this.Height = buttonWidth * 8;
            this.Width = buttonWidth * 8;

            // lvalue = ulong.MaxValue;
            UpdateLstBit();
            Display();
        }
    }
}
