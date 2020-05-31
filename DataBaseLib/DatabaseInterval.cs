using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class DatabaseInterval : IDatabaseInterval<IntervalDTO, bool>
    {
        private readonly DatabaseConnection client;

        public DatabaseInterval()
        {
            client = DatabaseConnection.Source;
        }
        public Task<List<IntervalDTO>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<IntervalDTO> SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(IntervalDTO newObject)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var command = $"DELETE [Task_Interval] WHERE ID = {id}";
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    cmd.ExecuteNonQuery();
                }
                client.CloseConnection();
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine("[DatabaseTask.InsertInterval()] Error: " + e.Message);
                client.CloseConnection();
                return false;
            }
        }

        public async Task<bool> InsertInterval(int idTask, IntervalDTO interval)
        {
            var command =
                $"INSERT [Task_Interval] VALUES ({idTask}, '{interval.StartTime}', '{interval.FinishTime}', {interval.Rating})";
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    cmd.ExecuteNonQuery();
                }
                client.CloseConnection();
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine("[DatabaseTask.InsertInterval()] Error: " + e.Message);
                client.CloseConnection();
                return false;
            }

        }
    }
}
