using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;
namespace DAL
{
    public class OrderDAL
    {
        public bool AddOrder(Orders order)
        {
            if (order == null || order.ItemsList == null || order.ItemsList.Count == 0)
            {
                return false;
            }
            MySqlConnection connection = DbConfiguration.OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;
            try
            {
                //Khoa cap nhat tat ca table , bao dam tinh toan ven du lieu
                cmd.CommandText = "lock tables Users write, Orders write, Items write, Bill write;";
                cmd.ExecuteNonQuery();
                MySqlTransaction trans = connection.BeginTransaction();
                cmd.Transaction = trans;
                // Nhap du lieu cho bang Order
                cmd.CommandText = "insert into Orders(CodeOrders , UserId) values (@CodeOrders , @UserId)";
                cmd.Parameters.AddWithValue("@CodeOrders", order.CodeOrder);
                cmd.Parameters.AddWithValue("@UserId", order.UserId);
                //Nhập dữ liệu cho bảng Bill
                for (int i = 0; i < order.ItemsList.Count; i++)
                {
                    cmd.CommandText = $@"insert into Bill(Codeorder,ItemId,Price,quantity) values
                    ({order.CodeOrder},
                     {order.ItemsList[i].item.ItemId},
                     {order.ItemsList[i].quantity},
                     {order.ItemsList[i].quantity * order.ItemsList[i].item.Price})";
                     cmd.CommandText = $"update Items set Amount = Amount - {order.ItemsList[i].quantity} where ItemId = {order.ItemsList[i].item.Price};";

                }
            }
            catch
            {

            }
            finally
            {
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DbConfiguration.CloseConnection();
            }

            return true;
        }
    }

}