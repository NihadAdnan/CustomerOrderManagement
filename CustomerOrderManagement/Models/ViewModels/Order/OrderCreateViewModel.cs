using CustomerOrderManagement.Models.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderManagement.Models.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
