using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();
        private int _nextId = 1;
        public EmployeeRepository()
        {
            Add(new Employee { EmpId = 1, Name = "Mano", Designation = "Developer", Salary = 15000 });
            Add(new Employee { EmpId = 2, Name = "Kumar", Designation = "Developer", Salary = 15000 });

        }
        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public Employee Get(int id)
        {
            return employees.Find(p => p.EmpId == id);
        }

        public Employee Add(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("item");
            }
            employee.EmpId = _nextId++;
            employees.Add(employee);
            return employee;
        }

        public void Remove(int id)
        {
            employees.RemoveAll(p => p.EmpId == id);
        }
        public bool Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = employees.FindIndex(p => p.EmpId == employee.EmpId);
            if (index == -1)
            {
                return false;
            }
            employees.RemoveAt(index);
            employees.Add(employee);
            return true;
        }
    }
}
