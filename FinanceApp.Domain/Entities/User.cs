using System;
using System.Collections.Generic;
using FinanceApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<Categorie> Categories { get; set; } = new List<Categorie>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public User(string email, string senha)
    {
        Id = Guid.NewGuid();
        Email = email;
        Senha = senha;
    }
    public User()
    {
        Id = Guid.NewGuid();
        Email = string.Empty;
        Senha = string.Empty;
    }
    public bool ValidatePassword(string senha)
    {
        return Senha == senha;
    }
    public void UpdatePassword(string newSenha)
    {
        Senha = newSenha;
    }
    public void AddCategory(Categorie category)
    {
        Categories.Add(category);
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"ID: {Id}");
        sb.AppendLine($"Email: {Email}");
        sb.AppendLine($"Senha: {Senha}");
        sb.AppendLine("Categorias:");
        foreach (var category in Categories)
        {
            sb.AppendLine($" - {category.Name}");
        }

        sb.AppendLine("Transações:");
        foreach (var transaction in Transactions)
        {
            sb.AppendLine($" - {transaction.Category.Name} | Valor: {transaction.Amount} | Categoria: {transaction.Category.Name} | Data: {transaction.Date}");
        }

        return sb.ToString();
    }

}