using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectDelorean.Interfaces;

namespace ProjectDolereanUnitTesting
{
    [TestFixture]
    public class ProjectDolereanUnitTests
    {

        [Test]
        public void ExampleInteractionTest()
        {

        }

        [Test]
        public void InputtingIncorrectCommand()
        {
            string command = "NOT CREATE";

            RecieveCommand testcommand = new RecieveCommand(command);

            Assert.AreEqual(testcommand.isCommandValid(), false);


        }

        [Test]
        public void TwoDifferentTimestamps()
        {

        }

        [Test]
        public void CreatingTimestamp()
        {

        }

        [Test]
        public void UpdatingTimestamp()
        {

        }

        [Test]
        public void DeletingATimestamp()
        {

        }

        [Test]
        public void UpdatingANonExistingTimestamp()
        {

        }

        [Test]
        public void TimestampContainingAString()
        {

        }

        [Test]
        public void GetExistingTimeStamp()
        {

        }

        [Test]
        public void GetNonExistingTimeStamp()
        {

        }

        [Test]
        public void CreateNewTimestamp()
        {

        }

        [Test]
        public void CreateExistingTimestamp()
        {

        }
        
        [Test]
        public void DeletingANonExistantTimestamp()
        {

        }



     
    }
}
