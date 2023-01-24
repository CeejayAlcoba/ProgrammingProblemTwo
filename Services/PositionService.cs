using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Position> GetAllPosition()
        {
            return _unitOfWork.Positions.GetAll();
        }
    }
}
