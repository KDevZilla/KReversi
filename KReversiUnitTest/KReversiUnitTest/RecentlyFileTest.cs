using KReversi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversiUnitTest
{
    [TestClass]
    public class RecentlyFileTest
    {
        [TestMethod]
        public void TestConstruct()
        {
            RecentlyFile recentlyfile = new RecentlyFile(4);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            int i;
            for (i = 0; i < 4; i++)
            {
               Test.Assert(recentlyfile.ListRecentyFile[i] == "");
            }

        }


        // These files don't need to exist.
        String botElizaPath = @"D:\BotPath\Eliza.bot";
        String botLucyPath = @"D:\BotPath\Lucy.bot";
        String botFox = @"D:\BotPath\botFox.bot";
        String botJohn = @"D:\BotPath\botJohn.bot";
        String botSam = @"D:\BotPath\botSam.bot";

        [TestMethod]
        public void TestAdd()
        {
            RecentlyFile recentlyfile = new RecentlyFile(4);
            Trace.Assert(recentlyfile.ListRecentyFile.Count == 4);
          

            recentlyfile.InsertNewPath(botElizaPath);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botElizaPath);

            recentlyfile.InsertNewPath(botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile[1] == botElizaPath);

            recentlyfile.InsertNewPath(botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile[1] == botElizaPath);

            recentlyfile.InsertNewPath(botElizaPath);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile[1] == botElizaPath);

            recentlyfile.InsertNewPath(botFox);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botFox);
            Test.Assert(recentlyfile.ListRecentyFile[1] == botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile[2] == botElizaPath);


            recentlyfile.InsertNewPath(botJohn);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botJohn);
            Test.Assert(recentlyfile.ListRecentyFile[1] == botFox);
            Test.Assert(recentlyfile.ListRecentyFile[2] == botLucyPath);
            Test.Assert(recentlyfile.ListRecentyFile[3] == botElizaPath);


        }

        [TestMethod]
        public void TestClear()
        {
            RecentlyFile recentlyfile = new RecentlyFile(4);
            Trace.Assert(recentlyfile.ListRecentyFile.Count == 4);


            recentlyfile.InsertNewPath(botElizaPath);
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            Test.Assert(recentlyfile.ListRecentyFile[0] == botElizaPath);

            recentlyfile.Clear();
            int i;
            Test.Assert(recentlyfile.ListRecentyFile.Count == 4);
            for (i = 0; i < recentlyfile.ListRecentyFile.Count; i++)
            {
                Test.Assert(recentlyfile.ListRecentyFile[i] == "");
            }

            /*
            bot.InsertNewPath(botElizaPath);
            Test.Assert(bot.ListRecentyFile.Count == 4);
            Test.Assert(bot.ListRecentyFile[0] == botElizaPath);
            Test.Assert(bot.ListRecentyFile[1] == botJohn);
            Test.Assert(bot.ListRecentyFile[2] == botFox);
            Test.Assert(bot.ListRecentyFile[3] == botLucyPath);
            */

        }
    }
}
