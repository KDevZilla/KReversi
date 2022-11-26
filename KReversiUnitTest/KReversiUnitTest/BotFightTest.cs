using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KReversi;
using KReversi.AI;
using System.Diagnostics;
using KReversi.Game;
namespace KReversiUnitTest
{
    [TestClass]
    public class BotFightTest
    {
        [TestMethod]
        public void Bot_Fight_RandomBotPlayWithRandomBot1000Times()
        {
            //KReversiGame game = CreateGame();
            IPlayer Bot1 = new RandomBot();
            IPlayer Bot2 = new RandomBot();
            int NumberofGame = 1000;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);





        }
        private void BotFightBot(IPlayer Bot1, IPlayer Bot2, int NumberofGame)
        {
            int i = 1;
            //int NoofLoopTest = 1000;
            int NoofBot1Won = 0;
            int NoofBot2Won = 0;
            int NoofDraw = 0;
            while (i <= NumberofGame)
            {
                KReversiGame game = GameBuilder.Builder.BeginBuild
                 .GameMode(KReversiGame.PlayerMode.FirstBot_SecondBot)
                 .BotPlayer1Is(Bot1)
                 .BotPlayer2Is(Bot2)
                 .FinishBuild();
                BoardUtil.SetUpBoardUI(game);
                game.Begin();
                int NoofBlackDisk = game.board.NumberofBlackDisk();
                int NoofWhieDisk = game.board.NumberofWhiteDisk();

                //Assert.aren
                Assert.AreEqual(game.GameState, KReversiGame.GameStatusEnum.Finished);
                Assert.AreNotEqual(game.GameResult, KReversiGame.GameResultEnum.NotDecideYet);

                Assert.IsTrue(NoofBlackDisk + NoofWhieDisk <= 64);
                Assert.IsTrue(NoofWhieDisk + NoofBlackDisk >= 10);
                /* Does not nessecially mean wrong if the sum of the disk of both color is < 10
                 * But it is very rate to happen
                 */

                if (game.GameResult == KReversiGame.GameResultEnum.BlackWon)
                {
                    NoofBot1Won++;
                    Assert.IsTrue(NoofBlackDisk > NoofWhieDisk);
                }
                else if (game.GameResult == KReversiGame.GameResultEnum.WhiteWon)
                {
                    NoofBot2Won++;
                    Assert.IsTrue(NoofBlackDisk < NoofWhieDisk);
                }
                else if (game.GameResult == KReversiGame.GameResultEnum.Draw)
                {
                    NoofDraw++;
                    Assert.IsTrue(NoofBlackDisk == NoofWhieDisk);
                }

                String BoardResult = game.board.ToString();
                Test.WriteLine(i.ToString());
                Test.WriteLine(Environment.NewLine + BoardResult);
                Test.WriteLine(" Result::" + game.GameResult);
                Test.WriteLine("  WhiteDisk::" + NoofWhieDisk);
                Test.WriteLine("  BlackDisk::" + NoofBlackDisk);

                Test.WriteLine("=========================");

                i++;
            }
            Test.WriteLine(" Finished testing ");
            Test.WriteLine(" No of Bot1 Won::" + NoofBot1Won);
            Test.WriteLine(" No of Bot2 Won::" + NoofBot2Won);
            Test.WriteLine(" No of Draw    ::" + NoofDraw);
            Test.WriteLine(" No of Game    ::" + NumberofGame);

            Assert.IsTrue(NoofBot1Won + NoofBot2Won + NoofDraw == NumberofGame);

        }
        [TestMethod]
        public void Bot_Fight_BasicBotPlayWithRandomBot1000Times()
        {
            IPlayer Bot1 = new BasicBot();
            IPlayer Bot2 = new RandomBot();
            int NumberofGame = 1000;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);

        }

        [TestMethod]
        public void Bot_Fight_BasicBotV2PlayWithRandomBot1000Times()
        {
            IPlayer Bot1 = new BasicBotV2();
            IPlayer Bot2 = new RandomBot();
            int NumberofGame = 1000;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);

        }

        [TestMethod]
        public void Bot_Fight_BasicBotV3PlayWithRandomBot1000Times()
        {
            IPlayer Bot1 = new BasicBotV3();
            IPlayer Bot2 = new RandomBot();
            int NumberofGame = 1000;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);
            Test.WriteLine("No of board in Brain::" + BasicBotV3.NoofBoardInBrain);
            Test.WriteLine("No time can read from Brain::" + BasicBotV3.NumberofTimeCanReadFromBrain);
        }
        [TestMethod]
        public void Bot_Fight_BasicBotV2PlayWithBasicBot1000Times()
        {
            IPlayer Bot1 = new BasicBotV2();
            IPlayer Bot2 = new BasicBot();
            int NumberofGame = 1000;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);

        }

        [TestMethod]
        public void Bot_Fight_MiniMaxBotPlayWithRandomBot()
        {
            //KReversiGame game = CreateGame();
            IPlayer Bot1 = MiniMaxBotProto.CreateBot();
            IPlayer Bot2 = new RandomBot();
            int NumberofGame = 5;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);





        }

        [TestMethod]
        public void Bot_Fight_MiniMaxBotPlayWithBasicBotV2()
        {
            //KReversiGame game = CreateGame();
            IPlayer Bot1 = MiniMaxBotProto.CreateBot();
            IPlayer Bot2 = new BasicBotV2();
            int NumberofGame = 5;
            BotFightBot(Bot1,
                Bot2,
                NumberofGame);





        }
    }
}
