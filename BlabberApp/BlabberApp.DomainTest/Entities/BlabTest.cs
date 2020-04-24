using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    /// <summary>
    /// I have rewritten Blab and User to match Don's
    /// This ensures that the sql given works!
    /// 
    /// User is the User equivalent to Twitter.
    /// </summary>
    [TestClass]
    public class BlabTest
    {       
        private Blab blab;
        public BlabTest() 
        {
            blab = new Blab();
        }
        [TestMethod]
        public void TestConstructors()
        {
            string message = "Blab";
            User user = new User();
            Blab blab = new Blab(message);
            Assert.AreEqual(blab.Message, message);

            blab = new Blab(user);
            Assert.AreEqual(blab.User, user);

            blab = new Blab(message, user);
            Assert.AreEqual(blab.User, user);
            Assert.AreEqual(blab.Message, message);

        }
        /// <summary>
        /// enusres that we can get the Blab message
        /// </summary>
        [TestMethod]
        public void TestSetGetMessage()
        {
            string expected = "Blab, Blab, Blab"; 
            blab.Message = "Blab, Blab, Blab";
            string actual = blab.Message;
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Ensures that we can get the id
        /// </summary>
        [TestMethod]
        public void TestId()
        {
            Guid expected = blab.Id;
            Guid actual = blab.Id;
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Tests Blab time
        /// </summary>
        [TestMethod]
        public void TestDTTM()
        {
            Blab Expected = new Blab();
            Blab Actual = new Blab();
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}
