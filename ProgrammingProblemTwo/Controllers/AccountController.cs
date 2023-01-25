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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        public AccountController(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult LoginEmployee([FromBody] Credential credential)
        {
            try
            {
                var token = _accountService.AccountLogin(credential);
                if (token != null)
                {
                    return Ok(token);
                }
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
