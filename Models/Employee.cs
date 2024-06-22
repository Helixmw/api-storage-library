using Microsoft.EntityFrameworkCore;
using StorageLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorageLibrary.Models
{
    public class Employee : IPersonalInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; } 
        public Department? Department { get; set; }    
       
    }
}
