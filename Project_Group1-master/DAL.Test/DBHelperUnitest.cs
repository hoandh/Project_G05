using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class DBHelperUnitTest
    {
        [Fact]
        public void GetConnectionTest()
        {
            Assert.NotNull(DBHelper.GetConnection());
        }
        
        [Fact]
        public void OpenConnectionTest()
        {
            MySqlConnection con = DBHelper.OpenConnection();
            Assert.NotNull(con);
        }
    }
}
