using Abnoan.Data.Model;

namespace Abnoan.Data.Repository
{
    public class UserRepository
    {
        private static List<User> _users = new List<User>();

        public List<User> GetAll()
        {
            return new List<User>(_users);
        }

        public User Get(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
            }
        }

        public void Delete(int id)
        {
            _users.RemoveAll(u => u.Id == id);
        }
    }
}
