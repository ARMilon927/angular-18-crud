using OfficeManagement.Web.Model;

namespace OfficeManagement.Web.Repository.Interface
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<Employee> GetById(int employeeId);
        Task<List<Employee>> GetAll();
        Task Update(Employee employee);
        Task Delete(int employeeId);
    }
}
