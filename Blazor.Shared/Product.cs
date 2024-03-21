using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string? ProductName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter Product Price")]
        public decimal? ProductPrice { get; set; }=decimal.Zero;
        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public decimal? ProductQty { get; set; } 
        public int CustomerId { get; set; }
      
    }
}
