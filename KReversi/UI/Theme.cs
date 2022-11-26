using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace KReversi.UI
{
    public class Theme
    {
        public Color ButtonBackColor { get; set; }
        public Color ButtonForeColor { get; set; }
        public Color LabelForeColor { get; set; }
        public Color FormBackColor { get; set; }
        public Color InputBoxBackColor { get; set; }
        public Color LinkLabelForeColor { get; set; }
        public Color LinkLabelActiveForeColor { get; set; }
        public Boolean IsFormCaptionDarkMode { get; set; } = true;

        public Color MenuBackColor { get; set; }
        public Color MenuHoverBackColor { get; set; }
        public Color MenuForeColor { get; set; }

    }
}
