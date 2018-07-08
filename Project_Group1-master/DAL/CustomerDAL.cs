using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persitence;
namespace DAL {
    public class CustomerDAL {
        private string query;
        private MySqlConnection connection = Dbconfiguration.OpenConnection ();
        private MySqlDataReader reader;
        public Customer GetById (int UserId) {
            if (connection.State == System.Data.ConnectionState.Closed) {
                connection.Open ();
            }
            query = @"select UserId, Username,
                        ifnull(Phone, '') as Phone
                        from Users where UserId=" + UserId + ";";
            reader = (new MySqlCommand (query, connection)).ExecuteReader ();
            Customer c = null;
            if (reader.Read ()) {
                c = GetCustomer (reader);
            }
            reader.Close ();
            connection.Close ();
            return c;
        }
        internal Customer GetById (int UserId, MySqlConnection connection) {
            query = @"select UserId, Username,
                        ifnull(Phone, '') as Phone
                        from Users where UserId=" + UserId + ";";
            Customer c = null;
            reader = (new MySqlCommand (query, connection)).ExecuteReader ();
            if (reader.Read ()) {
                c = GetCustomer (reader);
            }
            reader.Close ();
            return c;
        }
        private Customer GetCustomer (MySqlDataReader reader) {
            Customer c = new Customer ();
            c.UserId = reader.GetInt32 ("UserId");
            c.UserName = reader.GetString ("Username");
            c.Phone = reader.GetInt32 ("Phone");
            c.Password = reader.GetString ("Password");
            return c;
        }

    }
}