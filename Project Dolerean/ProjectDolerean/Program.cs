using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDelorean.Interfaces;

namespace ProjectDelorean
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, HistoryTree> tempstore = new Dictionary<int, HistoryTree>();
            TempStoreExeceptionMessage displayexceptionMessage = new TempStoreExeceptionMessage();
            Console.WriteLine("Enter a command for the temporal storage");
            string userinput = Console.ReadLine();
            
            while (!userinput.Contains("QUIT"))
            {
                RecieveCommand newcommand = new RecieveCommand(userinput);

                if (newcommand.isCommandValid() == false)
                {
                    displayexceptionMessage.IncorrectCommand();
                    Console.WriteLine("Enter a command for the temporal storage");
                    userinput = Console.ReadLine();
                }
                else
                {
                    newcommand.FormatUserInput();
                    newcommand.runCommand();
                    Console.WriteLine("Enter a command for the temporal storage");
                    userinput = Console.ReadLine();
                }
      
            }
        }
    }
}
