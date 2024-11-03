using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderManagement.Models.EntityModels
{
    public class Customer:IEntity
    {
        public Customer()
        {

        }
        public Customer(string name, string phone, string address)
        {
            Name = name;
            PhoneNo = phone;
            Address = address;
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }
        
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public int CategoryId { get; set; }

        public CustomerCategory Category { get; set; }



    }
}
