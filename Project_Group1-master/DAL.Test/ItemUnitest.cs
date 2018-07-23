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
            Item_DAL item = new Item_DAL();
            Assert.NotNull(item.getItemById(ItemId));
        }
        
    }
}