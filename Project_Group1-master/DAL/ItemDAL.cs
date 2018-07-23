using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL {
    public class Item_DAL {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public static Items GetItem (MySqlDataReader reader) {
            Items item = new Items ();
            item.ItemId = reader.GetInt32 ("ItemId");
            item.ItemName = reader.GetString ("Itemname");
            item.Price = reader.GetInt32 ("Price");
            item.Amount = reader.GetInt32 ("Amount");
            return item;
        }
        public List<Items> GetItems () {
            string query = "Select * from Items;";
            List<Items> list = new List<Items> ();
            using (connection = DBHelper.OpenConnection ()) {
                MySqlCommand cmd = new MySqlCommand (query, connection);
                using (reader = cmd.ExecuteReader ()) {
                    while (reader.Read ()) {
                        list.Add (GetItem (reader));
                    }
                }
            }
            return list;
        }
        public Items getItemById (int id) {
            string query = $"SELECT * FROM Items WHERE ItemId= '{id}';";
            Items item = new Items ();
            using (connection = DBHelper.OpenConnection ()) {
                MySqlCommand cmd = new MySqlCommand (query, connection);
                using (reader = cmd.ExecuteReader ()) {
                    if (reader.Read ()) {
                        item = GetItem (reader);
                    }
                }
            }
            return item;
        }
    }
}