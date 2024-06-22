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
    public class Departments : IOperations<Department>
    {
        private ApplicationDBContext dbContext;

        public Departments(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }

        public async Task<bool> AddAsync(Department department)
        {
                await dbContext.Departments.AddAsync(department);
                return true;
        }

        public async Task<Department> GetByIdAsync(int id)
        {

                return await dbContext.Departments.Where(x => x.Id == id).FirstAsync(); 
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {

                return (IEnumerable<Department>)await dbContext.Departments.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Department department)
        {

                var res = await dbContext.Departments.Where(x => x.Id == department.Id).FirstOrDefaultAsync();
                res = department;
                dbContext.Departments.Update(res);
                await dbContext.SaveChangesAsync();
                return true;

        }

        public async Task<bool> DeleteAsync(int Id)
        {

                var res = await dbContext.Departments.Where(x => x.Id == Id).FirstOrDefaultAsync();
                this.dbContext.Remove(res);
                var users = await dbContext.Employees.Where(x => x.DepartmentId == Id).ToListAsync();
                foreach (var user in users)
                {
                    user.DepartmentId = null;
                }
                await dbContext.SaveChangesAsync();
                return true;

        }
    }
}
