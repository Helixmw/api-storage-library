using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } //Specifying "CustomerId"
        public Customer Customer { get; set; }

        public Order()
        {
            
        }

    }
}
