using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Employee GetEmployeeByUsername(string username);
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int id);
    }
}
