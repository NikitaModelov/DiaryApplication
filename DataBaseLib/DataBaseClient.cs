using System;
using System.Data.SqlClient;

namespace DiaryApplication.Core.DataBase
{
    public sealed class DataBaseClient
    {
        private readonly string connectionString =
            @"Data Source=DESKTOP-UAKSTFA\SQLEXPRESS;Initial Catalog=Diary;Integrated Security=True";

        public SqlConnection Connection { get; }

        private DataBaseClient()
        {
            Connection = new SqlConnection(connectionString);
        }

        private static readonly Lazy<DataBaseClient> lazy =
            new Lazy<DataBaseClient>(() => new DataBaseClient());

        public static DataBaseClient Source => lazy.Value;

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