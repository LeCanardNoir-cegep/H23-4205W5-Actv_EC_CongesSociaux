using CongesSociaux_Web.Data.Repository;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Models.ViewModels;
using CongesSociaux_Web.Services.Interfaces;

namespace CongesSociaux_Web.Services
{
    public class DepartementControllerService : AbstractControllerServices, IDepartementControllerService
    {
        public DepartementControllerService(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public async Task Create(DepartementVM vm)
        {
            await _unitOfWork.Departements.AddAsync(
                new Departement { 
                    Id = vm.Id, 
                    Name = vm.Name, 
                    Code = vm.Code 
                });

            _unitOfWork.save();
        }

        public Task Delete(int id, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Departement?> Details(int id)
        {
            return await _unitOfWork.Departements.GetFirstOrDefaultAsync( d => d.Id == id );
        }

        public async Task<IEnumerable<DepartementVM>?> Index()
        {
            var data = await _unitOfWork.Departements.GetAllAsync();
            List<DepartementVM> vm = new List<DepartementVM>();
            foreach (var item in data)
            {
                vm.Add(new DepartementVM { Id = item.Id, Name= item.Name, Code = item.Code });
            }
            return vm;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _unitOfWork.Departements.GetFirstOrDefaultAsync(x => x.Id == id) != null;
        }

        public Task<Departement> Update(Departement model)
        {
            throw new NotImplementedException();
        }
    }
}
