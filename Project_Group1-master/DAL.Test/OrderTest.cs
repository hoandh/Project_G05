using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;
using Persistence;
using System.Collections.Generic;

namespace DAL.Test
{
    public class OrderTest
    {
        private OrderDAL order = new OrderDAL();
        [Fact]
        public void TestName()
        {
            Orders or = new Orders();
            Assert.Null(order.AddOrder(or));
        }
        

    }
}