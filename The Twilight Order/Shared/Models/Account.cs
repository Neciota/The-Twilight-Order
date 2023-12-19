namespace TheTwilightOrder.Shared.Models
{
    public class Account
    {
        public Account(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
