using Microsoft.EntityFrameworkCore;
using OfficeManagement.Web.Model;
using OfficeManagement.Web.Repository.Context;
using OfficeManagement.Web.Repository.Interface;

namespace OfficeManagement.Web.Repository.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int employeeId)
        {
            Employee? emp = await _dbContext.Employees.Where(x=> x.Id == employeeId).FirstOrDefaultAsync();
            if (emp != null)
            {
                emp.IsDeleted = true;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employees.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _dbContext.Employees.Where(x => x.Id == employeeId).FirstOrDefaultAsync();
        }

        public async Task Update(Employee employee)
        {
            Employee? emp = await _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Address = employee.Address;
                emp.Phone = employee.Phone;
                emp.Email = employee.Email;
                _dbContext.Employees.Update(emp);
                await _dbContext.SaveChangesAsync();
            }            
        }
    }
}
