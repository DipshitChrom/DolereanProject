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
            string userinput;
            string[] splituserinput;
            string command;
            int id;
            int timestamp;
            double data;
            TemporalStorage temporalStorage = new TemporalStorage();


            Console.WriteLine("Enter a command for the temporal storage");
            userinput = Console.ReadLine();

            while (!userinput.Contains("QUIT"))
            {
                splituserinput = userinput.Split();

                command = splituserinput[0];
                id = Convert.ToInt32(splituserinput[1]);
                timestamp = Convert.ToInt32(splituserinput[2]);
                data = Convert.ToDouble(splituserinput[3]);

                
                if (command.Equals("CREATE"))
                {
                    temporalStorage.CREATETimestamp(id, timestamp, data);
                    //Use the comman
                }
                
                //Split input here to grab command
            }
        }
    }
}
