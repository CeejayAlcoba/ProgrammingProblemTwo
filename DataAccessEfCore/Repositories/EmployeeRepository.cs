using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var employee = _context.Employees
                .Where(
                emp => emp.credential.username == username)
                .AsQueryable()
                .Include(x=>x.credential)
                .Include(x=>x.position);
            return employee.FirstOrDefault();
        }
        public IEnumerable<Employee> GetEmployee()
        {
            var employee = _context.Employees
                .AsQueryable()
                .Include(x => x.credential)
                .Include(x => x.position);
            return employee;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees
                .AsQueryable()
                .Where(c=>c.employeeId==id)
                .Include(x => x.credential)
                .Include(x => x.position);
            return employee.FirstOrDefault();
        }
    }
}
