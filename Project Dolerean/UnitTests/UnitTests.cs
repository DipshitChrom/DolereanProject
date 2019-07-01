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
        public void CanCreateForAnId()
        {
            var history = new History(new Dictionary<int, List<HistoryTree>>());

            var result = history.CreateTimestamp(1, 100, "10");

            Assert.That(result, Is.EqualTo("10"));
        }

        [TestCase]
        public void CanUpdateForAnId()
        {
            var history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(1, 100, "10");

            var result = history.UpdateTimestamp(1, 200, "20");

            Assert.That(result, Is.EqualTo("10"));
        }

        [TestCase]
        public void GetNoObservationData()
        {
            var history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(1, 100, "10");

            history.UpdateTimestamp(1, 120, "30");

            history.UpdateTimestamp(1, 115, "24");

            var result = history.GetTimestamp(1, 50);

            TempStoreExeceptionMessage storeExeceptionMessage = new TempStoreExeceptionMessage(); 

            Assert.That(result, Is.EqualTo(storeExeceptionMessage.TimestampNotFound(50)));
        }

        [TestCase]
        public void MoreThanOneCommand()
        {
            string command = "create monkey 1 1 21";

            var testCommand = new RecieveCommand(command, new Dictionary<int, List<HistoryTree>>());

            Assert.That(testCommand.IsCommandValid(), Is.EqualTo(false));
        }

        [TestCase]
        public void CorrectCommandWithIncorrectCommand()
        {
            string command = "quit create 1 1 21";

            RecieveCommand testCommand = new RecieveCommand(command, new Dictionary<int, List<HistoryTree>>());

            var result = testCommand.IsCommandValid();

            Assert.AreEqual(result, Is.EqualTo(new TempStoreExeceptionMessage().IncorrectCommand()));
        }

        [TestCase]
        public void CreateTimestampwithSameIdentifer()
        {
            History history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(1, 100, "20");

            var result = history.CreateTimestamp(1, 200, "20");

            Assert.That(result, Is.EqualTo(new TempStoreExeceptionMessage().HistoryAlreadyExists(1)));


            //myHistory.CreateTimestamp(1, 15, "anything");
          
        }

        [TestCase]
        public void GetTimestampwithExactIdentifer()
        {
            History history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(5, 150, "121");

            var result = history.GetTimestamp(5, 150);

            Assert.That(result, Is.EqualTo("121"));
            //Assert.AreEqual(data, history.GetTimestamp(identifer, timestamp));
        }


        [TestCase] 
        public void GetTimestampWithinRange()
        {
            History history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(1, 100, "25");
            history.UpdateTimestamp(1, 120, "21");

            var result = history.GetTimestamp(1, 110);

            Assert.That(result, Is.EqualTo("25"));
        }
        [TestCase]
        public void UpdateTimestampReturnPreviousData()
        {
            History history = new History(new Dictionary<int, List<HistoryTree>>());

            history.CreateTimestamp(0, 50, "Choco");

            var result = history.UpdateTimestamp(0, 120, "Cookie");

            Assert.That(result, Is.EqualTo("Choco"));

            //Assert.AreEqual(data, history.UpdateTimestamp(1, 18, "choco chip cookies"));

        }

        [TestCase]
        public void GetLatestTimestamp()
        {
            History latesthistory = new History(new Dictionary<int, List<HistoryTree>>());


            latesthistory.CreateTimestamp(7, 1213, "1");

            var result = latesthistory.GrabLatestTimestamp(7);

            Assert.That(result, Is.EqualTo("1"));
         
            //Assert.AreEqual(resulttimestamp, latesthistory.GrabLatestTimestamp(identifer));
        }
     
        [TestCase]

        public void DeleteAllTimestampsforIdentifer()
        {
            History deletehistory = new History(new Dictionary<int, List<HistoryTree>>());

            deletehistory.CreateTimestamp(7, 1213, "1");
            deletehistory.UpdateTimestamp(7, 1210, "5");
            deletehistory.UpdateTimestamp(7, 1219, "3");

            var result = deletehistory.DeleteTimestamp(7); 
            //Assert.That
        }
    }
}
