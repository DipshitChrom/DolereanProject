using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Classes
{
    public class HistoryTree
    {
        public long timestamp { get; set; }

        public string data { get; set; }

        public HistoryTree(long timestamp, string data)
        {
            this.timestamp = timestamp;

            this.data = data;
        }

        public void PrintTimestampAndData()
        {
            Console.WriteLine(timestamp + " " + data);
        }

        public void PrintData()
        {
            Console.WriteLine("OK " + data);
        }

        public long ReturnTimestamp()
        {
            return timestamp;
        }

        public string Returndata()
        {
            return data;
        }
    }
}
