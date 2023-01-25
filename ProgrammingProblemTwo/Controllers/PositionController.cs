using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProblemTwo.Controllers
{
    [Route("api/position")]
    [ApiController]
    [Authorize]
    public class PositionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPositionService _positionService;
        public PositionController(IUnitOfWork unitOfWork, IPositionService positionService)
        {
            _unitOfWork = unitOfWork;
            _positionService = positionService;
        }
        [HttpGet]
        public IActionResult GetAllPosition()
        {
            var allPosition = _positionService.GetAllPosition();
            return Ok(allPosition);

        }
    }
}
