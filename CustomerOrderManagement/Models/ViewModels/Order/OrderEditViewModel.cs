using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models.ViewModels.Order
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
