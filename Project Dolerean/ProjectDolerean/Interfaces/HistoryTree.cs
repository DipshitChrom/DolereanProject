using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public class HistoryTree
    {
     
        long timestamp { get; set; }

        string data { get; set; }

        public HistoryTree(long timestamp, string data)
        {
            this.timestamp = timestamp;

            this.data = data;
        }
    }
}
