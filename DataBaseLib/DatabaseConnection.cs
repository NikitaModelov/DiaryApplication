using System;
using System.Data.SqlClient;

namespace DataBaseLib
{
    public sealed class DatabaseConnection
    {
        private readonly string connectionString =
            @"Data Source=DESKTOP-UAKSTFA\SQLEXPRESS;Initial Catalog=Diary;Integrated Security=True";

        public SqlConnection Connection { get; }

        private DatabaseConnection()
        {
            Connection = new SqlConnection(connectionString);
        }

        private static readonly Lazy<DatabaseConnection> lazy =
            new Lazy<DatabaseConnection>(() => new DatabaseConnection());

        public static DatabaseConnection Source => lazy.Value;

        public SqlConnection OpenConnection()
        {
            Connection.Open();
            return Connection;
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}