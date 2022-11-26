using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.Game;
namespace KReversi.UI
{
    public class PictureBoxBoard : PictureBox
    {

        public enum CellImageEnum
        {
            WhiteCell,
            BlackCell,
            BlankCell,
            BlankCellWithRed
        }
        public enum BoardModeEnum
        {
            PlayMode,
            EditMode
        }
        const int Black = -1;
        const int Blank = 0;
        const int White = 1;
        public BoardModeEnum BoardMode { get; set; } = BoardModeEnum.PlayMode;

        private Dictionary<int, CellImageEnum> _DicDiskValueCellImage;
        private Dictionary<int, CellImageEnum> DicDiskValueCellImage
        {
            get
            {
                if (_DicDiskValueCellImage == null)
                {
                    _DicDiskValueCellImage = new Dictionary<int, CellImageEnum>();
                    _DicDiskValueCellImage.Add(Black, CellImageEnum.BlackCell);
                    _DicDiskValueCellImage.Add(Blank, CellImageEnum.BlankCell);
                    _DicDiskValueCellImage.Add(White, CellImageEnum.WhiteCell);
                }
                return _DicDiskValueCellImage;

            }
        }
        private PictureBox pictureBoxTable = null;
        private Label lblMaster = null;
        public int BoardLegendSize { get; set; } = 40;
        public Boolean IsRenderLegend { get; set; } = true;
        public int CellSize { get; set; } = 60;
        public float FontSize { get; set; } = 20.25F;
        private int IntersectionSize { get; set; } = 10;
        public Boolean IsSmallBoard { get; set; } = false;
        public Boolean IsHideLegent { get; set; } = false;
        public Boolean IsDrawNotion { get; set; } = true;
        int NoofRow = 8;
        KReversiGame game = null;
        AI.Board editModeBoard = null;


        private Color AccentColor = Color.Black; // Color.FromArgb (188,176,149)  ;//Color.FromArgb(35, 35, 35)
        private Color BoardColor = Color.FromArgb(255, 0, 144, 103); //Color.FromArgb(125, 124, 122);// Color.FromArgb(4, 41, 58); //
        private Color BoardBorderColor = Color.Black; // Color.FromArgb (36,61,88); //Color.FromArgb(165,202,202); //Color.FromArgb (150,150,150);//Color.FromArgb(4, 41, 58);
        private Color DiskBorderColor = Color.Black;
        private Pen _PenColor = null;
        private Pen PenBorder
        {
            get
            {
                if (_PenColor == null)
                {
                    _PenColor = new Pen(BoardBorderColor);
                }
                return _PenColor;
            }
        }
        private Brush _AccentBrush = null;
        private Brush AccentBrush
        {
            get
            {
                if (_AccentBrush == null)
                {
                    _AccentBrush = new SolidBrush(AccentColor);
                }
                return _AccentBrush;
            }
        }

        private Brush _BorderBrush = null;
        private Brush BorderBrush
        {
            get
            {
                if (_BorderBrush == null)
                {
                    _BorderBrush = new SolidBrush(BoardBorderColor);
                }
                return _BorderBrush;
            }
        }
        public List<PositionScore> listPositionScoreToShowMinimax { get; set; } = null;
        private AI.Board board
        {
            get
            {
                if (this.BoardMode == BoardModeEnum.PlayMode)
                {
                    return game.board;
                }
                return editModeBoard;
            }
        }
        private Rectangle[] _arrRecIntersection = null;
        private Rectangle[] arrRecIntersection
        {
            get
            {
                if (_arrRecIntersection == null)
                {
                    Size InterSecSize = new Size(IntersectionSize, IntersectionSize);
                    List<Point> listCellPosition = new List<Point>();
                    listCellPosition.Add(new Point(2, 2));
                    listCellPosition.Add(new Point(6, 2));
                    listCellPosition.Add(new Point(2, 6));
                    listCellPosition.Add(new Point(6, 6));
                    int i;
                    _arrRecIntersection = new Rectangle[listCellPosition.Count];
                    for (i = 0; i < listCellPosition.Count; i++)
                    {
                        Point PointDraw = new Point(CellSize * listCellPosition[i].X - (InterSecSize.Width / 2), CellSize * listCellPosition[i].Y - (InterSecSize.Width / 2));
                        Rectangle r = new Rectangle(PointDraw, InterSecSize);
                        _arrRecIntersection[i] = r;
                    }

                }
                return _arrRecIntersection;
            }
        }
        private Rectangle[] _arrRac = null;
        private Rectangle[] arrRac
        {
            get
            {
                if (_arrRac == null)
                {
                    int i, j;
                    _arrRac = new Rectangle[NoofRow * NoofRow];
                    for (i = 0; i < NoofRow; i++)
                    {
                        for (j = 0; j < NoofRow; j++)
                        {
                            int IndexArrRec = (i * NoofRow) + j;
                            _arrRac[IndexArrRec] = new Rectangle(CellSize * j, CellSize * i, CellSize, CellSize);
                        }
                    }
                }
                return _arrRac;
            }

        }
        public Boolean IsDrawCanPut { get; set; } = true;
        public void InitialEditBoard(AI.Board EditModeBoard)
        {

            IsDrawCanPut = false;
            if (IsSmallBoard)
            {

                this.CellSize = 40;
                this.BoardLegendSize = 30;
                this.FontSize = 15f;
                IntersectionSize = 7;

            }

            if (IsHideLegent)
            {
                this.BoardLegendSize = 0;
            }
            this.BoardMode = BoardModeEnum.EditMode;
            this.editModeBoard = EditModeBoard;

            this.CellClick -= PictureBoxBoard_CellClick;
            this.CellClick += PictureBoxBoard_CellClick;
            Initial();
        }
        public void InitialGame(KReversiGame pGame)
        {
            this.BoardMode = BoardModeEnum.PlayMode;
            this.game = pGame;
            Initial();
        }

