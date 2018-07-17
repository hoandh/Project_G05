using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class EmployeesTest
    {
        [Theory]
        [InlineData("abcd", "12345")]
        public void TestName(string user_name, string password)
        {
            CustomerDAL e = new CustomerDAL();
            Assert.Null(e.Login(user_name, password));
        }
        [Theory]
        [InlineData("Admin","12345")]
        public void TestName1(string user_name, string password)
        {
            CustomerDAL e = new CustomerDAL();
            Assert.NotNull(e.Login(user_name, password));
        }
    }
}