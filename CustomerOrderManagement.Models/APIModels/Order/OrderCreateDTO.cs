namespace CustomerOrderManagement.Models.APIModels.Order
{
    public class OrderCreateDTO
    {
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
