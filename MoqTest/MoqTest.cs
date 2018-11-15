using Moq;
using NUnit.Framework;using System;
using Test;

namespace MoqTest
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();
            service.PlaceOrder(order);
            storage.Verify(s => s.Store(order), Times.Once);
        }

        [Test]
        public void PlaceOrderWithId_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();
            storage.Setup(x => x.Store(order)).Returns(order.id = 3);
            Assert.AreEqual(service.PlaceOrder(order), 3);
        }
        [Test]
        public void PlaceOrderNull_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();
            storage.Setup(s => s.Store(null)).Throws(new ArgumentException());
            Assert.That(()=> service.PlaceOrder(null), Throws.ArgumentException);
        }
    }
}