        Boolean IsAcceptUserInput = true;

        private void Initial()
        {

            this.pictureBoxTable = new PictureBox();


            this.pictureBoxTable.Width = (CellSize * 8) + 1;
            this.pictureBoxTable.Height = (CellSize * 8) + 1;
            this.pictureBoxTable.Top = BoardLegendSize;
            this.pictureBoxTable.Left = BoardLegendSize;
            this.pictureBoxTable.Visible = true;
            this.pictureBoxTable.MouseDown += PictureBox1_MouseDown;
            this.pictureBoxTable.Paint += pictureBoxTable_Paint;


            this.BackColor = BoardColor; //Color.FromArgb(255, 0, 144, 103);
            this.Height = pictureBoxTable.Top + pictureBoxTable.Height + BoardLegendSize + 2;
            this.Width = pictureBoxTable.Left + pictureBoxTable.Width + BoardLegendSize + 2;
            this.Paint += PictureBoxBoard_Paint;
            this.BorderStyle = BorderStyle.FixedSingle;


            if (this.lblMaster == null)
            {
                this.lblMaster = new Label();
                this.lblMaster.BackColor = System.Drawing.Color.White;
                this.lblMaster.Font = new System.Drawing.Font("Segoe UI", this.FontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblMaster.ForeColor = System.Drawing.Color.Black;
                this.lblMaster.Location = new System.Drawing.Point(832, 9);
                this.lblMaster.Name = "lblMaster";
                this.lblMaster.Size = new System.Drawing.Size(CellSize, CellSize);
                this.lblMaster.TabIndex = 9;
                this.lblMaster.Text = "1";
                this.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.lblMaster.Visible = false;
                // this.lblMaster.Font = new Font(this.lblMaster.Font.Name, this.FontSize);


            }
            if (IsRenderLegend)
            {
                this.Controls.Add(this.pictureBoxTable);
            }


        }
        public int SelectedCellTypeEditMode { get; set; } = Blank;

        private void PictureBoxBoard_CellClick(object sender, Position position)
        {
            if (!IsAcceptUserInput)
            {
                return;
            }

            if (BoardMode == BoardModeEnum.PlayMode)
            {
                /*In PlayerMode, this control will not handler any
                 * logic in this method, it will just let game object handle the board value
                 */
                return;
            }


            //If you reach at this point it mean BoardMode is Custom
            board.boardMatrix[position.Row, position.Col] = SelectedCellTypeEditMode;
            this.pictureBoxTable.Invalidate();
            this.pictureBoxTable.Update();


        }
        public void UpdateRender()
        {
            this.pictureBoxTable.Invalidate();
            this.pictureBoxTable.Update();
        }
        private void pictureBoxTable_Paint(object sender, PaintEventArgs e)
        {
            int i;
            int j;
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            DrawBoard(g, arrRac);
            DrawIntersection(g, arrRecIntersection);

            for (i = 0; i < arrRac.Length; i++)
            {
                Position Diskposition = Utility.Utility.From1DimensionTo2(i, this.NoofRow);
                DrawDisk(g, board.CellsByPostion(Diskposition), arrRac[i]);

            }

            if (board.LastPutPosition != null)
            {
                DrawRedDot(g, arrRac[Utility.Utility.From2DimensionTo1(board.LastPutPosition, this.NoofRow)]);
            }

            if (IsDrawCanPut)
            {
                List<Position> listCanPut = board.generateMoves();
                foreach (Position position in listCanPut)
                {
                    int indexRec = Utility.Utility.From2DimensionTo1(position, this.NoofRow);
                    DrawDiskBorder(g, arrRac[indexRec]);

                }
                if (this.listPositionScoreToShowMinimax != null)
                {
                    foreach (PositionScore positionscore in this.listPositionScoreToShowMinimax)
                    {
                        int indexRec = Utility.Utility.From2DimensionTo1(positionscore.Row,
                            positionscore.Col, this.NoofRow);
                        DrawNumber(g, positionscore.Score, arrRac[indexRec]);
                    }
                }
            }
        }
        private void DrawRedDot(Graphics g, Rectangle rec)
        {
            using (Brush brushRedDot = new SolidBrush(Color.Red))
            {
                rec.Height -= 50;
                rec.Width -= 50;
                rec.X += 25;
                rec.Y += 25;

                g.FillEllipse(brushRedDot, rec);
                return;
            }
        }
        private void DrawIntersection(Graphics g, Rectangle[] arrRacInterSec)
        {
            int i;
            for (i = 0; i < arrRacInterSec.Length; i++)
            {
                g.FillEllipse(BorderBrush, arrRacInterSec[i]);
            }

        }
        private Boolean IsValidPosition(Position position, int DiskValue)
        {
            return false;
        }
        public delegate void PictureBoxCellClick(object sender, Position position);
        public event PictureBoxCellClick CellClick;
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            int X = e.X;
            int Y = e.Y;
            int RowClick = Y / CellSize;
            int ColClick = X / CellSize;
            if (RowClick >= NoofRow ||
                ColClick >= NoofRow ||
                RowClick < 0 ||
                ColClick < 0)
            {
                return;
            }

            if (CellClick != null)
            {
                CellClick(this, new Position(RowClick, ColClick));
            }

        }


