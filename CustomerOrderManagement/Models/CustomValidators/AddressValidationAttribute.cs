using System.ComponentModel.DataAnnotations;

namespace CustomerOrderManagement.Models.CustomValidators
{
    public class AddressValidationAttribute : ValidationAttribute
    {
        public string AddressLocation { get; set; }

        public override bool IsValid(object? value)
        {

            
            return true; 
            
        }

    }
}
