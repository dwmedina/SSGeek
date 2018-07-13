using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSGeek.Web.Models
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public decimal SubTotal => Quantity * Product.Cost;

    }
}
