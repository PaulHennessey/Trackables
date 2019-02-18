using System.Data;

namespace MyFoodDiary.Data.Abstract
{
    public interface IUserRepository
    {
        DataTable GetUser(string code);
    }
}
