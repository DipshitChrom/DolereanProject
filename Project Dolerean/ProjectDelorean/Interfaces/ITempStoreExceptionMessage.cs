using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public interface ITempStoreExceptionMessage
    {
        string IncorrectCommand();

        string NoHistoryExists(int identifer);

        string HistoryAlreadyExists(int identifer);

        string TimestampNotFound(long timestamp);

        string DeletingNotExistingTimestamp(long timestamp);

    }
}
