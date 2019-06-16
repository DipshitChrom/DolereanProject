using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public interface ITemporalStorage
    {
        void CREATETimestamp(int id, int timestamp, double data);
        int UPDATETimestamp(int id, int timestamp, double data);

        int DELETETimestamp(int id);

        int GrabLatestTimestamp(int id);

        int GETTimestamp(int id);
    }
}
