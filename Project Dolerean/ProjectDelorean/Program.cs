using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDelorean.Classes;

namespace ProjectDelorean
{
    class Program
    {
        static void Main(string[] args)
        {
            TempStoreExeceptionMessage displayexceptionMessage = new TempStoreExeceptionMessage();
            StoreDictionary temporalstore = new StoreDictionary();
            Dictionary<int, List<HistoryTree>> dictionary = new Dictionary<int, List<HistoryTree>>();

            Console.WriteLine("Enter a command for the temporal storage");
            string userinput = Console.ReadLine();
            
            RecieveCommand newcommand = new RecieveCommand(userinput, dictionary);
          

            while (!userinput.Equals("QUIT"))
            {
              
                if (newcommand.IsCommandValid() == false)
                {
                    displayexceptionMessage.IncorrectCommand();
                    Console.WriteLine("Enter a command for the temporal storage");
                    userinput = Console.ReadLine();
                }
                else
                {
                  
                    newcommand.FormatUserInput();
                    newcommand.RunCommand();
                    Console.WriteLine("Enter a command for the temporal storage");
                    userinput = Console.ReadLine();
                    newcommand.originalcommand = userinput;

                }

            }
        }
    }
}
