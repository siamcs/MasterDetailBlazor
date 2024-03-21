using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string? CustomerName { get; set; } = string.Empty;
        public bool IsPaid { get; set; }=false;
        [Required(ErrorMessage = "Please select Picture")]
        public string? ImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Date")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
