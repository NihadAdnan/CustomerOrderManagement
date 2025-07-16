using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Models.EntityModels
{
    public class CompanyAccountBalance
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}
