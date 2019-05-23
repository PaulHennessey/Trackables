using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;

namespace Trackables.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// This is used by the Search.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetProducts(string userId)
        {
          var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetAllProducts", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar));
                command.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }


        /// <summary>
        /// Note that the stored procedure will ignore duplicate fooditems, and
        /// only return a single product.
        /// </summary>
        /// <param name="foodItems"></param>
        /// <returns></returns>
        public DataTable GetProducts(IEnumerable<FoodItem> foodItems)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Food_Codes", SqlDbType.Structured));
                command.Parameters["@Food_Codes"].Value = CreateCodeTable(foodItems);

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// This is used by the ProductsController Index.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetCustomProducts(int userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetCustomProducts", connection)
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


        /// <summary>
        /// This is used by the ProductsController Index.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetCustomProducts(string userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetCustomProducts", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar));
                command.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        public void CreateProduct(Product product, int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = GenerateCode(userId);

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                cmd.Parameters["@Name"].Value = product.Name;

                cmd.Parameters.Add(new SqlParameter("@Calories", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calories"].Value = product.ProductMacronutrients.Quantity("Calories");

                cmd.Parameters.Add(new SqlParameter("@Protein", SqlDbType.VarChar, 255));
                cmd.Parameters["@Protein"].Value = product.ProductMacronutrients.Quantity("Protein");

                cmd.Parameters.Add(new SqlParameter("@Carbohydrate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carbohydrate"].Value = product.ProductMacronutrients.Quantity("Carbohydrates");

                cmd.Parameters.Add(new SqlParameter("@TotalSugars", SqlDbType.VarChar, 255));
                cmd.Parameters["@TotalSugars"].Value = product.ProductMacronutrients.Quantity("Total Sugars");

                cmd.Parameters.Add(new SqlParameter("@Fat", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fat"].Value = product.ProductMacronutrients.Quantity("Fat");

                cmd.Parameters.Add(new SqlParameter("@Alcohol", SqlDbType.VarChar, 255));
                cmd.Parameters["@Alcohol"].Value = product.ProductMacronutrients.Quantity("Alcohol");

                cmd.Parameters.Add(new SqlParameter("@Fibre", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fibre"].Value = product.ProductMacronutrients.Quantity("Fibre");

                cmd.Parameters.Add(new SqlParameter("@Calcium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calcium"].Value = product.ProductMicronutrients.Quantity("Calcium");

                cmd.Parameters.Add(new SqlParameter("@Sodium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Sodium"].Value = product.ProductMicronutrients.Quantity("Sodium");

                cmd.Parameters.Add(new SqlParameter("@Potassium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Potassium"].Value = product.ProductMicronutrients.Quantity("Potassium");

                cmd.Parameters.Add(new SqlParameter("@Magnesium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Magnesium"].Value = product.ProductMicronutrients.Quantity("Magnesium");

                cmd.Parameters.Add(new SqlParameter("@Iron", SqlDbType.VarChar, 255));
                cmd.Parameters["@Iron"].Value = product.ProductMicronutrients.Quantity("Iron");

                cmd.Parameters.Add(new SqlParameter("@Copper", SqlDbType.VarChar, 255));
                cmd.Parameters["@Copper"].Value = product.ProductMicronutrients.Quantity("Copper");

                cmd.Parameters.Add(new SqlParameter("@Zinc", SqlDbType.VarChar, 255));
                cmd.Parameters["@Zinc"].Value = product.ProductMicronutrients.Quantity("Zinc");

                cmd.Parameters.Add(new SqlParameter("@Manganese", SqlDbType.VarChar, 255));
                cmd.Parameters["@Manganese"].Value = product.ProductMicronutrients.Quantity("Manganese");

                cmd.Parameters.Add(new SqlParameter("@Phosphorus", SqlDbType.VarChar, 255));
                cmd.Parameters["@Phosphorus"].Value = product.ProductMicronutrients.Quantity("Phosphorus");

                cmd.Parameters.Add(new SqlParameter("@Selenium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Selenium"].Value = product.ProductMicronutrients.Quantity("Selenium");

                cmd.Parameters.Add(new SqlParameter("@VitaminD", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminD"].Value = product.ProductMicronutrients.Quantity("Vitamin D");

                cmd.Parameters.Add(new SqlParameter("@VitaminC", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminC"].Value = product.ProductMicronutrients.Quantity("Vitamin C");

                cmd.Parameters.Add(new SqlParameter("@VitaminE", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminE"].Value = product.ProductMicronutrients.Quantity("Vitamin E");

                cmd.Parameters.Add(new SqlParameter("@VitaminK1", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminK1"].Value = product.ProductMicronutrients.Quantity("Vitamin K1");

                cmd.Parameters.Add(new SqlParameter("@VitaminB6", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB6"].Value = product.ProductMicronutrients.Quantity("Vitamin B6");

                cmd.Parameters.Add(new SqlParameter("@VitaminB12", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB12"].Value = product.ProductMicronutrients.Quantity("Vitamin B12");

                cmd.Parameters.Add(new SqlParameter("@VitaminA", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminA"].Value = product.ProductMicronutrients.Quantity("Vitamin A");

                cmd.Parameters.Add(new SqlParameter("@PantothenicAcid", SqlDbType.VarChar, 255));
                cmd.Parameters["@PantothenicAcid"].Value = product.ProductMicronutrients.Quantity("Pantothenic Acid");

                cmd.Parameters.Add(new SqlParameter("@Thiamin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Thiamin"].Value = product.ProductMicronutrients.Quantity("Thiamin");

                cmd.Parameters.Add(new SqlParameter("@Riboflavin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Riboflavin"].Value = product.ProductMicronutrients.Quantity("Riboflavin");

                cmd.Parameters.Add(new SqlParameter("@Niacin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Niacin"].Value = product.ProductMicronutrients.Quantity("Niacin");

                cmd.Parameters.Add(new SqlParameter("@Folate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Folate"].Value = product.ProductMicronutrients.Quantity("Folate");

                cmd.Parameters.Add(new SqlParameter("@Carotene", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carotene"].Value = product.ProductMicronutrients.Quantity("Carotene");

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }




        public void CreateProduct(Product product, string userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("InsertProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = GenerateCode(userId);

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                cmd.Parameters["@Name"].Value = product.Name;

                cmd.Parameters.Add(new SqlParameter("@Calories", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calories"].Value = product.ProductMacronutrients.Quantity("Calories");

                cmd.Parameters.Add(new SqlParameter("@Protein", SqlDbType.VarChar, 255));
                cmd.Parameters["@Protein"].Value = product.ProductMacronutrients.Quantity("Protein");

                cmd.Parameters.Add(new SqlParameter("@Carbohydrate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carbohydrate"].Value = product.ProductMacronutrients.Quantity("Carbohydrates");

                cmd.Parameters.Add(new SqlParameter("@TotalSugars", SqlDbType.VarChar, 255));
                cmd.Parameters["@TotalSugars"].Value = product.ProductMacronutrients.Quantity("Total Sugars");

                cmd.Parameters.Add(new SqlParameter("@Fat", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fat"].Value = product.ProductMacronutrients.Quantity("Fat");

                cmd.Parameters.Add(new SqlParameter("@Alcohol", SqlDbType.VarChar, 255));
                cmd.Parameters["@Alcohol"].Value = product.ProductMacronutrients.Quantity("Alcohol");

                cmd.Parameters.Add(new SqlParameter("@Fibre", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fibre"].Value = product.ProductMacronutrients.Quantity("Fibre");

                cmd.Parameters.Add(new SqlParameter("@Calcium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calcium"].Value = product.ProductMicronutrients.Quantity("Calcium");

                cmd.Parameters.Add(new SqlParameter("@Sodium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Sodium"].Value = product.ProductMicronutrients.Quantity("Sodium");

                cmd.Parameters.Add(new SqlParameter("@Potassium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Potassium"].Value = product.ProductMicronutrients.Quantity("Potassium");

                cmd.Parameters.Add(new SqlParameter("@Magnesium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Magnesium"].Value = product.ProductMicronutrients.Quantity("Magnesium");

                cmd.Parameters.Add(new SqlParameter("@Iron", SqlDbType.VarChar, 255));
                cmd.Parameters["@Iron"].Value = product.ProductMicronutrients.Quantity("Iron");

                cmd.Parameters.Add(new SqlParameter("@Copper", SqlDbType.VarChar, 255));
                cmd.Parameters["@Copper"].Value = product.ProductMicronutrients.Quantity("Copper");

                cmd.Parameters.Add(new SqlParameter("@Zinc", SqlDbType.VarChar, 255));
                cmd.Parameters["@Zinc"].Value = product.ProductMicronutrients.Quantity("Zinc");

                cmd.Parameters.Add(new SqlParameter("@Manganese", SqlDbType.VarChar, 255));
                cmd.Parameters["@Manganese"].Value = product.ProductMicronutrients.Quantity("Manganese");

                cmd.Parameters.Add(new SqlParameter("@Phosphorus", SqlDbType.VarChar, 255));
                cmd.Parameters["@Phosphorus"].Value = product.ProductMicronutrients.Quantity("Phosphorus");

                cmd.Parameters.Add(new SqlParameter("@Selenium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Selenium"].Value = product.ProductMicronutrients.Quantity("Selenium");

                cmd.Parameters.Add(new SqlParameter("@VitaminD", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminD"].Value = product.ProductMicronutrients.Quantity("Vitamin D");

                cmd.Parameters.Add(new SqlParameter("@VitaminC", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminC"].Value = product.ProductMicronutrients.Quantity("Vitamin C");

                cmd.Parameters.Add(new SqlParameter("@VitaminE", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminE"].Value = product.ProductMicronutrients.Quantity("Vitamin E");

                cmd.Parameters.Add(new SqlParameter("@VitaminK1", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminK1"].Value = product.ProductMicronutrients.Quantity("Vitamin K1");

                cmd.Parameters.Add(new SqlParameter("@VitaminB6", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB6"].Value = product.ProductMicronutrients.Quantity("Vitamin B6");

                cmd.Parameters.Add(new SqlParameter("@VitaminB12", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB12"].Value = product.ProductMicronutrients.Quantity("Vitamin B12");

                cmd.Parameters.Add(new SqlParameter("@VitaminA", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminA"].Value = product.ProductMicronutrients.Quantity("Vitamin A");

                cmd.Parameters.Add(new SqlParameter("@PantothenicAcid", SqlDbType.VarChar, 255));
                cmd.Parameters["@PantothenicAcid"].Value = product.ProductMicronutrients.Quantity("Pantothenic Acid");

                cmd.Parameters.Add(new SqlParameter("@Thiamin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Thiamin"].Value = product.ProductMicronutrients.Quantity("Thiamin");

                cmd.Parameters.Add(new SqlParameter("@Riboflavin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Riboflavin"].Value = product.ProductMicronutrients.Quantity("Riboflavin");

                cmd.Parameters.Add(new SqlParameter("@Niacin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Niacin"].Value = product.ProductMicronutrients.Quantity("Niacin");

                cmd.Parameters.Add(new SqlParameter("@Folate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Folate"].Value = product.ProductMicronutrients.Quantity("Folate");

                cmd.Parameters.Add(new SqlParameter("@Carotene", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carotene"].Value = product.ProductMicronutrients.Quantity("Carotene");

                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 128));
                cmd.Parameters["@UserId"].Value = userId;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UpdateProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = product.Code;

                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                cmd.Parameters["@Name"].Value = product.Name;

                cmd.Parameters.Add(new SqlParameter("@Calories", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calories"].Value = product.ProductMacronutrients.Quantity("Calories");

                cmd.Parameters.Add(new SqlParameter("@Protein", SqlDbType.VarChar, 255));
                cmd.Parameters["@Protein"].Value = product.ProductMacronutrients.Quantity("Protein");

                cmd.Parameters.Add(new SqlParameter("@Carbohydrate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carbohydrate"].Value = product.ProductMacronutrients.Quantity("Carbohydrates");

                cmd.Parameters.Add(new SqlParameter("@TotalSugars", SqlDbType.VarChar, 255));
                cmd.Parameters["@TotalSugars"].Value = product.ProductMacronutrients.Quantity("Total Sugars");

                cmd.Parameters.Add(new SqlParameter("@Fat", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fat"].Value = product.ProductMacronutrients.Quantity("Fat");

                cmd.Parameters.Add(new SqlParameter("@Alcohol", SqlDbType.VarChar, 255));
                cmd.Parameters["@Alcohol"].Value = product.ProductMacronutrients.Quantity("Alcohol");

                cmd.Parameters.Add(new SqlParameter("@Fibre", SqlDbType.VarChar, 255));
                cmd.Parameters["@Fibre"].Value = product.ProductMacronutrients.Quantity("Fibre");

                cmd.Parameters.Add(new SqlParameter("@Calcium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Calcium"].Value = product.ProductMicronutrients.Quantity("Calcium");

                cmd.Parameters.Add(new SqlParameter("@Sodium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Sodium"].Value = product.ProductMicronutrients.Quantity("Sodium");

                cmd.Parameters.Add(new SqlParameter("@Potassium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Potassium"].Value = product.ProductMicronutrients.Quantity("Potassium");

                cmd.Parameters.Add(new SqlParameter("@Magnesium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Magnesium"].Value = product.ProductMicronutrients.Quantity("Magnesium");

                cmd.Parameters.Add(new SqlParameter("@Iron", SqlDbType.VarChar, 255));
                cmd.Parameters["@Iron"].Value = product.ProductMicronutrients.Quantity("Iron");

                cmd.Parameters.Add(new SqlParameter("@Copper", SqlDbType.VarChar, 255));
                cmd.Parameters["@Copper"].Value = product.ProductMicronutrients.Quantity("Copper");

                cmd.Parameters.Add(new SqlParameter("@Zinc", SqlDbType.VarChar, 255));
                cmd.Parameters["@Zinc"].Value = product.ProductMicronutrients.Quantity("Zinc");

                cmd.Parameters.Add(new SqlParameter("@Manganese", SqlDbType.VarChar, 255));
                cmd.Parameters["@Manganese"].Value = product.ProductMicronutrients.Quantity("Manganese");

                cmd.Parameters.Add(new SqlParameter("@Phosphorus", SqlDbType.VarChar, 255));
                cmd.Parameters["@Phosphorus"].Value = product.ProductMicronutrients.Quantity("Phosphorus");

                cmd.Parameters.Add(new SqlParameter("@Selenium", SqlDbType.VarChar, 255));
                cmd.Parameters["@Selenium"].Value = product.ProductMicronutrients.Quantity("Selenium");

                cmd.Parameters.Add(new SqlParameter("@VitaminD", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminD"].Value = product.ProductMicronutrients.Quantity("Vitamin D");

                cmd.Parameters.Add(new SqlParameter("@VitaminC", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminC"].Value = product.ProductMicronutrients.Quantity("Vitamin C");

                cmd.Parameters.Add(new SqlParameter("@VitaminE", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminE"].Value = product.ProductMicronutrients.Quantity("Vitamin E");

                cmd.Parameters.Add(new SqlParameter("@VitaminK1", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminK1"].Value = product.ProductMicronutrients.Quantity("Vitamin K1");

                cmd.Parameters.Add(new SqlParameter("@VitaminB6", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB6"].Value = product.ProductMicronutrients.Quantity("Vitamin B6");

                cmd.Parameters.Add(new SqlParameter("@VitaminB12", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminB12"].Value = product.ProductMicronutrients.Quantity("Vitamin B12");

                cmd.Parameters.Add(new SqlParameter("@VitaminA", SqlDbType.VarChar, 255));
                cmd.Parameters["@VitaminA"].Value = product.ProductMicronutrients.Quantity("Vitamin A");

                cmd.Parameters.Add(new SqlParameter("@PantothenicAcid", SqlDbType.VarChar, 255));
                cmd.Parameters["@PantothenicAcid"].Value = product.ProductMicronutrients.Quantity("Pantothenic Acid");

                cmd.Parameters.Add(new SqlParameter("@Thiamin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Thiamin"].Value = product.ProductMicronutrients.Quantity("Thiamin");

                cmd.Parameters.Add(new SqlParameter("@Riboflavin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Riboflavin"].Value = product.ProductMicronutrients.Quantity("Riboflavin");

                cmd.Parameters.Add(new SqlParameter("@Niacin", SqlDbType.VarChar, 255));
                cmd.Parameters["@Niacin"].Value = product.ProductMicronutrients.Quantity("Niacin");

                cmd.Parameters.Add(new SqlParameter("@Folate", SqlDbType.VarChar, 255));
                cmd.Parameters["@Folate"].Value = product.ProductMicronutrients.Quantity("Folate");

                cmd.Parameters.Add(new SqlParameter("@Carotene", SqlDbType.VarChar, 255));
                cmd.Parameters["@Carotene"].Value = product.ProductMicronutrients.Quantity("Carotene");


                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void DeleteProduct(string code)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DeleteProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                cmd.Parameters["@Code"].Value = code;

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        private string GenerateCode(int userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetCustomProductCount", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                command.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            DataRow row = dataTable.Rows[0];
            int count = Convert.ToInt32(row["ProductCount"]);
            count++;

            return "99-" + userId.ToString() + "-" + count.ToString();
        }



        private string GenerateCode(string userId)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetCustomProductCount", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar));
                command.Parameters["@userId"].Value = userId;

                var da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            DataRow row = dataTable.Rows[0];
            int count = Convert.ToInt32(row["ProductCount"]);
            count++;


            return "99-" + "-" + count.ToString();
        }


        public DataTable GetProduct(string code)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetProduct", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 255));
                command.Parameters["@Code"].Value = code;

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dataTable);
            }

            return dataTable;
        }

        private DataTable CreateCodeTable(IEnumerable<FoodItem> foodItems)
        {
            var table = new DataTable();
            table.Columns.Add("Food Code", typeof(String));
            foreach (FoodItem foodItem in foodItems)
            {
                table.Rows.Add(foodItem.Code);
            }
            return table;
        }

    }
}
