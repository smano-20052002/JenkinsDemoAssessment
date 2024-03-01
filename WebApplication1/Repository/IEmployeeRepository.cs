using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        Employee Add(Employee employee);
        void Remove(int id);
        bool Update(Employee employee);
    }
}
