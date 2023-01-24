using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Services.Interface;
using System;
using System.Security.Cryptography;


namespace Services
{
    public class AccountService :IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Employee AccountLogin(Credential credential)
        {
            var getEmployeeByUsername =
                _unitOfWork
                .Employees
                .GetEmployeeByUsername(credential.username);
            var hashedInputedPasword =
                GenerateHashPassword(credential.password
                , getEmployeeByUsername.credential.salted);
            if (getEmployeeByUsername != null
                && getEmployeeByUsername.credential.hashed
                == hashedInputedPasword)
            {
                return getEmployeeByUsername;
            }
            else return null;
        }
        public byte[] GenerateSalt(string password)
        {
            var salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public string GenerateHashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }

    }
}
