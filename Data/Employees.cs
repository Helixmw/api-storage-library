using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StorageLibrary.DTOs.Employees;
using StorageLibrary.Interfaces;
using StorageLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibrary.Data
{
    public class Employees
    {
        private ApplicationDBContext dbContext;
    public Department Department {  get; set; }
        public Employees(ApplicationDBContext applicationDBContext)
        {
          dbContext = applicationDBContext;
        }

        public async Task<bool> AddAsync(AddEmployeeDTO Value)
        {
            var employee = new Employee()
            {
                Name = Value.Name,
                Email = Value.Email,
                Address = Value.Address,
            };
                var res = await this.dbContext.Employees.AddAsync(employee);
                return true;
            
           
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
                return (IEnumerable<Employee>)await dbContext.Employees.ToListAsync();                 
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
                return await this.dbContext.Employees.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
             var emp = await this.dbContext.Employees.Where(x => x.Id == employee.Id).FirstAsync();
             emp = employee;
             var res = dbContext.Employees.Update(emp);
             await dbContext.SaveChangesAsync();
             return true;           
        }

        public async Task<bool> DeleteAsync(int id)
        {
         var res = await dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            dbContext.Employees.Remove(res);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignDepartmentAsync(Employee employee, int deptId)
        {
                   var emp = await dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
                    emp.DepartmentId = deptId;
                    dbContext.Employees.Update(emp);
                    await dbContext.SaveChangesAsync();
            return true;

         }
            
         
        
    }
}
