using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectDelorean.Classes;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase]
        public void MoreThanOneCommand()
        {
            string command = "create monkey 1 1 21";

            RecieveCommand testCommand = new RecieveCommand(command);

            Assert.AreEqual(false, testCommand.IsCommandValid());
        }

        [TestCase]
        public void CorrectCommandWithIncorrectCommand()
        {
            string command = "quit create 1 1 21";

            RecieveCommand testCommand = new RecieveCommand(command);

            Assert.AreEqual(false, testCommand.IsCommandValid());
        }

        public void CreateTimestampwithExistingData()
        {
            History myHistory = new History();
            myHistory.CreateTimestamp(1, 15, "anything");
          
        }

        public void GetTimestampwithExactIdentifer()
        {
            History history = new History();
            int identifer = 2;
            long timestamp = 130;
            string data = "honey";
            Assert.AreEqual(data, history.GetTimestamp(identifer, timestamp));
        }

        [TestCase]
        public void UpdateTimestampReturnPreviousData()
        {
            History history = new History();
            string data = "chocolate";

            Assert.AreEqual(data, history.UpdateTimestamp(1, 18, "choco chip cookies"));

        }

        [TestCase]
        public void GetLatestTimestamp()
        {
            History latesthistory = new History();

            int identifer = 2;

            long resulttimestamp = 130;
            Assert.AreEqual(resulttimestamp, latesthistory.GrabLatestTimestamp(identifer));
        }
        
    }
}
