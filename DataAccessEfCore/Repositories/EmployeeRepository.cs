using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEfCore.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return _context.Employees.Where(
                emp => emp.credential.username == username)
                .FirstOrDefault();
        }
    }
}
