using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
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
