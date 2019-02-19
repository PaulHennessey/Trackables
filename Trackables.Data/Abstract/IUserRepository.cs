using System.Data;

namespace Trackables.Data.Abstract
{
    public interface IUserRepository
    {
        DataTable GetUser(string code);
    }
}
