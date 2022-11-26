using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi.Utility
{
    public class UI
    {
        public static void MakeSubMenuDark(System.Windows.Forms.ToolStripMenuItem m)
        {
            m.ForeColor = Color.White;
        }

        private static void T_MouseLeave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToolStripDropDownItem t = (ToolStripDropDownItem)sender;
           // t.BackColor = Color.Blue;
        }

        private static void T_MouseHover(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
          //  ToolStripDropDownItem t = (ToolStripDropDownItem)sender;
           // t.BackColor = Color.Blue;
        }

        private static void Menu_MouseLeave(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            var menu = (System.Windows.Forms.MenuStrip)sender;
            menu.ForeColor = Color.White;

        }

        private static void Menu_MouseEnter(object sender, EventArgs e)
        {
            var menu = (System.Windows.Forms.MenuStrip)sender;
            menu.ForeColor = Color.Black;

            //  throw new NotImplementedException();
        }

        private void ToolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
          //  ToolStripMenuItem1.ForeColor = Color.Orange;
        }

        private void ToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
           // ToolStripMenuItem1.ForeColor = Color.Black;
        }
        public static  void MakeComboBoxOwnerDrawBackColor(params ComboBox[] arrCbo)
        {
            foreach (ComboBox cbo in arrCbo)
            {
                cbo.DrawMode = DrawMode.OwnerDrawFixed;
                cbo.DrawItem -= Cbo_DrawItem;
                cbo.DrawItem += Cbo_DrawItem;
            }
        }
        //https://stackoverflow.com/questions/6468024/how-to-change-combobox-background-color-not-just-the-drop-down-list-part
        private static void Cbo_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            int index = e.Index >= 0 ? e.Index : 0;
            e.DrawBackground();
            using (Brush brush = new SolidBrush(cbo.ForeColor)) { 
            e.Graphics.DrawString(cbo.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }




        // DarkMode Title
        public static bool MakeFormCaptionToBeDarkMode(System.Windows.Forms.Form f, Boolean IsEnabled)
        {

            return UseImmersiveDarkMode(f.Handle, IsEnabled);
        }

        //https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;

            attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;

            int useImmersiveDarkMode = enabled ? 1 : 0;
            return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;

            /*
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
            */
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}
