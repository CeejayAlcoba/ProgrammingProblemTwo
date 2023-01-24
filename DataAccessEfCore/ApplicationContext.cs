using Domain;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace DataAccessEfCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Position>()
                .HasData(
                 ModelBuilderExtensions.NewPosition(1, "Admin"),
                 ModelBuilderExtensions.NewPosition(2, "Manager"),
                 ModelBuilderExtensions.NewPosition(3, "Supervisor"),
                 ModelBuilderExtensions.NewPosition(4, "Staff")
                ); ;

            modelBuilder.Entity<Credential>().HasData(
                ModelBuilderExtensions.newCredetial(1,"admin","admin")
                ); 
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    employeeId = 1,
                    positionId = 1,
                    credentialId = 1,
                }
                ); ; 
        }
        public static class ModelBuilderExtensions
        {
            public static Position NewPosition(int id, string type)
            {
                var newPosition = new Position()
                {
                    positionId = id,
                    type = type
                };
                return newPosition;
            }
            public static Credential newCredetial(int id
                ,string username
                ,string password)
            {
                var toSalt = GenerateSalt(password);
                var toHash = GenerateHashPassword(password, toSalt);
                var newCredential = new Credential()
                {
                    credentialId = id,
                    username = username,
                    salted = toSalt,
                    hashed = toHash
                };
                return newCredential;
            }
            public static byte[] GenerateSalt(string password)
            {
                var salt = new byte[128 / 8];

                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                return salt;
            }
            public static string GenerateHashPassword(string password, byte[] salt)
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


}
