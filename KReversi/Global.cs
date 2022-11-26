using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace KReversi
{
    public class Global
    {


        public static string Player1AsHumanPhotoPath
        {
            get
            {
                return Utility.FileUtility.AppImagePath  + "Player1.png";
            }
        }
        public static string Player2AsHumanPhotoPath
        {
            get
            {
                return Utility.FileUtility.AppImagePath + "Player2.png";
            }
        }



        public static string Player1Base64 { get; set; }
        public static string Player2Base64 { get; set; }
        public static string Player1Name { get; set; } = "John";
        public static string Player2Name { get; set; } = "Mary";
        private static UI.Theme _LightTheme = null;
        public static UI.Theme LightTheme
        {
            get
            {
                if (_LightTheme == null)
                {
                    _LightTheme = new UI.Theme();
                    _LightTheme.ButtonBackColor = SystemColors.Control;
                    _LightTheme.ButtonForeColor = Color.Black;
                    _LightTheme.LabelForeColor = Color.Black;
                    _LightTheme.InputBoxBackColor = Color.WhiteSmoke  ;
                    _LightTheme.LinkLabelForeColor = Color.Black ;
                    _LightTheme.LinkLabelActiveForeColor = Color.Black  ;
                    _LightTheme.FormBackColor = Color.FromArgb(245, 245, 245); //Color.White;
                    _LightTheme.IsFormCaptionDarkMode = false;

                    _LightTheme.MenuBackColor = Color.FromArgb(253, 253, 253);
                    _LightTheme.MenuHoverBackColor = Color.FromArgb(181, 215, 243);
                    _LightTheme.MenuForeColor = Color.FromArgb(25, 25, 25);
    }
                return _LightTheme;
            }
        }

        private static UI.Theme _DarkTheme = null;
        public static UI.Theme DarkTheme
        {
            get
            {
                if(_DarkTheme == null)
                {
                    _DarkTheme = new UI.Theme();
                    _DarkTheme.ButtonBackColor = Color.FromArgb(44, 44, 44);
                    _DarkTheme.ButtonForeColor = Color.White;
                    _DarkTheme.LabelForeColor = Color.White;
                    _DarkTheme.InputBoxBackColor = Color.FromArgb(20, 20, 20);
                    _DarkTheme.LinkLabelForeColor = Color.White;
                    _DarkTheme.LinkLabelActiveForeColor = Color.FromArgb(220, 220, 220);
                    _DarkTheme.FormBackColor = Color.FromArgb(34, 34, 34);
                    _DarkTheme.IsFormCaptionDarkMode = true;

                    _DarkTheme.MenuBackColor = Color.FromArgb(36, 41, 46);
                    _DarkTheme.MenuHoverBackColor  = Color.FromArgb(70, 80, 80);
                    _DarkTheme.MenuForeColor = Color.White   ;
                }
                return _DarkTheme;
            }
        }


        public static UI.Theme CurrentTheme {
            get
            {
                
                if (CurrentSettings.IsDarkMode)
                {
                    return DarkTheme;
                }
                return LightTheme;
            }
        }

        private static int gameRecentlyFileSize { get; set; } = 6;
        private static RecentlyFile _GameRecentlyFile;
        public static RecentlyFile GameRecentlyFile
        {
            get
            {
                if(_GameRecentlyFile == null)
                {
                    if (!System.IO.File.Exists(Utility.FileUtility.GameRecentlyFile))
                    {
                        Utility.SerializeUtility.CreateNewRecentlyFile(Utility.FileUtility.GameRecentlyFile, gameRecentlyFileSize);
                    }
                    _GameRecentlyFile = Utility.SerializeUtility.DeserializeRecentlyFile(Utility.FileUtility.GameRecentlyFile);

                }
                return _GameRecentlyFile;
            }
        }


        private static int boardRecentlyFileSize { get; set; } = 6;
        private static RecentlyFile _BoardRecentlyFile;
        public static RecentlyFile BoardRecentlyFile
        {
            get
            {
                if (_BoardRecentlyFile == null)
                {
                    if (!System.IO.File.Exists(Utility.FileUtility.BoardRecentlyFile))
                    {
                        Utility.SerializeUtility.CreateNewRecentlyFile(Utility.FileUtility.BoardRecentlyFile, boardRecentlyFileSize);
                    }
                    _BoardRecentlyFile = Utility.SerializeUtility.DeserializeRecentlyFile(Utility.FileUtility.BoardRecentlyFile);

                }
                return _BoardRecentlyFile;
            }
        }

        private static int botRecentlyFileSize { get; set; } = 6;
        private static RecentlyFile _BotRecentlyFile;
        public static RecentlyFile BotRecentlyFile
        {
            get
            {
                if (_BotRecentlyFile == null)
                {
                    if (!System.IO.File.Exists(Utility.FileUtility.BotRecentlyFile))
                    {
                        Utility.SerializeUtility.CreateNewRecentlyFile(Utility.FileUtility.BotRecentlyFile, botRecentlyFileSize);
                    }
                    _BotRecentlyFile = Utility.SerializeUtility.DeserializeRecentlyFile(Utility.FileUtility.BotRecentlyFile);

                }
                return _BotRecentlyFile;
            }
        }
        public static void SaveGameRecentlyFile()
        {
            Utility.SerializeUtility.SerializeRecentlyFile(GameRecentlyFile, Utility.FileUtility.GameRecentlyFile);
        }
        public static void SaveBoardRecentlyFile()
        {
            Utility.SerializeUtility.SerializeRecentlyFile(BoardRecentlyFile, Utility.FileUtility.BoardRecentlyFile);
        }
        public static void SaveBotRecentlyFile()
        {
            Utility.SerializeUtility.SerializeRecentlyFile(BotRecentlyFile, Utility.FileUtility.BotRecentlyFile);
        }
        private static  KReversiSettings _CurrentSettings;
        public static  KReversiSettings CurrentSettings
        {
            get
            {
                
                if (_CurrentSettings == null)
                {
                    if (!System.IO.File.Exists(Utility.FileUtility.SettingsPath))
                    {
                        Utility.SerializeUtility.CreateNewSettings(Utility.FileUtility.SettingsPath);
                    }
                    _CurrentSettings = Utility.SerializeUtility.DeserializeSettings(Utility.FileUtility.SettingsPath);
                }
                return _CurrentSettings;
            }
        }
        public static  void SaveSettings()
        {
            Utility.SerializeUtility.SerializeSettings(_CurrentSettings, Utility.FileUtility.SettingsPath);
            _CurrentSettings = null;
        }
    }
}
