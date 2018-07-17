using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DAL;
using Persistence;

namespace BL {
    public class Customer_Bl {
        private CustomerDAL idal = new CustomerDAL ();
        public Customer Login (String Username, String password) {
            string regexUser = @"^[^<>()[\]\\,;:'\%#^\s@\$&!@]+@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}))$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            if (Regex.IsMatch (Username, regexUser) != true || Username == "" || Regex.IsMatch (password, regexPassword) != true || password == "") {
                return null;
            }
            return idal.Login (Username, password);
        }
    }
}