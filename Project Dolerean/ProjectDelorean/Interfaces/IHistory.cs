using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public interface IHistory
    {
        void CreateTimestamp(int identifer, long timestamp, string data);
        string UpdateTimestamp(int identifer, long timestamp, string data);

        void DeleteTimestamp(int identifer);

        long GrabLatestTimestamp(int identifer);

        string GetTimestamp(int id, long timestamp);
    }
}
