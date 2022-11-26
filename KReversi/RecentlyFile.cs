using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KReversi
{
    [Serializable]
    public class RecentlyFile
    {
        public List<String> ListRecentyFile { get; set; } = new List<string>();
        public int ListSize { get; private set; } = 4;
        public RecentlyFile (int listSize)
        {
            ListSize = listSize;
            Construct();
        }
        public RecentlyFile()
        {
            Construct();
        }
        private void Construct()
        {
            int i;
            
            for (i = 0; i < ListSize; i++)
            {
                ListRecentyFile.Add("");
            }

        }
        public void Clear()
        {
            int i = 0;
            for (i = 0; i < ListRecentyFile.Count ; i++)
            {
                ListRecentyFile[i] = "";
            }
        }
        public void InsertNewPath(String filePath)
        {
            int i;
            for (i = 0; i < ListRecentyFile.Count; i++)
            {
                Boolean IsAlreadyExistsinThelist = ListRecentyFile[i].Trim().Equals(filePath.Trim());
                if (IsAlreadyExistsinThelist)
                {
                    return;
                }
            }
          
            int indexBeforeLast = ListRecentyFile.Count - 2;
            for (i = indexBeforeLast ; i >=0; i--)
            {
                ListRecentyFile[i + 1] = ListRecentyFile[i];
            }
            ListRecentyFile[0] = filePath;
        }
    }
}
