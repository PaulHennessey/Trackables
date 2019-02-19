using System.Data;
using System.Data.SqlClient;
using Trackables.Data.Abstract;

namespace Trackables.Data.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetUser(string code)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("GetUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50));
                cmd.Parameters["@Email"].Value = code;

                var da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }

            return dataTable;
        }
    }
}
