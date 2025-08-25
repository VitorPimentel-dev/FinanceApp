using System;
using System.Linq;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Services;

class Program
{
    static void Main()
    {
        var userService = new UserService();

        Console.WriteLine("Digite 'login' para entrar ou 'cadastro' para criar um usuário:");
        var opcao = Console.ReadLine()?.ToLower();

        if (opcao == "cadastro")
        {
            Console.WriteLine("Digite o email do usuário:");
            string email = Console.ReadLine()!;
            Console.WriteLine("Digite a senha do usuário:");
            string password = Console.ReadLine()!;

            if (userService.GetByEmail(email) != null)
            {
                Console.WriteLine("Email já cadastrado.");
                return;
            }

            var user = new User(email, password);
            userService.Add(user);
            Console.WriteLine($"Usuário {user.Email} cadastrado com sucesso!");
        }

        // Login
        Console.WriteLine("Digite o email do usuário:");
        string loginEmail = Console.ReadLine()!;
        Console.WriteLine("Digite a senha do usuário:");
        string loginPassword = Console.ReadLine()!;

        var loggedUser = userService.GetByEmail(loginEmail);
        if (loggedUser == null || !loggedUser.ValidatePassword(loginPassword))
        {
            Console.WriteLine("Usuário ou senha inválidos.");
            return;
        }

        Console.WriteLine($"Bem-vindo {loggedUser.Email}!");

        if (!loggedUser.Categories.Any())
        {
            var categoriaPadrao = new Categorie("Lazer", "Atividades de lazer e entretenimento");
            loggedUser.AddCategory(categoriaPadrao);
        }

        var transactionService = new TransactionService(loggedUser);

        Console.WriteLine("Digite o valor da transação:");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }
        System.Console.WriteLine("Digite o nome da categoria");
        var categoria = new Categorie(Console.ReadLine()!, "Categoria personalizada");
        loggedUser.AddCategory(categoria);
        var transaction = new Transaction(amount, DateTime.Now, categoria);
        transactionService.Add(transaction);

        Console.WriteLine("Transação adicionada com sucesso!\n");

        // Exibe usuário com transações
        Console.WriteLine(loggedUser);
    }
}
