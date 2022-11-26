using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi.UI
{
    public class Dialog
    {
        public static DialogResult ShowConfirm(String message)
        {

            FormCustomMessageBox f = new FormCustomMessageBox();
            f.Message = message;
            f.Caption = "Confirm";
            f.ShowCancel = true;
            f.StartPosition = FormStartPosition.CenterParent;
            return f.ShowDialog();

        }
        public static Form fParent = null;
        public static void ShowMessage(String message)
        {

            ShowMessage(message, fParent);

        }
        public static void  ShowMessage(String message,Form formParent)
        {
             FormCustomMessageBox f = new FormCustomMessageBox();
            f.Message = message;
            f.Caption = "Message";
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowCancel = false;
           
            if (formParent != null && formParent.Visible)
            {
                f.ShowDialog(formParent);
            } else
            {
                f.ShowDialog();
            }

        }

        public static void ShowErrorMessage(String message)
        {

            message += Environment.NewLine
                + "Please check the log at " + Utility.FileUtility.LogFilePath;
            ShowMessage(message);
        }
        public static String ChooseBotOpenPath()
        {
            OpenFileDialog Opf = new OpenFileDialog();
            Opf.InitialDirectory = Utility.FileUtility.BotPath;

            Opf.Filter = "Bot |*.bot";
            if (Opf.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Opf.FileName.Trim().Equals(String.Empty))
            {
                return "";
            }
            return Opf.FileName;
        }
        public static String ChooseBotSavePath(String defaultBotFileName)
        {
            SaveFileDialog Spf = new SaveFileDialog();

            Spf.InitialDirectory = Utility.FileUtility.BotPath;
            Spf.Filter = "Bot Files (*.bot)|*.bot";
            Spf.DefaultExt = "bot";
            Spf.FileName = defaultBotFileName + ".bot";

            if (Spf.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Spf.FileName.Trim().Equals(String.Empty))
            {
                return "";
            }
            return Spf.FileName;
        }
        public static String ChooseGameOpenPath()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Utility.FileUtility.GamePath ;
            openfile.Filter = "Reversi Game |*.rev";
            if (openfile.ShowDialog() != DialogResult.OK)
            {
                return "";
            }

            return openfile.FileName;

        }
        public static String ChooseGameSavePath(String defaultGameFileName)
        {
            SaveFileDialog Spf = new SaveFileDialog();

            Spf.InitialDirectory = Utility.FileUtility.GamePath;
            Spf.Filter = "Reversi Files (*.rev)|*.rev";
            Spf.DefaultExt = "rev";
            Spf.FileName = defaultGameFileName + ".rev";

            if (Spf.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Spf.FileName.Trim().Equals(String.Empty))
            {
                return "";
            }
            return Spf.FileName;
        }

        public static String ChooseBoardOpenPath()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = Utility.FileUtility.BoardPath;
            openfile.Filter = "Board |*.brd";
            if (openfile.ShowDialog() != DialogResult.OK)
            {
                return "";
            }

            return openfile.FileName;

        }
        public static String ChooseBoardSavePath()
        {
            SaveFileDialog Spf = new SaveFileDialog();
            Spf.Filter = "Board Files (*.brd)|*.brd";
            Spf.DefaultExt = "brd";
            Spf.InitialDirectory = Utility.FileUtility.BoardPath;

            if (Spf.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Spf.FileName.Trim().Equals(String.Empty))
            {
                return "";
            }
            return Spf.FileName;
        }
        public static String ChoosePhoto()
        {
            OpenFileDialog Opf = new OpenFileDialog();

            Opf.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (Opf.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            if (Opf.FileName.Trim().Equals(String.Empty))
            {
                return "";
            }
            return Opf.FileName;
        }
    }
}
