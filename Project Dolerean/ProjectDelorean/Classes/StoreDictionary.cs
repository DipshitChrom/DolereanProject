using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Classes
{
    public class StoreDictionary
    {
        public Dictionary<int, List<HistoryTree>> previousdictionary;

        public void StoreDict(Dictionary<int, List<HistoryTree>> takedictionary)
        {
            previousdictionary = takedictionary;
        }

        public Dictionary<int, List<HistoryTree>> ReturnPreviousDictionary()
        {
            if (previousdictionary == null)
            {
                return new Dictionary<int, List<HistoryTree>>();
            }
            else
            {
                return previousdictionary;
            }
          

        }
    }
}
