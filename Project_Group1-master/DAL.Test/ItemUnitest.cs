using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class ItemsTest
    {
        [Theory]
        [InlineData(1)]
        public void TestGetItemByID(int ItemId)
        {
            ItemDAL item = new ItemDAL();
            Assert.NotNull(item.GetItemById(ItemId));
        }
        
    }
}