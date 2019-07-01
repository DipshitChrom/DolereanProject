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
        public string IncorrectCommand()
        {
            String message = "Command does not exist in the command list";

            Console.WriteLine(message);

            return message;
        }

        public string NoHistoryExists(int identifer)
        {
            string message = "ERR No history exists for the timestamp - " + identifer;

            Console.WriteLine(message);

            return message;

        }

        public string HistoryAlreadyExists(int identifer)
        {
            string message = "ERR History already exists for the timestamp: " + identifer;

            Console.WriteLine(message);

            return message;
        }

        public string TimestampNotFound(long timestamp)
        {
            string message = "ERR the timestamp does not exist in the temporal storage: " + timestamp;

            Console.WriteLine(message);

            return message;
        }

        public string DeletingNotExistingTimestamp(long timestamp)
        {
            string message = "ERR the timestamp you are trying to delete does not exist - " + timestamp;

            Console.WriteLine(message);

            return message;
        }

        public string NoHistoryForLatestTimestamp(int identifer)
        {
            string message = "ERR there is no history for the identifer " + identifer;

            Console.WriteLine(message);

            return message;
        }

        public string CommandOnly()
        {
            string message = "Please enter the values along with the command";

            Console.WriteLine(message);

            return message;
        }
    }
}
