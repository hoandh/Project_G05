using System;
using System.Text.RegularExpressions;
using BL;
using Xunit;

namespace BL.Test {
    public class TestDataLogin {
        private static Customer_Bl custom = new Customer_Bl ();
        // User Regex format Email 
        [Fact]
        public void TestDataLoginCinemaTrue () {
            string regex =@"^[-.@_a-zA-Z0-9 ]+$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            string User = "hoan";
            string pass = "123456";
            Assert.Matches (regex, User);
            Assert.Matches (regexPassword,pass);
            Assert.NotNull (custom.Login (User, pass));
        }

        [Theory]
        [InlineData ("hoa''n", "123''45")]
        [InlineData ("''", "12''34s5")]
        public void TestDataLoginCinemaFail (string username, string pass) {
            string regexEmail = @"^[-.@_a-zA-Z0-9 ]+$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            Assert.DoesNotMatch (regexEmail, username);
            Assert.DoesNotMatch (regexPassword, pass);
            Assert.Null (custom.Login (username, pass));
        }
    }
}