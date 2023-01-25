using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AccountService(IUnitOfWork unitOfWork
            , IConfiguration config
            )
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }
        public string AccountLogin(Credential credential)
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
                return GenerateJSONWebToken(getEmployeeByUsername);
            }
            else return null;
        }
        public string GenerateJSONWebToken(Employee employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim("id", employee.employeeId.ToString()),
        new Claim("firstname", employee.firstname),
        new Claim("lastname", employee.lastname),
        new Claim("gender", employee.gender),
        new Claim("birthday", employee.birthday.ToString()),
        new Claim("username", employee.credential.username),
        new Claim("position", employee.position.type)
    };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
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
