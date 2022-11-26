using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KReversi.Utility;
using System.IO;

namespace KReversi
{

    public class SimpleLog
    {
        //Please change it to be the real log framework such as log4Net
        public static void ClearLog()
        {
            try
            {

                System.IO.File.Delete(FileUtility.LogFilePath);
                
            }
            catch (Exception ex)
            {

            }
        }
        public static void WriteLog(Exception ex)
        {
            WriteLog(ex.ToString());
        }
        public static void WriteLog(string Message)
        {
            if(!Global.CurrentSettings.IsWriteLog)
            {
                return;
            }

            try
            {
                // return;
                using (StreamWriter SW = new StreamWriter(FileUtility.LogFilePath, true))
                {
                    Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss ") + Message;
                    SW.WriteLine(Message);
                }
               
            }
            catch (Exception ex)
            {

            }

        }

        public static void WriteDebugLog(string Message)
        {
            if (!Global.CurrentSettings.IsWriteDebugLog)
            {
                return;
            }

            try
            {
                // return;
                using (StreamWriter SW = new StreamWriter(FileUtility.LogFilePath, true))
                {
                    Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss ") + " [DEBUG] " + Message;
                    SW.WriteLine(Message);
                }

            }
            catch (Exception ex)
            {

            }

        }

        public static void WriteDebugLogL2(string Message)
        {
            if (!Global.CurrentSettings.IsWriteDebugLogL2)
            {
                return;
            }

            try
            {
                // return;
                using (StreamWriter SW = new StreamWriter(FileUtility.LogFilePath, true))
                {
                    Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss ") + " [DEBUGL2] " + Message;
                    SW.WriteLine(Message);
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}
