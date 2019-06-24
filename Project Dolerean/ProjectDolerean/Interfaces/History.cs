using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public class History : IHistory
    {
        Dictionary<int, HistoryTree> storedata = new Dictionary<int, HistoryTree>();
        TempStoreExeceptionMessage displayexecptionmessage = new TempStoreExeceptionMessage();


        public void CreateTimestamp(int identifer, long timestamp, string data)
        {
            if (storedata.ContainsKey(identifer))
            {
                displayexecptionmessage.HistoryAlreadyExists(identifer);
                Console.WriteLine(identifer + " " + storedata[identifer]);

            }
            
            else
            {
                HistoryTree userentry = new HistoryTree(timestamp, data);
                storedata.Add(identifer, userentry);
                Console.WriteLine("OK " + identifer + " " + timestamp + " " + data);

            }
           
        }
        public void UpdateTimestamp(int identifer, long timestamp, string data)
        {
     
            HistoryTree updateddata = new HistoryTree(timestamp, data);
            if (storedata.ContainsKey(identifer))
            {
                storedata[identifer] = updateddata;
            }
            else 
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
            }
        }

       public void DeleteTimestamp(int identifer)
        {
            
            if (storedata.ContainsKey(identifer))
            {
                storedata.Remove(identifer);
            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
            }
        }

        public void DeletewithIdentiferTimestamp(int identifer, long timestamp)
        {
            
            if (storedata.ContainsKey(identifer))
            {
                storedata.Remove(identifer);
            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
            }
        }

        public void GrabLatestTimestamp(int identifer)
        {
            if (storedata.ContainsKey(identifer))
            {
                //return timestamp;
            }
            else
            {
                Console.WriteLine("ERR No timestamp for this identifer exists");
              
            }
        }

        public void GetTimestamp(int identifer, long timestamp)
        {
            if (storedata.ContainsKey(identifer))
            {
                Console.WriteLine(storedata[identifer]);
                //return timestamp;
            }
            else
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
            } 
        }

        public Dictionary<int, HistoryTree> returnDictionary()
        {
            Dictionary<int, HistoryTree> returnDict = storedata;
            return returnDict;
        }
    }
}
