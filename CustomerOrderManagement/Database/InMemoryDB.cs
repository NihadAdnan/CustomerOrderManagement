using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.Database
{
    public static class InMemoryDB
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Product> Products { get; set; } = new List<Product>();
    }
}
