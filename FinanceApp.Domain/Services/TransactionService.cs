
using FinanceApp.Domain.Interfaces;
using FinanceApp.Domain.Entities;

namespace FinanceApp.Domain.Services
{
    public class TransactionService : IRepository<Transaction>
    {
        User User = new User();
        public TransactionService(User user)
        {
            User = user;
        }
        public void Add(Transaction entity)
        {

            if (User.Transactions.Any(t => t.Id == entity.Id))
            {
                throw new System.Exception("Transação já cadastrada");
            }

            User.Transactions.Add(entity);
        }


        public IEnumerable<Transaction> GetAll()
        {
            return User.Transactions;
        }

        public void Update(Transaction entity)
        {
            var existing = User.Transactions.FirstOrDefault(t => t.Id == entity.Id);
            if (existing != null)
            {
                existing.Amount = entity.Amount;
                existing.Date = entity.Date;
                existing.Category = entity.Category;
            }
        }

        public void Delete(Transaction entity)
        {
            User.Transactions.RemoveAll(t => t.Id == entity.Id);
        }
    }
}
