namespace ComputerWebApi.Models
{
    public class Product_VM
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }

    public class Product : Product_VM
    {
        public Guid Id { get; set; }
    }
}
