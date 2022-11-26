using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KReversi.UI;

namespace KReversi.Utility
{
    public class ThemeUtility
    {
        public KReversi.UI.Theme CurrentTheme = null;
        public ThemeUtility(KReversi.UI.Theme ptheme)
        {
            CurrentTheme = ptheme;
        }

        public ThemeUtility SetAllofControlInForm(Control c)
        {

                if(c is TextBox)
                {
                    SetTextBoxColor((TextBox)c);

                }
                if(c is Button)
                {
                    SetButtonColor((Button)c);

                }
                if (c is Label)
                {
                    SetLabelColor((Label)c);

                }
                if(c is ComboBox)
                {
                    SetComboboxColor((ComboBox)c);

                }
                if(c is CheckBox)
                {
                    SetCheckboxColor((CheckBox)c);

                }
                if(c is NumericUpDown)
                {
                    SetNumericUpDownColor((NumericUpDown)c);

                }
                if(c is GroupBox)
                {
                    SetGroupboxColor((GroupBox)c);

                }
                if(c is TabControl)
                {
                    //SetTabControl((TabControl)c);
                    foreach (Control child in c.Controls)
                    {
                        SetAllofControlInForm(child);
                    }

                }
                if(c is TabPage)
                {
                    SetTabPages((TabPage)c);
                    foreach (Control child in c.Controls)
                    {
                        SetAllofControlInForm(child);
                    }
                }
                if(c is Form)
                {
                    SetForm((Form)c);
                    foreach (Control child in c.Controls)
                    {
                        SetAllofControlInForm(child);
                    }

                }

            //SetForm(f);
            return this;
        }
        public   ThemeUtility SetLabelColor(KReversi.UI.Theme theme, params Label[] arrLabel)
        {
            foreach (Label label in arrLabel)
            {
                label.ForeColor = theme.LabelForeColor;
            }
            return this;
        }
        public ThemeUtility SetLabelColor(params Label[] arrLabel)
        {

            SetLabelColor(CurrentTheme, arrLabel);
            return this;
        }



        public ThemeUtility SetNumericUpDownColor(params NumericUpDown[] arrNumeric)
        {
            SetNumericUpDownColor(CurrentTheme, arrNumeric);
            return this;
        }

        public ThemeUtility SetNumericUpDownColor(KReversi.UI.Theme theme, NumericUpDown[] arrNumeric)
        {
            foreach (NumericUpDown num in arrNumeric)
            {
                num.ForeColor = theme.LabelForeColor;
                num.BackColor = theme.InputBoxBackColor;


            }
            return this;
        }
        public ThemeUtility SetTextBoxColor(params TextBox[] arrtextbox)
        {
            SetTextBoxColor(CurrentTheme, arrtextbox);
            return this;
        }

        public ThemeUtility SetTextBoxColor(KReversi.UI.Theme theme, TextBox[] arrtextbox)
        {
            foreach (TextBox text in arrtextbox)
            {
                text.ForeColor = theme.LabelForeColor;
                text.BackColor = theme.InputBoxBackColor;


            }
            return this;
        }
        public ThemeUtility SetMenu(System.Windows.Forms.MenuStrip menu )
        {
            // Not implement yet in this version
            // This method can support Black menu
            // But it might crate some flicke
            return this;


                
                menu.RenderMode = ToolStripRenderMode.Professional  ;
              
               
                menu.Renderer = new KReversi.UI.MyRender(CurrentTheme.MenuBackColor,
                     CurrentTheme.MenuHoverBackColor);
                     
               // menu.Font = new Font(menu.Font.Name, 10, FontStyle.Regular);
                menu.ForeColor = CurrentTheme.MenuForeColor;
                menu.BackColor = CurrentTheme.MenuBackColor ;

             
                foreach (System.Windows.Forms.ToolStripMenuItem c in menu.Items)
                {
                    if (c is ToolStripMenuItem)
                    {
                        // ToolStripMenuItem tool = (ToolStripMenuItem)c;
                        foreach (var item in c.DropDownItems)
                        {
                            if (item is ToolStripDropDownItem)
                            {
                                ToolStripDropDownItem t = (ToolStripDropDownItem)item;

                                t.ForeColor =CurrentTheme.MenuForeColor;
                                t.BackColor = CurrentTheme.MenuBackColor;
                            }
                            else
                            {
                                if (item is System.Windows.Forms.ToolStripSeparator)
                                {
                                    System.Windows.Forms.ToolStripSeparator t = (System.Windows.Forms.ToolStripSeparator)item;
                                    t.ForeColor = CurrentTheme.MenuForeColor;
                              //  t.BackColor =System.Drawing.Color.Red  ;// CurrentTheme.MenuBackColor;
                              //       t.Paint += T_Paint;
                                   
                                }


                            }
                        }

                    }
                }
            return this;
        }

