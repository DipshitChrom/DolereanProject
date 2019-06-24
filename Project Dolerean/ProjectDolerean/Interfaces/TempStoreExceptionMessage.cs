using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public interface TempStoreExceptionMessage
    {
        void IncorrectCommand();

        void NoHistoryExists(int identifer);

        void HistoryAlreadyExists(int identifer);

        void TimestampNotFound(long timestamp);

        void DeletingNotExistingTimestamp(long timestamp);

        

    }
}
