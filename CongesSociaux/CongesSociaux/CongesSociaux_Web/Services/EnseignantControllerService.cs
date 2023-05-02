using CongesSociaux_Web.Data.Repository.IRepository;

namespace CongesSociaux_Web.Services
{
    public class EnseignantControllerService : AbstractControllerServices, IEnseignantControllerService
    {
        public EnseignantControllerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task Create(EnseignantVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<Enseignant> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EnseignantVM?> Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EntityIsEmpty()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EnseignantVM>?> Index()
        {
            var test = await _unitOfWork.Enseignants.GetAllAsync();
            var data = (await _unitOfWork.Enseignants.GetAllAsync(includedProperties: "Departement")).Select( e => new EnseignantVM {
                Id = e.Id,
                Prenom = e.Prenom,
                Nom = e.Nom,
                DateEmbauche = e.DateEmbauche,
                DepartementId = e.DepartementId,
                Departement = e.Departement,
                Specialite = e.Specialite
            }).ToList();
            return data;
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EnseignantVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
