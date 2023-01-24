using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICredentialRepository Credentials { get; }
        IEmployeeRepository Employees { get; }
        IPositionRepository Positions { get; }
        int Complete();
    }
}
