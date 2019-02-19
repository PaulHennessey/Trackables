using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IUserServices
    {
        User GetUser(string email);
    }
}
