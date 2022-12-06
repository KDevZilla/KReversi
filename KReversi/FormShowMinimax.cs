using KReversi.AI;
using KReversi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi
{
    public partial class FormShowMinimax : Form
    {
        public FormShowMinimax()
        {
            InitializeComponent();
        }
        UI.PictureBoxBoard pictureBoard = null;
        public AI.Board CurrentBoard { get; set; }
       

        private void SetUpBoardUI()
        {
            if (this.Controls.Contains(pictureBoard))
            {
                this.Controls.Remove(pictureBoard);
            }
            pictureBoard = new UI.PictureBoxBoard();
            pictureBoard.InitialEditBoard(CurrentBoard);

            pictureBoard.IsDrawCanPut = true;//By default EditMode will not show can put position
            pictureBoard.Top = 0;
            pictureBoard.Left = this.treeView1.Width + this.treeView1.Left + 5;
            pictureBoard.IsDrawNotion = this.chkUserReversiNotation.Checked;
            
            treeView1.AfterSelect -= TreeView1_AfterSelect;
            treeView1.AfterSelect += TreeView1_AfterSelect;
            this.Controls.Add(pictureBoard);

            treeView1.Nodes.Clear();
            TreeNode tn = treeView1.Nodes.Add("Root");
            if(Para.PositionScore.Score ==0 &&
                Para.IsMax &&
                Para.Alpha != 0)
            {
                Para.PositionScore.Score = Para.Alpha;
            }
            RenderTree(Para, tn );
            this.Width  = pictureBoard.Left + pictureBoard.Width + 20;
            this.btnClose.Left = this.Width - this.btnClose.Width - 20;

            this.Text ="No of nodes is " + this.iCountRenderTree.ToString();


        
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

           if(e.Node == null || e.Node.Tag ==null)
            {
                return;
            }

            BoardCompositScore boardComposit = (BoardCompositScore)e.Node.Tag;
            pictureBoard.InitialEditBoard(boardComposit.board);
            pictureBoard.listPositionScoreToShowMinimax = boardComposit.listPositionScore;

            pictureBoard.IsDrawCanPut = true;
            pictureBoard.Refresh();
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeNode Tn = (TreeNode)sender;
            if(Tn==null)
            {
                return;
            }
            if(Tn.Tag == null)
            {
                return;
            }
            BoardCompositScore boardComposit = (BoardCompositScore)Tn.Tag;
            pictureBoard.InitialEditBoard(boardComposit.board);
            pictureBoard.listPositionScoreToShowMinimax = boardComposit.listPositionScore;


        }

        private string GetString(MiniMaxParameterExtend Para, Boolean IsUsingOthelloNotation)
        {
            String MinMax = "Max";
            if (!Para.IsMax)
            {
                MinMax = "Min";
            }
            if(Para.child.Count == 0)
            {
                MinMax = "Leaf";
            }
            String Result = Para.PositionScore.Score + " [" +
              Para.PositionScore.Row + "," +
              Para.PositionScore.Col + "] " + MinMax;
            if (IsUsingOthelloNotation)
            {
                Result = Para.PositionScore.Score + " [" +
                       Utility.Utility.ConvertToReversiNotation(Para.PositionScore)
                       + "]" + MinMax ;
            }

            return Result;
        }
        int iCountRenderTree = 0;
        private void RenderTree(MiniMaxParameterExtend Para ,TreeNode tn)
        {
            int i;
            iCountRenderTree++;
            var treeNode = tn.Nodes.Add( GetString ( Para,chkUserReversiNotation.Checked));
            BoardCompositScore boardCompo = new BoardCompositScore((Board)Para.board);
            treeNode.Tag = boardCompo;

             
            for (i = 0; i < Para.child.Count; i++)
            {
                boardCompo.listPositionScore.Add(Para.child[i].PositionScore.ClonePositionScore());
                RenderTree(Para.child[i], treeNode);
              
            }
        }
        public MiniMaxParameterExtend Para { get; set; }
        private void Initial()
        {
            if(!System.IO.File.Exists (FileUtility.MiniMaxParameterForDebugFilePath))
            {
                UI.Dialog.ShowMessage("There is no file. Please look into Game->Configure menu to learn more detail how to use this function.");
                return;
            }

            Para = SerializeUtility.DeSerializeMiniMaxParameterExtend(FileUtility.MiniMaxParameterForDebugFilePath);
            this.CurrentBoard = (Board)Para.board;

            SetUpBoardUI();
        }
        private void FormShowMinimax_Load(object sender, EventArgs e)
        {
            try
            {
                Utility.UI.MakeFormCaptionToBeDarkMode(this, Global.CurrentTheme.IsFormCaptionDarkMode);
                //Global.SetButtonColor(this.btnClose);
                Utility.ThemeUtility themeUtil = new Utility.ThemeUtility(Global.CurrentTheme);
                themeUtil.SetButtonColor(this.btnClose)
                    .SetCheckboxColor (this.chkUserReversiNotation)
                    .SetTreeViewColor (this.treeView1)
                    .SetForm(this);


                this.Initial();
            }catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  this.Initial();

        }

        private void chkUserReversiNotation_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

           
            treeView1.Nodes.Clear();
            TreeNode tn = treeView1.Nodes.Add("Root");
            RenderTree(Para, tn);
            pictureBoard.IsDrawNotion = this.chkUserReversiNotation.Checked;
            pictureBoard.UpdateRender();

            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                UI.Dialog.ShowErrorMessage(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
