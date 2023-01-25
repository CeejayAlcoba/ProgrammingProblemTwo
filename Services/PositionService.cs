using Domain;
using Domain.Interfaces;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Position> GetAllPosition()
        {
            return _unitOfWork.Positions.GetAll().Where(c=>c.positionId!=1);
        }
    }
}
