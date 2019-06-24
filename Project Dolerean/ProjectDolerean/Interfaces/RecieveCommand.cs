using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public class RecieveCommand : IRecieveCommand
    {
     
        string userCommand;
        string[] formatcommand;
        int identifer;
        long timeStamp;
        string Data;

        public RecieveCommand(string usercommand)
        {
            userCommand = usercommand;
        }

        public void FormatUserInput()
        {
            string data;
            int id;
            long timestamp;

            id = Convert.ToInt32(formatcommand[1]);
            timestamp = Convert.ToInt64(formatcommand[2]);
            data = formatcommand[3];

            identifer = id;
            timeStamp = timestamp;
            Data = data;

        }

        public bool isCommandValid()
        {
            formatcommand = userCommand.Split();
            
            string[] validcommands = {"QUIT", "CREATE", "UPDATE", "GET", "LATEST", "DELETE"};


            string command = formatcommand[0];
            command = command.ToUpper();
            if (validcommands.Contains(command))
            {
                userCommand = command;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void runCommand()
        {
            
            userCommand.ToUpper();
            History commandtoRun = new History();


            if (userCommand.Equals("CREATE"))
            {
                commandtoRun.CreateTimestamp(identifer, timeStamp, Data);
                
            }
            else if (userCommand.Equals("GET"))
            {
                commandtoRun.GetTimestamp(identifer, timeStamp);
            }
            else if (userCommand.Equals("LATEST"))
            {
                commandtoRun.GrabLatestTimestamp(identifer);
            }

            else if (userCommand.Equals("UPDATE"))
            {
                commandtoRun.UpdateTimestamp(identifer, timeStamp, Data);
            }

            else if (userCommand.Equals("DELETE"))
            {
                commandtoRun.DeleteTimestamp(identifer);
            }
         
        }
            

        }
    }

