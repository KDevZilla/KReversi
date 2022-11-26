using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace KReversiUnitTest
{
    public class Test
    {
        // public static Boolean IsUsingDebug = true;
        public static AssertTypeEnum AssertType = AssertTypeEnum.Assert;
        public enum AssertTypeEnum
        {
            Debug,
            Trace,
            Assert
        }

        public static void Fail(String message)
        {
            Fail(message, "");
        }
        public static void Fail(String message, String detailmessage)
        {
            switch (AssertType)
            {
                case AssertTypeEnum.Assert:
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(detailmessage);
                    break;
                case AssertTypeEnum.Debug:
                    Debug.Fail(detailmessage);
                    break;
                case AssertTypeEnum.Trace:
                    Trace.Fail(detailmessage);
                    break;
            }
          
        }
        public static  void Assert(Boolean condition)
        {
            Assert(condition, "");

        }
        public static  void Assert(Boolean condition,String message)
        {
            switch (AssertType)
            {
                case AssertTypeEnum.Assert:
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(condition,message);
                    break;
                case AssertTypeEnum.Debug:
                    Debug.Assert(condition,message);
                    break;
                case AssertTypeEnum.Trace:
                    Trace.Assert(condition,message);
                    break;
            }
        }
        public static void Write(object message)
        {

                    Debug.Write (message);
               

        }

        public static void WriteLine(object message)
        {

                Debug.WriteLine(message);
                return;
           

        }


        public static void WriteLine(bool condition, object message)
        {


                Debug.WriteIf(condition, message);
                return;
        
        }

        public static void WriteLineIf(bool condition, object message)
        {


                Debug.WriteLineIf(condition, message);
                return;
          

        }
    }
   
}
