using CustomerOrderManagement.Models.CustomValidators;
using CustomerOrderManagement.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models.ViewModels.Customers
{
    public class CustomerCreateViewModel
    {

        [Required(ErrorMessage ="Please provide Name!")]
        public string Name { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [AddressValidation(ErrorMessage ="Address is not correct!", AddressLocation ="Dhaka")]
        public string? Address { get; set; }

        public List<Customer>? Customers { get; set; }

       
    }
}
