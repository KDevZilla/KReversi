using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KReversi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            
            Exception e = (Exception)args.ExceptionObject;
            

            SimpleLog.WriteLog(e);
            String Message = "If you see this message it means there is an unhandle exception occurred";
            UI.Dialog.ShowErrorMessage(Message);

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.ThreadException += Application_ThreadException;

             Application.Run(new FormGame());
            //Application.Run(new FormTestDynamicMenu());


        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // throw new NotImplementedException();
         //   Exception e2 = (Exception)e.


            SimpleLog.WriteLog(e.Exception);
            String Message = "If you see this message it means there is an unhandle exception occurred";
            UI.Dialog.ShowErrorMessage(Message);
        }
    }
}
