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
    public class BlabServiceTest
    {
        private BlabServiceFactory blabServiceFactory = new BlabServiceFactory();

        /// <summary>
        /// Appears to be an in memory Test ensuring that empty lists do not return anything.
        /// </summary>
        [TestMethod]
        public void GetAllEmptyTest()
        {
            BlabService blabService = blabServiceFactory.CreateBlabService();
            ArrayList expected = new ArrayList();
            IEnumerable actual = blabService.GetAll();
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }
        /// <summary>
        /// Appears to be an in memory test ensuring that after adding a blab you can get that blab.
        /// </summary>
        [TestMethod]
        public void AddNewBlabSuccessTest()
        {
            string email = "user@example.com";
            string msg = "Blab, Blab, Blab";
            BlabService blabService = blabServiceFactory.CreateBlabService();
            Blab blab = blabService.CreateBlab(msg, email);
            blabService.AddBlab(blab);
            Blab actual = (Blab)blabService.FindUserBlabs(email);
        }
    }
}
