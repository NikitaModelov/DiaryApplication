using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib
{
    public class DatabaseInterval : Database.IDatabaseInterval<IntervalDTO, bool>
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
            var command = $"DELETE [Task_Interval] WHERE ID = @ID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = id;

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
            finally
            {
                client.CloseConnection();
            }
        }

        public async Task<bool> InsertInterval(int idTask, IntervalDTO interval)
        {
            var command =
                "INSERT [Task_Interval] VALUES (@IDTask, @StartTime, @FinishTime, @Rating)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(command, client.OpenConnection()))
                {
                    cmd.Parameters.Add("@IDTask", SqlDbType.Int);
                    cmd.Parameters["@IDTask"].Value = idTask;

                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime);
                    cmd.Parameters["@StartTime"].Value = interval.StartTime;

                    cmd.Parameters.Add("@FinishTime", SqlDbType.DateTime);
                    cmd.Parameters["@FinishTime"].Value = interval.FinishTime;

                    cmd.Parameters.Add("@Rating", SqlDbType.Float);
                    cmd.Parameters["@Rating"].Value = interval.Rating;

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
            finally
            {
                client.CloseConnection();
            }

        }
    }
}
