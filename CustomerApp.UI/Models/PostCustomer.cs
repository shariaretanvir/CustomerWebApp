namespace CustomerApp.UI.Models
{
    public class PostCustomer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
