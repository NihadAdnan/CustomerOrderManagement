using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderManagement.Models.EntityModels
{
    public class CustomerAccountBalance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer customer { get; set; }  
        public double Balance { get; set; }
    }
}
