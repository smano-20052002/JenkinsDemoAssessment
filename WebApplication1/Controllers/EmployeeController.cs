using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static readonly IEmployeeRepository repository = new EmployeeRepository();

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return repository.GetAll();
        }
        [HttpGet("id")]
        public Employee GetEmployees(int id)
        {
            Employee employee = repository.Get(id);
            if (employee == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;

            }
            return employee;
        }

        [HttpGet("Designation")]
        public IEnumerable<Employee> GetByEmployee(string Designation)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Designation, Designation, StringComparison.OrdinalIgnoreCase));
        }
        [HttpPost]
        public ActionResult PostEmployee(Employee item)
        {
            repository.Add(item);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Employee employee)
        {
            if (id != employee.EmpId)
                return BadRequest();
            else
                repository.Update(employee);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           
            repository.Remove(id);
            return Ok();
        }



    }
}
