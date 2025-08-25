using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Interfaces;

namespace FinanceApp.Domain.Services
{
    public class CategorieService : IRepository<Categorie>
    {
        User User = new User();
        public CategorieService(User user)
        {
            User = user;
        }
        public void Add(Categorie entity)
        {
            User.AddCategory(entity);
        }

        public IEnumerable<Categorie> GetAll()
        {
            return User.Categories;
        }

        public void Update(Categorie entity)
        {
            var index = User.Categories.FindIndex(c => c.Id == entity.Id);
            if (index != -1)
            {
                User.Categories[index] = entity;
            }
        }

        public void Delete(Categorie entity)
        {
            User.Categories.RemoveAll(c => c.Id == entity.Id);
        }
    }
}
