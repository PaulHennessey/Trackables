using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Concrete
{
    public class TrackablesRepository : ITrackablesRepository
    {
        private readonly string _connectionString;

        public TrackablesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetTrackables(int userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetTrackables", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                command.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public DataTable GetTrackable(int id)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetTrackable", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void CreateTrackable(Trackable trackable, int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertTrackable", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
                cmd.Parameters["@UserId"].Value = userId;

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                cmd.Parameters["@Name"].Value = trackable.Name;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTrackable(Trackable trackable)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateTrackable", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Value = trackable.Id;

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                cmd.Parameters["@Name"].Value = trackable.Name;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTrackable(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DeleteTrackable", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Value = id;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
