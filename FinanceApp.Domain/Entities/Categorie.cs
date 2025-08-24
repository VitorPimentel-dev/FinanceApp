namespace FinanceApp.Domain.Entities
{
    public class Categorie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public Categorie(string name, string type)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
        }
        public void UpdateName(string newName)
        {
            Name = newName;
        }
    }
}
