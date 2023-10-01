using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace KReversi.Utility
{
    public class FileUtility
    {

        public static string AppInfoPath => $@"{Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath)}\AppInfo";       
        public static string GetBotFileNameFromBotName(String botname) =>  $"{BotPath}{botname}.bot";
        public static string GetBotPhotoFileNameFromBotName(String botname) => $@"{BotImagesPath}{botname}.png";
        public static string AppImagePath=> AppInfoPath + @"\AppImages\";
        public static string SettingsPath => AppInfoPath + @"\Settings.bin";
        public static string TempPath => AppInfoPath + @"\Temp\";
        public static string BoardPath => AppInfoPath + @"\Boards\";
        public static string BotPath => AppInfoPath + @"\Bots\";
        public static string GamePath => AppInfoPath + @"\GamesSaved\";
        public static string BotImagesPath =>  AppInfoPath + @"\Bots\BotImages\";
        public static string GameSavedPath => AppInfoPath + @"\GamesSaved\";
        public static string LogFilePath => AppInfoPath + @"\Log.txt";
        public static string MiniMaxParameterForDebugFilePath => $@"{AppInfoPath}\MiniMaxForDebug.bin";
        public static string GameRecentlyFile => AppInfoPath + @"\RecentlyGame.bin";
        public static string BoardRecentlyFile => AppInfoPath + @"\RecentlyBoard.bin";
        public static string BotRecentlyFile => AppInfoPath + @"\RecentlyBot.bin";

        public static bool IsFileExist(String fileName) => System.IO.File.Exists(fileName);
        public static  List<String> GetAllBoardName()=> GetAllBoardName(BoardPath);
        public static void OpenFolder(String folder)=> Process.Start(folder);
        public static void CopyFileIfItIsDifferentPath(String original, String destination)
        {
            Boolean NeedtoCopy = true;
            if (original.Trim().ToLower() ==
            destination.Trim().ToLower())
            {
                NeedtoCopy = false;
            }
            if (NeedtoCopy)
            {
                System.IO.File.Copy(original, destination, true);
            }
        }
        public static  List<String> GetAllBoardName(String Path)
        {
            List<string> list = new List<string>();
            string[] arrFiles= System.IO.Directory.GetFiles(Path, "*.brd");
            int i;
            for (i = 0; i < arrFiles.Length; i++)
            {
                list.Add( System.IO.Path.GetFileName ( arrFiles[i]).Replace (".brd",""));
            }
            return list;
        }

        public static Image ReadImageWithoutLockFile(String fileName)
        {
            Image img;
            using (var bmpTemp = new Bitmap(fileName))
            {
                img = new Bitmap(bmpTemp);
            }
            return img;
        }

        //https://stackoverflow.com/questions/21325661/convert-an-image-selected-by-path-to-base64-string
        public static String  GetBase64FromImageFile(String fileName)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(fileName);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
        public static Image GetImageFromBase64(string Base64)
        {
            if (String.IsNullOrEmpty(Base64))
            {
                return null;
            }

            try
            {
                var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(Base64)));
                return img;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

    }
}
