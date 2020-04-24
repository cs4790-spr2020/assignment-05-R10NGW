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
    public class BlabServiceFactoryTest
    {
        BlabServiceFactory harness = new BlabServiceFactory();
        /// <summary>
        /// Ensures that BlabServiceFactory.CreateBlabAdapter returns the correct type.
        /// </summary>
        [TestMethod]
        public void BuildAdapterPluginTest()
        {
            //Arrange and Act
            var blabAdapter = harness.CreateBlabAdapter();
            //Assert
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }
        /// <summary>
        /// ensures that BlabServiceFactory returns the correct type
        /// </summary>
        [TestMethod]
        public void BuildServiceAdapterPluginTest()
        {
            //Arrange and Act
            var blabService = harness.CreateBlabService();
            //Assert
            Assert.IsTrue(blabService is BlabService);
        }
    }
}
