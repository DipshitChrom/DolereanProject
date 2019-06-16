using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelorean.Interfaces
{
    public class TemporalStorage : ITemporalStorage
    {
        Dictionary<int, int> DictStorage = new Dictionary<int, int>();
        public void CREATETimestamp(int id, int timestamp, double data)
        {
            if (DoesTimestampExist(id, timestamp) == true)
            {
                //Get the user to enter another timestamp or update the timestamp that already exists;
                Console.WriteLine("Would you like to update the timestamp or enter a new timestamp");
            }
            else
            {
                DictStorage.Add(id, timestamp);
            }
            
        }
        public int UPDATETimestamp(int id, int timestamp, double data)
        {
            if (DoesTimestampExist(id, timestamp) == true)
            {
                //Get the user to enter another timestamp or update the timestamp that already exists;
                DictStorage[id] = timestamp;
            }
            else
            {
                //Output a message here to the user stating that the Timestamp doesn't exist
                //Maybe ask if they would like to create the timestamp they inputed
                Console.WriteLine("Would you like to create the timestamp entered: y or n");
                string answer = Console.ReadLine();

                if (answer.Equals("y"))
                {
                    CREATETimestamp(id, timestamp, data);
                }
                else if (answer.Equals("n"))
                {
                    //Return user to entering another 
                }
            }

            return id;
        }

        public int DELETETimestamp(int id)
        {
            return id;
        }

        public int GrabLatestTimestamp(int id)
        {
            return id;
        }

        public int GETTimestamp(int id)
        {
            return id;
        }

        public bool DoesTimestampExist(int id, int timestamp)
        {
            if (DictStorage.ContainsKey(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
