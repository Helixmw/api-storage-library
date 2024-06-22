using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Interfaces
{
    public interface IPersonalInfo
    {
        int Id { get; set; }

        string Name { get; set; }

        public string Email { get; set; }

        string Address { get; set; }
    }
}
