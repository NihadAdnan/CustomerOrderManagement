using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models.ViewModels.Products
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double UnitPrice { get; set; }
    }
}
