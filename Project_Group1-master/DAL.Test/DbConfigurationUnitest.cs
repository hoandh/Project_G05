using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class DbConfiguratonTest
    {
        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(Dbconfiguration.OpenConnection());
        }

        [Theory]
        [InlineData("server=localhost; user id=root; password=danghoan; port=3306;database=shopping;SslMode=None")]
        public void OpenConnectionWithStringTest(string connectionString)
        {
            Assert.NotNull(Dbconfiguration.OpenConnection(connectionString));
        }

        [Theory]
        [InlineData("server=localhost1;user id=root;password=danghoan;port=3306;database=shopping;SslMode=None")]
        public void OpenConnectionWithStringFailTest(string connectionString)
        {
            Assert.Null(Dbconfiguration.OpenConnection(connectionString));
        }

        [Fact]
        public void OpenDefaultConnectionTest()
        {
            Assert.NotNull(Dbconfiguration.OpenDefaultConnection());
        }
    }
}