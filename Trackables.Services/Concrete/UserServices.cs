using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Services.Abstract;

namespace MyFoodDiary.Services.Concrete
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserServices()
        { }

        public UserServices(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public User GetUser(string email)
        {
            DataTable dataTable = _userRepository.GetUser(email);
            return _userMapper.HydrateUsers(dataTable).First();
        }
    }
}
