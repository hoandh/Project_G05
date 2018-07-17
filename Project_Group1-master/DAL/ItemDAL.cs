using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public static class ItemFilter{
        public const int GET_ALL = 0;
        public const int FILTER_BY_ITEM_NAME = 1;
    }
    public class ItemDAL
    {
        private string query;
        private MySqlDataReader reader;
        public Items GetItemById(int itemId)
        {
            query = @"select ItemID, ItemName, Price, Amount
                        ifnull(item_description, '') as item_description
                        from Items where item_id=" + itemId + ";";
            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
            Items item = null;
            if (reader.Read())
            {
                item = GetItem(reader);
            }
            DBHelper.CloseConnection();
            return item;
        }
        private Items GetItem(MySqlDataReader reader)
        {
            Items item = new Items();
            item.ItemId = reader.GetInt32("ItemID");
            item.ItemName = reader.GetString("ItemName");
            item.Price = reader.GetInt32("price");
            item.Amount = reader.GetInt32("Amount");
            return item;
        }
        private List<Items> GetItems(MySqlCommand command)
        {
            List<Items> lstItem = new List<Items>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                lstItem.Add(GetItem(reader));
            }
            reader.Close();
            DBHelper.CloseConnection();
            return lstItem;
        }
        public List<Items> GetItems(int itemFilter, Items item)
        {
            MySqlCommand command = new MySqlCommand("", DBHelper.OpenConnection());
            switch(itemFilter)
            {
                case ItemFilter.GET_ALL:
                    query = @"select ItemID, ItemName, Price, Amount";
                    break;
                case ItemFilter.FILTER_BY_ITEM_NAME:
                    query = @"select ItemID, ItemName, Price, Amount
                                where item_name like concat('%',@ItemName,'%');";
                    command.Parameters.AddWithValue("@itemName", item.ItemName);
                    break;
            }
            command.CommandText = query;
            return GetItems(command);
        }
    }
}