using Trackables.Data.Abstract;
using System.Data;
using System.Data.SqlClient;

namespace Trackables.Data.Concrete
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly string _connectionString;

        public FavouriteRepository()
        {}

        public FavouriteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DataTable GetFavourites(int userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetFavourites", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void MergeFavourite(int userId, int id, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("MergeFavourite", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));
                cmd.Parameters["@quantity"].Value = quantity;

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters["@userId"].Value = userId;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteFavourite(int userId, string code)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DeleteFavourite", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters["@userId"].Value = userId;

                cmd.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 255));
                cmd.Parameters["@code"].Value = code;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
