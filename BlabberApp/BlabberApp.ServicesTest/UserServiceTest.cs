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
    public class UserServiceTest
    {
        private UserServiceFactory userServiceFactory = new UserServiceFactory();
        /// <summary>
        /// Appears to be an in memory test ensuring that an empty list doesn't return anything.
        /// </summary>
        [TestMethod]
        public void GetAllEmptyTest()
        {
            UserService userService = userServiceFactory.CreateUserService();
            ArrayList expected = new ArrayList();
            IEnumerable actual = userService.GetAll();
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }
        /// <summary>
        /// Appears to be an in memory test ensuring that after adding a User we can return that user.
        /// </summary>
        [TestMethod]
        public void AddNewUserSuccessTest()
        {
            string email = "user@example.com"; 
            UserService userService = userServiceFactory.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);
            User actual = userService.FindUser(email);
            Assert.AreEqual(expected.Email, actual.Email);
        }
    }
}
