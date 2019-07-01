using ProjectDelorean.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDelorean.Classes
{
    public class History : IHistory
    {
        Dictionary<int, List<HistoryTree>> storedata;
        TempStoreExeceptionMessage displayexecptionmessage = new TempStoreExeceptionMessage();
        StoreDictionary mydictionarystore = new StoreDictionary();
     
        public History(Dictionary<int, List<HistoryTree>> temporalstore)
        {
            storedata = temporalstore;
        }

        public string CreateTimestamp(int identifer, long timestamp, string data)
        {
          
            if (storedata.ContainsKey(identifer))
            {
                displayexecptionmessage.HistoryAlreadyExists(identifer);
                Console.WriteLine(identifer + " " + storedata[identifer]);
                return null;
            }

            else
            {
                HistoryTree userentry = new HistoryTree(timestamp, data);
                List<HistoryTree> histories = new List<HistoryTree>();
                histories.Add(userentry);
                storedata.Add(identifer, histories);
                Console.WriteLine("OK " + data);
                
                

                return data;

            }

        }
        public string UpdateTimestamp(int identifer, long timestamp, string data)
        {
            
            //InitaliseDict();
            HistoryTree updateddata = new HistoryTree(timestamp, data);
            HistoryTree previousobservation;
            
            if (storedata.ContainsKey(identifer))
            {
                List<HistoryTree> updatelist = storedata[identifer];
                previousobservation = storedata[identifer].Last();
                //previousobservation.PrintTimestampAndData();
                updatelist.Add(updateddata);
                previousobservation.PrintData();
                storedata[identifer] = updatelist;
                
                return previousobservation.data;

            }
            else
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
                return null;
            }
        }


        public string DeleteTimestamp(int identifer)
        {
            HistoryTree lastentry;
            if (storedata.ContainsKey(identifer))
            {
                lastentry = storedata[identifer].Last();
                lastentry.PrintData();
                storedata.Remove(identifer);
                return lastentry.data;
            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
                return null;
            }
        }

        public void DeletewithIdentiferTimestamp(int identifer, long timestamp)
        {
            //var minimumtimestamp = x.Min(entry => entry.Value);

            HistoryTree lastentry;
            List<HistoryTree> updatehistory;
          
            if (storedata.ContainsKey(identifer))
            {
                //List<HistoryTree> updatedeletedtimestamp;
                updatehistory = storedata[identifer];

                var closest = updatehistory.Select(n => new { n, timestamp = Math.Abs(n.timestamp - timestamp) })
                    .OrderBy(n => n.timestamp)
                    .First().n.timestamp;

                updatehistory.RemoveAll(n => n.timestamp >= closest);



                storedata[identifer] = updatehistory;


            }
            else
            {
                displayexecptionmessage.DeletingNotExistingTimestamp(identifer);
            }
        }

        public long GrabLatestTimestamp(int identifer)
        {
            long notimestamp = 0;
            //InitaliseDict();
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
            //InitaliseDict();
            HistoryTree returntimestamp;
            List <HistoryTree> getHistory;

            if (storedata.ContainsKey(identifer))
            {
                getHistory = storedata[identifer];

                //The lowest value in the list
                HistoryTree LowestTimestamp = getHistory.OrderByDescending(p => p.timestamp).LastOrDefault();
                //HistoryTree GreatestTimestamp = getHistory.OrderByDescending(x => x.timestamp).FirstOrDefault();

                var closest = getHistory.Select(n => new { n, timestamp = Math.Abs(n.timestamp - timestamp) })
                    .OrderBy(n => n.timestamp)
                    .First().n.timestamp;

                if (timestamp < LowestTimestamp.timestamp)
                {
                    displayexecptionmessage.TimestampNotFound(timestamp);
                    return null;
                }

                returntimestamp = getHistory.Single(s => s.timestamp == closest);
                returntimestamp.PrintData();
                return returntimestamp.data;

                //Remove any entries that are equal or greater than
                
                //if (timestamp )
                //LowestTimestamp.PrintTimestampAndData();
                //LowestTimestamp.PrintTimestampAndData();
             
            }
            else
            {
                displayexecptionmessage.TimestampNotFound(timestamp);
                return null;
            }

           
        }

    
    }
}
