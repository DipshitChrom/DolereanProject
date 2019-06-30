using ProjectDelorean.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDelorean.Classes
{
    public class History : IHistory
    {
        Dictionary<int, List<HistoryTree>> storedata = new Dictionary<int, List<HistoryTree>>();
        TempStoreExeceptionMessage displayexecptionmessage = new TempStoreExeceptionMessage();
        FileDataStore storeentry = new FileDataStore();

        public void InitaliseDict()
        {
            storedata = storeentry.InitializeDictionary();
        }

        public void CreateTimestamp(int identifer, long timestamp, string data)
        {
            InitaliseDict();
            if (storedata.ContainsKey(identifer))
            {
                displayexecptionmessage.HistoryAlreadyExists(identifer);
                Console.WriteLine(identifer + " " + storedata[identifer]);

            }

            else
            {
                HistoryTree userentry = new HistoryTree(timestamp, data);
                List<HistoryTree> histories = new List<HistoryTree>();
                storedata.Add(identifer, histories);
                Console.WriteLine("OK " + timestamp);
                storeentry.StoreDictionaryEntries(identifer, timestamp, data);

            }

        }
        public string UpdateTimestamp(int identifer, long timestamp, string data)
        {
            
            InitaliseDict();
            HistoryTree updateddata = new HistoryTree(timestamp, data);
            HistoryTree previousobservation;
            List<HistoryTree> updatelist = new List<HistoryTree>();
            if (storedata.ContainsKey(identifer))
            {

                previousobservation = storedata[identifer].Last();
                previousobservation.PrintTimestampAndData();
                updatelist.Add(updateddata);
                storedata[identifer] = updatelist;
                
                storeentry.StoreDictionaryEntries(identifer, timestamp, data);
                Console.WriteLine("OK " + identifer);
                return previousobservation.data;
            }
            else
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
                return null;
            }
        }


        public void DeleteTimestamp(int identifer)
        {

            if (storedata.ContainsKey(identifer))
            {
                storedata.Remove(identifer);
                //storeentry.StoreDictionaryEntries();
            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
            }
        }

        public void DeletewithIdentiferTimestamp(int identifer, long timestamp)
        {
            InitaliseDict();
            if (storedata.ContainsKey(identifer))
            {
                storedata.Remove(identifer);
                //storeentry.StoreDictionaryEntries();
            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
            }
        }

        public long GrabLatestTimestamp(int identifer)
        {
            long notimestamp = 0;
            InitaliseDict();
            HistoryTree latestvalue;
            if (storedata.ContainsKey(identifer))
            {
                //return timestamp;
                latestvalue = storedata[identifer].Last();
                latestvalue.PrintTimestampAndData();
                return latestvalue.timestamp;
            }
            else
            {
                displayexecptionmessage.NoHistoryForLatestTimestamp(identifer);
                return notimestamp;
            }
        }

        public string GetTimestamp(int identifer, long timestamp)
        {
            InitaliseDict();
            string iddata = null;


            if (storedata.ContainsKey(identifer))
            {
                //Console.WriteLine(storedata[identifer]);
                //return timestamp;
                foreach (HistoryTree item in storedata[identifer])
                {
                    if (timestamp == item.timestamp)
                    {
                        iddata = item.data;
                        item.PrintData();
                        return iddata;
                    }
                    
                }
            }
            else
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
            }

            return iddata;
        }

        //public Dictionary<int, HistoryTree> returnDictionary()
        //{
        //  Dictionary<int, HistoryTree> returnDict = storedata;
        //return returnDict;
        //}
    }
}
