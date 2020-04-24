using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;

namespace BlabberApp.ServicesTest
{
    /// <summary>
    /// After I ask more questions and understand what Services do, I'll write my own tests.
    /// If these tests fail, I know I broke something.
    /// These should be identical to Don's tests.
    /// </summary>
    [TestClass]
    public class UserServiceFactoryTest
    {
        UserServiceFactory harness = new UserServiceFactory();
        /// <summary>
        /// Ensures that UserServiceFactory.CreateUserAdapter returns the correct type.
        /// </summary>
        [TestMethod]
        public void BuildAdapterPluginTest()
        {
            var userAdapter = harness.CreateUserAdapter();
            Assert.IsTrue(userAdapter is UserAdapter);
        }
        /// <summary>
        /// Ensures that the UserServiceFactory.CreateUserService returns the correct type.
        /// </summary>
        [TestMethod]
        public void BuildServiceAdapterPluginTest()
        {
            var userService = harness.CreateUserService();
            Assert.IsTrue(userService is UserService);
        }
    }
}
