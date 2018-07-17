using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL odl = new OrderDAL();
        public bool CreateOrder(Orders order)
        {
            bool result = odl.AddOrder(order);
            return result;
        }
    }
}