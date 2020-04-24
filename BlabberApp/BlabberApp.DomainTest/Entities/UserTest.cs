using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// Test get email
        /// </summary>
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            User harness = new User(); 
            string expected = "foobar@example.com";
            User user = new User(expected);
            harness.ChangeEmail("foobar@example.com");
            string actual = harness.Email;
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        /// <summary>
        /// Testing for invalid email.
        /// </summary>
        [TestMethod]
        public void TestSetGetEmail_Fail()
        {
            User harness = new User();
            string fakemail = "example.com";
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail(fakemail));
            Assert.AreEqual(fakemail + " is invalid", ex.Message.ToString());
        }
        /// <summary>
        /// Tests the UserID
        /// </summary>
        [TestMethod]
        public void TestId()
        {
            User harness = new User();
            Guid expected = harness.Id;
            Guid actual = harness.Id;
            Assert.AreEqual(actual, expected);
        }
    }
}
