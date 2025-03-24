using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NorthWindManagementApp.DataAccessLayer
{
    public static class DataAccess // sınıf static olduysa metotlar static olmak zorunda. static demek bir tane kendisi otomatik olarak nesne oluşturur. bizim ayrıyeten nesne yaratmamıza gerek kalmaz.
    {
        public static SqlConnection Connection { get; set; } = CreateConnection();
        private static SqlConnection CreateConnection()
        {
            //string connectionString = @"Server=HALIL\MSCD8SQLSERVER;Database=Northwind;User=sa;Password=Qwe123.,;TrustServerCertificate=true";

            string server = "HALIL\\MSCD8SQLSERVER";
            string db = "Northwind";
            string user = "sa";
            string pass = "Qwe123.,";
            bool trust = true;
            string connectionString = $"Server={server};Database={db};User={user};Password={pass};TrustServerCertificate={trust}";
            SqlConnection connection = new (connectionString);
            return connection;
        }

        public static void ConnectDb()
        {
            if(Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public static void DisconnectDb()
        {
            if(Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
