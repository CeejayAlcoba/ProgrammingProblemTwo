using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProblemTwo.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IUnitOfWork unitOfWork,IEmployeeService employeeService)
        {
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            try
            {
                var result = _employeeService.AddEmployee(employee);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var result = _employeeService.GetAllEmployee();
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody]Employee employee)
        {
            try
            {
                var result = _employeeService.UpdateEmployee(employee);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
