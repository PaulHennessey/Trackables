using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IUserMapper
    {
        IEnumerable<User> HydrateUsers(DataTable dataTable);
    }
}
