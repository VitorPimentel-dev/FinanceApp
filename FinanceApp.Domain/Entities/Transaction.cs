using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Categorie Category { get; set; }

        public Transaction(double amount, DateTime date, Categorie category)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Date = date;
            Category = category;
        }
    }
}