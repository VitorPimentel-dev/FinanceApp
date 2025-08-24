using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Interfaces;

namespace FinanceApp.Domain.Services
{
    public class UserService : IRepository<User>
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User entity)
        {
            if (_users.Any(u => u.Email == entity.Email))
                throw new System.Exception("Email já cadastrado");

            _users.Add(entity);
        }

        public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email)!;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Update(User entity)
        {
            var existing = _users.FirstOrDefault(u => u.Id == entity.Id);
            if (existing != null)
            {
                existing.Email = entity.Email;
                existing.Senha = entity.Senha;
            }
        }

        public void Delete(User entity)
        {
            _users.RemoveAll(u => u.Id == entity.Id);
        }
    }
}
