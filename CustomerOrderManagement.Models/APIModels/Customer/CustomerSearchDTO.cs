using CustomerOrderManagement.Models.EntityModels;

namespace CustomerOrderManagement.Models.APIModels.Customer
{
    public class CustomerSearchDTO
    {
        public string? FilterText {  get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
