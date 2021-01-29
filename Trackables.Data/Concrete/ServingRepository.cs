using System;
using System.Data;
using System.Data.SqlClient;
using Trackables.Data.Abstract;

namespace Trackables.Data.Concrete
{
    public class ServingRepository : IServingRepository
    {
        private readonly string _connectionString;

        public ServingRepository()
        {}

        public ServingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DataTable GetServings(DateTime dt, string userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetServings", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));
                cmd.Parameters["@dt"].Value = dt;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar));
                cmd.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void InsertServing(string code, int quantity, DateTime dt, int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertServing", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = code;

                cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
                cmd.Parameters["@quantity"].Value = quantity;

                cmd.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));
                cmd.Parameters["@dt"].Value = dt;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void InsertServing(string code, int quantity, DateTime dt, string userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertServing", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = code;

                cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
                cmd.Parameters["@quantity"].Value = quantity;

                cmd.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));
                cmd.Parameters["@dt"].Value = dt;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar));
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteServing(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DeleteServing", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Value = id;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateServing(int id, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateServing", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                cmd.Parameters["@Id"].Value = id;

                cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                cmd.Parameters["@Quantity"].Value = quantity;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
