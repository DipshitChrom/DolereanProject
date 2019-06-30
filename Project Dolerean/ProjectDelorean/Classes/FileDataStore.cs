using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDelorean.Interfaces;
using System.IO;
using System.Diagnostics;

namespace ProjectDelorean.Classes
{
    public class FileDataStore : IFileDataStore
    {
        public void StoreDictionaryEntries(int id, long timestamp, string data)
        {
            //Write dictionary storage to a file.
            //
            try
            {
                StreamWriter sw = new StreamWriter("C:/Users/Emmanuel Mark/Desktop/Interview Practice Code VS 2019/Project Delorean/ProjectDelorean/datastore2.txt", true);

                sw.WriteLine(id + "," + timestamp + "," + data);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Execption" + e.Message);
            }
            finally
            {
                Debug.WriteLine("Executing final block");
            }



        }

        //public int ReturnArrayLength(string[] arraylengthtoreturn)
        //{

        //}
        public Dictionary<int, List<HistoryTree>> InitializeDictionary()
        {
            Dictionary<int, List<HistoryTree>> initialisedDictionary = new Dictionary<int, List<HistoryTree>>();
            List<HistoryTree> historytreelist = new List<HistoryTree>();
            HistoryTree historyTree;
            int identifer;
            int previousidentifer = 0;
            long timestamp;
            string data;

            //Read the file
            string line;
            try
            {
                StreamReader readfile = new StreamReader("C:/Users/Emmanuel Mark/Desktop/Interview Practice Code VS 2019/Project Delorean/ProjectDelorean/datastore2.txt");

                line = readfile.ReadLine();
                string[] filedata;

                while (line != null)
                {
                
                    filedata = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (filedata.Length == 3)
                    {
                        identifer = Convert.ToInt32(filedata[0]);
                        timestamp = Convert.ToInt64(filedata[1]);
                        data = filedata[2];
                        historyTree = new HistoryTree(timestamp, data);

                        //if (identifer != previousidentifer)
                        //{
                          //  h
                        //}

                        if (initialisedDictionary.ContainsKey(identifer))
                        {
                            historytreelist.Add(historyTree);
                            initialisedDictionary[identifer] = historytreelist;
                        }
                        else
                        {
                            historytreelist.Add(historyTree);
                            initialisedDictionary.Add(identifer, historytreelist);
                        }
                       

                        //if (identifer == previousidentifer)
                        //{
                          //  historytreelist.Add(historyTree);
                           // intializedDictionary[identifer] = historytreelist;
                       // }

                        previousidentifer = identifer;
                    }


                    if (filedata.Length == 2)
                    {
                        identifer = Convert.ToInt32(filedata[0]);
                        timestamp = Convert.ToInt64(filedata[1]);
                    }


                    line = readfile.ReadLine();
                }

                readfile.Close();
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Debug.WriteLine("Executing final block");
            }
            return initialisedDictionary;
        }
    }
}
