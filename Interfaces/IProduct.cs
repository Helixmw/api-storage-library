using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Interfaces
{
    public interface IProduct
    {
       
        int ProductId { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        double Price { get; set; }
    }
}
