using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjectDelorean.Classes
{
    public class TempStoreExeceptionMessage
    {
        public void IncorrectCommand()
        {
            Console.WriteLine("ERR Command does not exist in the command list");
        }

        public void NoHistoryExists(int identifer)
        {
            Console.WriteLine("ERR No history exists for the timestamp - " + identifer);
        }

        public void HistoryAlreadyExists(int identifer)
        {
            Console.WriteLine("ERR History already exists for the timestamp: " + identifer);
        }

        public void TimestampNotFound(long timestamp)
        {
            Console.WriteLine("ERR the timestamp does not exist in the temporal storage: " + timestamp);
        }

        public void DeletingNotExistingTimestamp(long timestamp)
        {
            Console.WriteLine("ERR the timestamp you are trying to delete does not exist - " + timestamp);
        }

        public void NoHistoryForLatestTimestamp(int identifer)
        {
            Console.WriteLine("ERR there is no history for the identifer " + identifer);
        }

        public void CommandOnly()
        {
            Console.WriteLine("Please enter the values along with the command");
        }
    }
}
