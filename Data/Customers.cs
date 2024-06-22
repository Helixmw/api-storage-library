using Microsoft.EntityFrameworkCore;
using StorageLibrary.Interfaces;
using StorageLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Data
{
    public class Customers : IOperations<Customer>
    {

        private ApplicationDBContext _dbContext;

        public Customers(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        public async Task<bool> AddAsync(Customer Value)
        {
                await _dbContext.Customers.AddAsync(Value);
                return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
  
                var customer = await _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefaultAsync();
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
      
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
                var customers = await _dbContext.Customers.ToListAsync();
                return (IEnumerable<Customer>)customers;          
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
                var customer = await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
                return customer;        
        } 

        public async Task<bool> UpdateAsync(Customer custom)
        {      
              var customer = await GetByIdAsync(custom.Id);
               _dbContext.Customers.Update(customer);
               await _dbContext.SaveChangesAsync();
               return true;
           
        }

        public async Task<bool> AssignOrderAsync(Order order)
        {
                await _dbContext.Orders.AddAsync(order);
                return true;     
        }

        public async Task<bool> RemoveOrderAsync(Order order)
        {
            var _order = await _dbContext.Orders.Where(x => x.OrderId == order.OrderId).FirstOrDefaultAsync();
                _dbContext.Orders.Remove(_order);
                await _dbContext.SaveChangesAsync();
                return true;
        }
    }
}
