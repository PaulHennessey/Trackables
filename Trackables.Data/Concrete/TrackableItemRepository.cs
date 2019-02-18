using System;
using System.Data;
using System.Data.SqlClient;
using MyFoodDiary.Data.Abstract;

namespace MyFoodDiary.Data.Concrete
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

        public DataTable GetTrackableItems(DateTime dt, int userId)
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

                cmd.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                cmd.Parameters["@userId"].Value = userId;

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

                cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.VarChar));
                cmd.Parameters["@Amount"].Value = quantity.ToString();

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //public void DeleteFoodItem(int id)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var cmd = new SqlCommand("DeleteFoodItem", connection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
        //        cmd.Parameters["@Id"].Value = id;

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}


        //public void UpdateFoodItem(int id, int quantity)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var cmd = new SqlCommand("UpdateFoodItem", connection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
        //        cmd.Parameters["@Id"].Value = id;

        //        cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
        //        cmd.Parameters["@Quantity"].Value = quantity;

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
    }
}
