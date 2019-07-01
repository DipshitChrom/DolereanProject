using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDelorean.Interfaces;

namespace ProjectDelorean.Classes
{
    public class RecieveCommand : IRecieveCommand
    {
        Dictionary<int, List<HistoryTree>> tempstore;
        List<string> validcommands = new List<string> { "CREATE", "UPDATE", "GET", "LATEST", "DELETE" };
        public string originalcommand { get; set; }
        string cleancommand;
        string[] formatcommand;
        int identifer;
        long timeStamp;
        string Data;

        public RecieveCommand(string usercommand, Dictionary<int, List<HistoryTree>> temporalstorage)
        {
            originalcommand = usercommand;
            tempstore = temporalstorage;
        }

        public void NewCommand(string newcommand)
        {
            originalcommand = newcommand;
        }
        public void FormatUserInput()
        {
            string data;
            int id;
            long timestamp;

            if (cleancommand.Equals("DELETE") || cleancommand.Equals("GET"))
            {
                id = Convert.ToInt32(formatcommand[1]);
                timestamp = Convert.ToInt64(formatcommand[2]);

                identifer = id;
                timeStamp = timestamp;
            }
            else if (cleancommand.Equals("LATEST"))
            {
                id = Convert.ToInt32(formatcommand[1]);

                identifer = id;
            }
            else
            {
                id = Convert.ToInt32(formatcommand[1]);
                timestamp = Convert.ToInt64(formatcommand[2]);
                data = formatcommand[3];

                identifer = id;
                timeStamp = timestamp;
                Data = data;
            }


        }

        public bool IsCommandValid()
        {
            formatcommand = originalcommand.Split(new[] { ' ' } , StringSplitOptions.RemoveEmptyEntries);

            if (formatcommand.Length > 4)
            {
                cleancommand = formatcommand[0] + " " + formatcommand[1];
                cleancommand = cleancommand.ToUpper();
            }
            else if (formatcommand.Length < 2)
            {
                cleancommand = formatcommand[0];

                if (cleancommand != "LATEST")
                {
                    return false;
                }
                //TempStoreExeceptionMessage execeptionMessage = new TempStoreExeceptionMessage();
                //execeptionMessage.IncorrectCommand();
            }
            else
            {
                cleancommand = formatcommand[0];
                cleancommand = cleancommand.ToUpper();
            }


            if (validcommands.Contains(cleancommand))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void RunCommand()
        {

            History commandtoRun = new History(tempstore);

            if (cleancommand.Equals("CREATE"))
            {
                commandtoRun.CreateTimestamp(identifer, timeStamp, Data);

            }
            else if (cleancommand.Equals("GET"))
            {
                commandtoRun.GetTimestamp(identifer, timeStamp);
            }
            else if (cleancommand.Equals("LATEST"))
            {
                commandtoRun.GrabLatestTimestamp(identifer);
            }

            else if (cleancommand.Equals("UPDATE"))
            {
                commandtoRun.UpdateTimestamp(identifer, timeStamp, Data);
            }

            else if (cleancommand.Equals("DELETE"))
            {
                commandtoRun.DeletewithIdentiferTimestamp(identifer, timeStamp);
                
            }
        }
    }
}
