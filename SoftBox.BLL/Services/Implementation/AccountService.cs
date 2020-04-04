using SoftBox.BLL.Services.Interfaces;
using SoftBox.DAL.UnitOfWork;

namespace SoftBox.BLL.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
