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
            Console.WriteLine("Enter a command for the temporal storage");
            string userinput = Console.ReadLine();
            //FileDataStore test = new FileDataStore();

            //test.InitializeDictionary();

            while (!userinput.Equals("QUIT"))
            {
                RecieveCommand newcommand = new RecieveCommand(userinput);

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
                }

            }
        }
    }
}
