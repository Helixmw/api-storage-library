using Microsoft.EntityFrameworkCore;
using StorageLibrary.DTOs.Employees;
using StorageLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Interfaces
{
    public interface IOperations<T>
    {
        Task<bool> AddAsync(T Value);


        Task<T> GetByIdAsync(int id);


        Task<IEnumerable<T>> GetAllAsync();


        Task<bool> UpdateAsync(T department);


        Task<bool> DeleteAsync(int Id);
       
    }
}
