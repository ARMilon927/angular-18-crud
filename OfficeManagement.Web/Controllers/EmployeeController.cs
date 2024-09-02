using Microsoft.AspNetCore.Mvc;
using OfficeManagement.Web.Model;
using OfficeManagement.Web.Repository.Interface;

namespace OfficeManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _employeeService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _employeeService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Employee employee)
        {
            try
            {
                await _employeeService.Add(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{empId}")]
        public async Task<IActionResult> Delete(int empId)
        {
            try
            {
                await _employeeService.Delete(empId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{empId}")]
        public async Task<IActionResult> Update(int empId, Employee employee)
        {
            try
            {
                employee.Id = empId;
                await _employeeService.Update(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
