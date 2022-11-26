using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi.UI
{

    public class MyRender : ToolStripProfessionalRenderer
    {
        private Color BackColor = Color.FromArgb(0, 0, 0);
        private Color HoverBackColor = Color.FromArgb(255, 255, 255);

        public MyRender (Color pBackColor, Color pHoverBackColor)
        {
            this.BackColor = pBackColor;
            this.HoverBackColor = pHoverBackColor;
        }
       
    }
    public class MenuCustomColor : ProfessionalColorTable
    {
        //a bunch of other overrides...

        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(0, 0, 0); }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientBegin
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientEnd
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return Color.FromArgb(64, 64, 64); }
        }


        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(64, 64, 64); }
        }
        /*
        public override Color MenuItemSelected
        {
            get { return Color.Red; }
        }
        */

        public override Color MenuBorder  //added for changing the menu border
        {
            get { return Color.Silver; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }



    }

    
}
