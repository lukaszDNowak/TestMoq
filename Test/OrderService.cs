﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class OrderService
    {
        private readonly IStorage _storage;
        public OrderService(IStorage storage)
        {
            _storage = storage;
        }
        public int PlaceOrder(Order order)
        {
            var orderId = _storage.Store(order);
            // Some other work
            return orderId;
        }
    }
}
