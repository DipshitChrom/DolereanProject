using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public interface IRecieveCommand
    {
        void FormatUserInput();

        bool IsCommandValid();
        void RunCommand();
    }
}
