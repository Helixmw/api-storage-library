using StorageLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Models
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]  
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
