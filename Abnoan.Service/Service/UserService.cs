using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abnoan.Business.Model;
using Abnoan.Data.Model;
using Abnoan.Data.Repository;

namespace Abnoan.Business.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.ConvertAll(user => ToDto(user));
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.Get(id);
            return user != null ? ToDto(user) : null;
        }

        public void AddUser(UserDto userDto)
        {
            var user = ToEntity(userDto);
            _userRepository.Add(user);
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = ToEntity(userDto);
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        private UserDto ToDto(User user)
        {
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email };
        }

        private User ToEntity(UserDto userDto)
        {
            return new User { Id = userDto.Id, Name = userDto.Name, Email = userDto.Email };
        }
    }

}
