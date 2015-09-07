using System;
using System.Collections.Generic;
using System.Linq;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Honey.Test
{
    [TestClass]
    public class SubscriberCRUDTest
    {
        [TestMethod]
        public void GetListTest()
        {
            int subsriberId = Add();
            Assert.IsTrue(subsriberId > 0);

            List<Subscriber> subscribers = new SubscriberCRUD().GetList();
            Assert.IsNotNull(subscribers);
            Assert.IsTrue(subscribers.Count > 0);
            Assert.AreEqual(1, subscribers.Where(x => x.Id == subsriberId).ToList().Count);
        }

        [TestMethod]
        public void AddTest()
        {
            int subsriberId = Add();
            Assert.IsTrue(subsriberId > 0);
        }

        private int Add()
        {
            Subscriber subsriber = new Subscriber
            {
                
                EmailAddress = "none@none.com",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            int result = new SubscriberCRUD().Add(subsriber);
            return result;
        }
    }
}
