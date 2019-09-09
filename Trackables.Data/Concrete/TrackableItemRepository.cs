using System;
using System.Data;
using System.Data.SqlClient;
using Trackables.Data.Abstract;

namespace Trackables.Data.Concrete
{
    public class TrackableItemRepository : ITrackableItemRepository
    {
        private readonly string _connectionString;

        public TrackableItemRepository()
        {}

        public TrackableItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetTrackableItems(DateTime dt, string userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetTrackableItems", connection)
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

        public DataTable GetTrackableItem(DateTime dt, int trackableId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetTrackableItem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));
                cmd.Parameters["@dt"].Value = dt;

                cmd.Parameters.Add(new SqlParameter("@trackableId", SqlDbType.Int));
                cmd.Parameters["@trackableId"].Value = trackableId;

                var da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }


        public void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertTrackableItem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@trackableId", SqlDbType.Int));
                cmd.Parameters["@trackableId"].Value = trackableId;

                cmd.Parameters.Add(new SqlParameter("@dt", SqlDbType.DateTime));
                cmd.Parameters["@dt"].Value = dt;

                cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal));
                cmd.Parameters["@Amount"].Value = quantity;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateTrackableItem(int? id, decimal? quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateTrackableItem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal));
                cmd.Parameters["@Amount"].Value = quantity;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
