using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        private User _user;
        private UserAdapter _harness = new UserAdapter(new MySqlUser());
        private MySqlUser msu = new MySqlUser();
        private InMemory InMemory = new InMemory();
        private readonly string _email = "foobar@example.com";

        [TestInitialize]
        public void Setup()
        {
            _user = new User(_email);
        }
        [TestCleanup]
        public void TearDown()
        {
            User user = new User(_email);
            _harness.Remove(user);
        }

        [TestMethod]
        public void Canary()
        {
            User user = new User();
            Assert.AreEqual(true, true);
            InMemory.ReadByUserEmail("");
            InMemory.Create(user);
            InMemory.Update(user);
            InMemory.ReadById(user.Id);
            InMemory.ReadByUserId("");
            InMemory.Delete(user);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness.Add(_user);
            _harness.Update(_user);
            _harness.GetAll();
            msu.Update(_user);
            User actual = _harness.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
        }
        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);
            //Act
            User actual = _harness.GetByEmail(_email);
            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }
        [TestMethod]
        public void Test()
        {
            msu.ReadAll();
            msu.Close();
        }
    }
}
