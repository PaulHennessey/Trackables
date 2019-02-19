using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IUserMapper
    {
        IEnumerable<User> HydrateUsers(DataTable dataTable);
    }
}
