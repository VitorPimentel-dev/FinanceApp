using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Services;

UserService userService = new UserService();
System.Console.WriteLine("Login/cadastro");
if (Console.ReadLine()!.ToLower() == "login")
{
    System.Console.WriteLine("Digite o email do usuario:");
    string email = Console.ReadLine()!;
    System.Console.WriteLine("Digite a senha do usuario:");
    string password = Console.ReadLine()!;
    var user = userService.GetByEmail(email);
    if (user == null || !user.ValidatePassword(password))
    {
        System.Console.WriteLine("Usuario ou senha inválidos.");
        return;
    }
    System.Console.WriteLine($"Bem vindo {user.Email}!");

    TransactionService transactionService = new TransactionService(user);
    System.Console.WriteLine("Digite o valor da transação:");
    double amount = double.Parse(Console.ReadLine()!);
    DateTime date = DateTime.Now;
    var transaction = new Transaction(amount, date, user.Categories.First());
    transactionService.Add(transaction);
    System.Console.WriteLine("Transação adicionada com sucesso!");
    System.Console.WriteLine(user);
}
else
{
    System.Console.WriteLine("Digite o email do usuario:");
    string email = Console.ReadLine()!;
    System.Console.WriteLine("Digite a senha do usuario:");
    string password = Console.ReadLine()!;
    userService.Add(new User(email, password));
    var user = userService.GetByEmail(email);
    System.Console.WriteLine($"Usuario {user.Email} cadastrado com sucesso!");
}
