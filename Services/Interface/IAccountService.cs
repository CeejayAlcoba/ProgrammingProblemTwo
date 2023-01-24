using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAccountService
    {
        byte[] GenerateSalt(string password);
        string GenerateHashPassword(string password, byte[] salt);
        Employee AccountLogin(Credential credential);
    }
}
