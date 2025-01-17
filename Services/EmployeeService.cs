﻿using Domain;
using Domain.Interfaces;
using Services.Interface;
using System.Collections.Generic;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountInterface;
        public EmployeeService(IUnitOfWork unitOfWork
            , IAccountService accountInterface)
        {
            _unitOfWork = unitOfWork;
            _accountInterface = accountInterface;
        }
        public string AddEmployee(Employee employee)
        {
            var getEmployeeByUsername = _unitOfWork
                .Employees
                .GetEmployeeByUsername(employee.credential.username);
            if (getEmployeeByUsername == null)
            {
                var toSalt = _accountInterface
                    .GenerateSalt(employee.credential.password);
                var toHash = _accountInterface
                    .GenerateHashPassword(employee.credential.password
                    , toSalt);
                var newCredential = new Credential()
                {
                    username = employee.credential.username,
                    salted = toSalt,
                    hashed = toHash
                };
                var newEmployee = new Employee()
                {
                    firstname = employee.firstname,
                    lastname = employee.lastname,
                    gender = employee.gender,
                    birthday = employee.birthday,
                    positionId = employee.positionId,
                    credential = newCredential
                };
                _unitOfWork.Employees.Add(newEmployee);
                _unitOfWork.Complete();
                var token = _accountInterface.AccountLogin(employee.credential);
                return token;
            }
            else
            {
                return null;
            }

        }
        public Employee UpdateEmployee(Employee employee)
        {
            var getEmployeeById = _unitOfWork.Employees.GetEmployeeById(employee.employeeId);
            getEmployeeById.firstname = employee.firstname;
            getEmployeeById.lastname = employee.lastname;
            getEmployeeById.gender = employee.gender;
            getEmployeeById.birthday = employee.birthday;
            getEmployeeById.positionId = employee.positionId;
            getEmployeeById.credential.username = employee.credential.username;
            if (employee.credential.password != null)
            {
                var toSalt = _accountInterface.GenerateSalt(
                    employee.credential.password
                    );
                var toHash = _accountInterface.GenerateHashPassword(
                    employee.credential.password,
                    toSalt
                    );

                getEmployeeById.credential.salted = toSalt;
                getEmployeeById.credential.hashed = toHash;
            }
            _unitOfWork.Complete();
            return getEmployeeById;

        }
        public void DeleteEmployee(int id)
        {

            var employee = _unitOfWork.Employees.GetEmployeeById(id);
            var credential = _unitOfWork.Credentials.GetById(employee.credentialId);
            _unitOfWork.Employees.Remove(employee);
            _unitOfWork.Credentials.Remove(credential);
            _unitOfWork.Complete();
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            var allEmployees = _unitOfWork.Employees.GetEmployee();
            return allEmployees;
        }

    }
}
