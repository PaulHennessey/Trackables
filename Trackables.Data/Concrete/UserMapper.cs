using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;

namespace Trackables.Data.Concrete
{
    public class UserMapper : IUserMapper
    {
        public IEnumerable<User> HydrateUsers(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows
                   select new User
                   {
                       Id = (int)row["UserId"],
                       Email = row["Email"].ToString(),
                       FirstName = row["FirstName"].ToString(),
                       LastName = row["LastName"].ToString(),
                   };
        }
    }
}
