using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDelorean.Classes;

namespace ProjectDelorean.Interfaces
{
    public interface IFileDataStore
    {
        void StoreDictionaryEntries(int id, long timestamp, string data);
        Dictionary<int, List<HistoryTree>> InitializeDictionary();
    }
}
