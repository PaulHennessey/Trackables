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
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string _connectionString;

        public IngredientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// This is used by the Search.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetIngredients(int mealId)
        {
          var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetIngredients", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@mealId", SqlDbType.Int));
                command.Parameters["@mealId"].Value = mealId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }


        public void CreateIngredient(string code, int mealId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertIngredient", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = code;

                cmd.Parameters.Add(new SqlParameter("@MealId", SqlDbType.Int));
                cmd.Parameters["@MealId"].Value = mealId;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateIngredient(int id, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateIngredient", connection)
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



        public DataTable GetIngredient(int id)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetIngredient", connection)
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


        public void DeleteIngredient(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DeleteIngredient", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = id;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