        private void T_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        public ThemeUtility SetForm(Form f)
        {
            SetForm(CurrentTheme, f);
            return this;
        }


        public ThemeUtility SetForm(KReversi.UI.Theme theme, Form f)
        {
            f.BackColor = theme.FormBackColor;
            return this;
        }




        public ThemeUtility SetTabControl(TabControl t)
        {
           foreach (TabPage tp in t.TabPages)
            {
                SetTabPages(tp);
            }
            return this;
        }
        public ThemeUtility SetTabPages(TabPage tp)
        {
            //SetForm(CurrentTheme, f);
            tp.BackColor = CurrentTheme.FormBackColor;
            return this;
        }

        public ThemeUtility SetTabPages(params TabPage[] arrtp)
        {
            foreach (TabPage tp in arrtp)
            {
                SetTabPages(tp);
            }
            return this;
        }
        public ThemeUtility SetComboboxColor(params ComboBox[] arrCombobox)
        {
            SetComboboxColor(CurrentTheme, arrCombobox);
            return this;
        }

        public ThemeUtility SetComboboxColor(KReversi.UI.Theme theme, ComboBox[] arrCombobox)
        {
            foreach (ComboBox cbo in arrCombobox)
            {
                cbo.ForeColor = theme.LabelForeColor;
                cbo.BackColor = theme.InputBoxBackColor;



            }
            return this;
        }

        public ThemeUtility SetGroupboxColor(params GroupBox[] arrGrpbox)
        {
            SetGroupboxColor(CurrentTheme, arrGrpbox);
            return this;
        }

        public ThemeUtility SetGroupboxColor(KReversi.UI.Theme theme, params GroupBox[] arrGrpbox)
        {
            foreach (GroupBox grp in arrGrpbox)
            {
                grp.ForeColor = theme.LabelForeColor;
                grp.BackColor = theme.InputBoxBackColor;



            }
            return this;
        }
        public ThemeUtility SetCheckboxColor(params CheckBox[] arrCheckbox)
        {
            SetCheckboxColor(CurrentTheme, arrCheckbox);
            return this;
        }
        public ThemeUtility SetTreeViewColor(TreeView treeview)
        {
            //SetCheckboxColor(CurrentTheme, arrCheckbox);
            treeview.BackColor = CurrentTheme.InputBoxBackColor;
            treeview.ForeColor = CurrentTheme.LabelForeColor;

            return this;
        }
        public ThemeUtility SetCheckboxColor(KReversi.UI.Theme theme, CheckBox[] arrCheckbox)
        {
            foreach (CheckBox chk in arrCheckbox)
            {
                chk.ForeColor = theme.LabelForeColor;
                //  chk.BackColor = theme.InputBoxBackColor;
            }
            return this;
        }
        public ThemeUtility SetButtonColor(KReversi.UI.Theme theme, params Button[] arrButton)
        {
            foreach (Button button in arrButton)
            {
                button.ForeColor = theme.ButtonForeColor;
                button.BackColor = theme.ButtonBackColor;
            }
            return this;
        }
        public ThemeUtility SetButtonColor(params Button[] arrButton)
        {
            SetButtonColor(CurrentTheme, arrButton);
            return this;
        }
    }
}
