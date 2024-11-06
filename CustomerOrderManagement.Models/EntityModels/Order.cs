using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Models.EntityModels
{
    public class Order:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderedOn { get; set; }
        public double TotalAmount {  get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId {  get; set; }
        public Customer customer { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId {  get; set; }
        public Product product { get; set; }
    }
}
