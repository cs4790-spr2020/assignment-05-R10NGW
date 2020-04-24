using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using System;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter adapter = new BlabAdapter(new MySqlBlab());
        MySqlBlab msb = new MySqlBlab();
        private BlabAdapter testHarness = new BlabAdapter(new InMemory());

        [TestCleanup]
        public void SQLTeardown()
        {
            //mock User and Blab
            string email = "them@cool.com";
            User user = new User(email);
            Blab blab = new Blab("Test", user);
            adapter.Remove(blab);
        }

        [TestMethod]
        public void SQLCreate()
        {
            //mock User and Blab
            string email = "them@cool.com";
            User user = new User(email);
            Blab blab = new Blab("Test", user);
            //Add blab to database
            adapter.Add(blab);
            adapter.Update(blab);
            //get blab from database
            //ArrayList actual = (ArrayList)adapter.GetByUserId(email);
            //Gets single blab from user
            Blab actual = adapter.GetById(blab.Id);
            adapter.GetByUserId("");
            Assert.AreEqual(actual.Id, blab.Id);
            msb.Update(blab);
            msb.ReadAll();
            msb.Close();
        }

        [TestMethod]
        public void Test()
        {
            User user = new User();
            Blab blab = new Blab();
            blab = new Blab("Blab");
            blab = new Blab(user);
            testHarness.Add(blab);
            testHarness.Update(blab);
            testHarness.GetAll();
            testHarness.GetById(blab.Id);
            testHarness.GetByUserId(user.Id.ToString());
            User user1 = blab.User;
            DateTime dateTime = blab.DTTM;
            string message = blab.Message;
            Guid guid = blab.Id;

            IEnumerable enumerable = adapter.GetAll();

        }
    }
}
