using CongesSociaux_Web.Data.Repository;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.Interfaces;
using CongesSociaux_Web.ViewModels;

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

        public async Task Delete(int id, bool confirmed)
        {
            var departement = await _unitOfWork.Departements.GetFirstOrDefaultAsync(d => d.Id == id);
            if (departement != null)
            {
                var enseignants = await _unitOfWork.Enseignants.GetAllAsync();
                departement.Enseignants = null;
                foreach (var item in enseignants)
                {
                    item.DepartementId = null;
                }
                _unitOfWork.Enseignants.UpdateRange(enseignants);
                _unitOfWork.Departements.Update(departement);
                _unitOfWork.save();

                _unitOfWork.Departements.Remove(departement);
            }

            _unitOfWork.save();
        }

        public async Task<Departement> Delete(int id)
        {
            return await _unitOfWork.Departements.GetFirstOrDefaultAsync( d => d.Id == id );
        }

        public async Task<DepartementVM?> Details(int id)
        {
            var data = await _unitOfWork.Departements.GetFirstOrDefaultAsync(d => d.Id == id);
            DepartementVM vm = null;

            if(data != null)
            vm = new DepartementVM
            {
                Id = data.Id,
                Name = data.Name,
                Code = data.Code,
                Enseignants = data.Enseignants
            };

            return vm;
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

        public async Task Update(DepartementVM vm)
        {
            Departement data =  await _unitOfWork.Departements.GetFirstOrDefaultAsync( d => d.Id == vm.Id);
            if (data != null)
            {
                data.Code = vm.Code;
                data.Name = vm.Name;
                _unitOfWork.Departements.Update(data);
                _unitOfWork.save();
            }
        }

        public async Task<bool> EntityIsEmpty() => _unitOfWork.Departements == null;
    }
}
