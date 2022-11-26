using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using KReversi.AI;
using KReversi.Game;

namespace KReversi.Utility
{
    public class SerializeUtility
    {

        public static void CreateNewRecentlyFile(String filename, int listFileSize)
        {
            RecentlyFile recentlyfile = new RecentlyFile(listFileSize);
            Serailze(recentlyfile, filename);
        }
        public static void SerializeRecentlyFile(RecentlyFile recentlyfile, String filename)
        {
            Serailze(recentlyfile, filename);
        }
        public static void CreateNewSettings(String filename)
        {
            KReversiSettings sta = new KReversiSettings();
            Serailze(sta, filename);
        }
        public static void SerializeSettings(KReversiSettings setting,String filename)
        {
            Serailze(setting, filename);
        }
        public static void SerializeMiniMaxBot(AI.MiniMaxBotProto sta, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(sta, filename);
        }

        public static void SerializeMiniMaxParameterExtend(MiniMaxParameterExtend Para, String filename)
        {
            //Create the stream to add object into it. 
            try
            {
                System.IO.File.Delete(filename);
            }
            catch (Exception ex)
            {
                SimpleLog.WriteLog(ex);
                
            }
            Serailze(Para, filename);
        }
        public static void SerializeBoardValue(AI.BoardValue  boardValue, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(boardValue, filename);
        }

        public static void SerializeGameValue(GameValue  gameValue, String filename)
        {
            //Create the stream to add object into it.  
            Serailze(gameValue, filename);
        }
        public static RecentlyFile DeserializeRecentlyFile(String filename)
        {
            object obj = Deserialize(filename);
            RecentlyFile recently = (RecentlyFile)obj;
            return recently;
        }
        public static KReversiSettings DeserializeSettings(String filename)
        {
            object obj = Deserialize(filename);
            KReversiSettings setting = (KReversiSettings)obj;
            return setting;
        }
        public static AI.MiniMaxBotProto DeserializeMinimaxBot(String filename)
        {
            object obj = Deserialize(filename);
            AI.MiniMaxBotProto bot = (AI.MiniMaxBotProto)obj;
            return bot;
        }

        public static AI.BoardValue DeserializeBoardValue(String filename)
        {
            object obj = Deserialize(filename);
            AI.BoardValue boardValue = (AI.BoardValue)obj;
            return boardValue;
        }

        public static GameValue DeserializeGameValue(String filename)
        {
            object obj = Deserialize(filename);
            GameValue gameValue = (GameValue)obj;
            return gameValue;
        }

        public static MiniMaxParameterExtend DeSerializeMiniMaxParameterExtend(String filename)
        {
            //Create the stream to add object into it.  
           
            object obj = Deserialize(filename);
            MiniMaxParameterExtend Para = (MiniMaxParameterExtend)obj;
            return Para;
        }
        private static void Serailze(object obj, String filename)
        {
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, obj);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        private static object Deserialize(String filename)
        {
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            // Statistics sta = (Statistics)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return obj;

        }
    }
}
