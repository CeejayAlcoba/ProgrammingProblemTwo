using DataAccessEfCore.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Credentials = new CredentialRepository(_context);
            Employees = new EmployeeRepository(_context);
            Positions = new PositionRepository(_context);
        }
        public ICredentialRepository Credentials { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IPositionRepository Positions { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
