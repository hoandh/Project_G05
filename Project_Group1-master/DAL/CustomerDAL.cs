using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL {
    public class CustomerDAL {
        private string query;
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public static Customer GetCustomer (MySqlDataReader reader) {
            Customer customer = new Customer ();
            customer.UserId = reader.GetInt32 ("UserId");
            customer.UserName = reader.GetString ("Username");
            customer.Phone = reader.GetInt32 ("Phone");
            customer.Password = reader.GetString ("password");
            customer.Address = reader.GetString ("Address");
            return customer;
        }
        public Customer Login (string UserName, string password) {
            string regexUser =  @"^[-.@_a-zA-Z0-9 ]+$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            if (Regex.IsMatch (UserName, regexUser) != true || UserName == "" || Regex.IsMatch (password, regexPassword) != true || password == "") {
                return null;
            }
            query = $"Select * From Users  where Username = '{UserName}' and password = '{password}';";
            Customer customer = null;
            using (connection = DBHelper.OpenConnection ()) {
                MySqlCommand cmd = new MySqlCommand (query, connection);
                using (reader = cmd.ExecuteReader ()) {
                    if (reader.Read ()) {
                        customer = new Customer ();
                        customer = GetCustomer (reader);
                    }
                }
            }
            return customer;
        }
        // public List<Customer> GetCustomers (MySqlCommand command) {
        //     List<Customer> list = new List<Customer> ();
        //     using (connection = DBHelper.OpenConnection ()) {
        //         MySqlCommand cmd = new MySqlCommand (query, connection);
        //         using (reader = cmd.ExecuteReader ()) {
        //             while (reader.Read ()) {
        //                 list.Add (GetCustomer (reader));
        //             }
        //         }
        //     }
        //     return list;
        // }
    }

}