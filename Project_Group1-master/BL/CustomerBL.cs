using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL {
    public class Customer_Bl {
        private CustomerDAL idal = new CustomerDAL ();
        public Customer Login (String UserName, String password) {
            string regexUser =@"^[-.@_a-zA-Z0-9 ]+$" ;
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            if (Regex.IsMatch (UserName, regexUser) != true || UserName == "" || Regex.IsMatch (password, regexPassword) != true || password == "") {
                return null;
            }
            return idal.Login (UserName, password);
        }
    }
     

}