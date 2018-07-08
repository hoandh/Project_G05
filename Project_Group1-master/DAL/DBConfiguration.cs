using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class Dbconfiguration
    {
        private static string Connection_string = "server=localhost; user id=root; password=danghoan; port=3306;database=shopping;SslMode=None";
        private static string conString = null;
        public static MySqlConnection OpenDefaultConnection()
        {
            try{
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = Connection_string
                };
                connection.Open();
                return connection;
            }catch{
                return null;
            }
        }

        public static MySqlConnection OpenConnection()
        {
            try{
                if(conString == null){
                    using (FileStream fileStream = File.OpenRead("ConnectionString.txt"))
                    {
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            conString = reader.ReadLine();
                        }
                    }
                }
                return OpenConnection(conString);
            }catch{
                return null;
            }
        }

        public static MySqlConnection OpenConnection(string connectionString)
        {
            try{
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }catch{
                return null;
            }
        }    
    }
}