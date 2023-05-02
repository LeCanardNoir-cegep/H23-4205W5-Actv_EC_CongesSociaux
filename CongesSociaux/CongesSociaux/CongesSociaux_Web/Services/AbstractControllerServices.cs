using CongesSociaux_Web.Data.Repository.IRepository;

namespace CongesSociaux_Web.Services
{
    public abstract class AbstractControllerServices
    {
        protected readonly IUnitOfWork _unitOfWork;

        public AbstractControllerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
