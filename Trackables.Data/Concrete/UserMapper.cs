using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Concrete
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
