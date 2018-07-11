using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;
using Persistence;

namespace DAL.Test
{
    public class ItemDalUnitTest
    {
        private ItemDAL itemDal = new ItemDAL();
        
        [Theory]
        [InlineData(1)]
        public void GetByCustomerIdTest(int id)
        {
            Items result = itemDal.GetItemById(id);
            Assert.NotNull(result);
        }
    }
}