        private void PictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {

            int i = 0;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            for (i = 0; i < NoofRow; i++)
            {

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                String RowValue = i.ToString();
                String ColumnValue = i.ToString();
                int iValue = i + 1;// NoofRow  - i;
                if (IsDrawNotion)
                {
                    RowValue = (i + 1).ToString();
                    int unicode = 65 + i;
                    char character = (char)unicode;
                    ColumnValue = character.ToString();
                }



                e.Graphics.DrawString(ColumnValue,
                lblMaster.Font,
                AccentBrush,
                new Point((CellSize * i) + (CellSize / 2) + BoardLegendSize, 0), format);

                e.Graphics.DrawString(RowValue,
                    lblMaster.Font,
                    AccentBrush,
                    new Point(10, (CellSize * i) + CellSize - 10));

            }
        }

        private void DrawNumber(Graphics g, int Number, Rectangle rec)
        {

            Rectangle r = rec;
            r.Height -= 10;
            r.Width -= 10;
            r.X += 10;
            r.Y += 15;

            Font SegoeUIFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Color NumberColor = Color.FromArgb(150, 180, 180);
            String NumberText = "+" + Number;
            if (Number < 0)
            {
                NumberText = Number.ToString();
                NumberColor = Color.FromArgb(255, 199, 79);
            }
            //Create Brush and other objects
            PointF pointF = new PointF(r.X, r.Y);
            SolidBrush solidBrush =
                new SolidBrush(NumberColor);
            //Draw text using DrawString
            g.DrawString(NumberText,
                SegoeUIFont,
                solidBrush, pointF);

            solidBrush.Dispose();

        }
        private void DrawDisk(Graphics g, AI.Board.CellValue CellValue, Rectangle rec)
        {
            DrawDisk(g, (int)CellValue, rec);
        }
        private void DrawDisk(Graphics g, int CellValue, Rectangle rec)
        {
            DrawDisk(g, DicDiskValueCellImage[CellValue], rec);
        }

        private void DrawDisk(Graphics g, CellImageEnum CellImage, Rectangle rec)
        {
            if (CellImage == CellImageEnum.BlankCell)
            {
                return;
            }

            Rectangle r = rec;
            r.Height -= 10;
            r.Width -= 10;
            r.X += 5;
            r.Y += 5;
            DrawDiskBorder(g, r);

            Color colorDisk = Color.White;
            if (CellImage != CellImageEnum.WhiteCell)
            {
                colorDisk = Color.Black;
            }

            using (Brush brushDisk = new SolidBrush(colorDisk))
            {
                g.FillEllipse(brushDisk, r);
            }


            Color diskBorderColor = Color.Black;

            //Uncomment this line in case you would like white disk to have white color border
            //diskBorderColor = colorDisk
            using (Pen penDisk = new Pen(new SolidBrush(diskBorderColor)))
            {
                g.DrawEllipse(penDisk, r);
            }

        }
        private void DrawDiskBorder(Graphics g, Rectangle rec)
        {

            Rectangle r = rec;
            r.Height -= 10;
            r.Width -= 10;
            r.X += 5;
            r.Y += 5;
            using (Pen penDisk = new Pen(DiskBorderColor))
            {
                g.DrawEllipse(penDisk, r);
            }
        }
        private void DrawBoard(Graphics g, Rectangle[] arrRac)
        {

            g.Clear(BoardColor);
            g.DrawRectangles(PenBorder, arrRac);
            Rectangle rectangleBorder = new Rectangle(0, 0, CellSize * 8, CellSize * 8);
            using (Pen penBigBorder = new Pen(Color.Black, 4))
            {
                g.DrawRectangle(penBigBorder, rectangleBorder);
            }
        }


    }
}
