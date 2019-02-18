using MyFoodDiary.Domain;

namespace MyFoodDiary.Services.Abstract
{
    public interface IUserServices
    {
        User GetUser(string email);
    }
}
