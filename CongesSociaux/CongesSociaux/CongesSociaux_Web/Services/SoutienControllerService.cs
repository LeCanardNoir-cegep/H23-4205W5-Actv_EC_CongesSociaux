using CongesSociaux_Web.Data.Repository;
using CongesSociaux_Web.Data.Repository.IRepository;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.Interfaces;
using CongesSociaux_Web.ViewModels;

namespace CongesSociaux_Web.Services
{
	public class SoutienControllerService : AbstractControllerServices, ISoutienControllerService
	{
		public SoutienControllerService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

		public async Task<IEnumerable<SoutienVM>?> Index()
		{
			IEnumerable<Soutien>? soutiens = await _unitOfWork.Soutiens.GetAllAsync();

			return soutiens.Select(s => new SoutienVM
			{
				Id = s.Id,
				Prenom = s.Prenom,
				Nom = s.Nom,
				DateEmbauche = s.DateEmbauche,
				Poste = s.Poste
			});
		}

		public async Task<SoutienVM?> Details(int id)
		{
			Soutien? soutien = await _unitOfWork.Soutiens.GetFirstOrDefaultAsync(s => s.Id == id);

			if (soutien == null)
				return null;

			return new SoutienVM
			{
				Id = soutien.Id,
				Prenom = soutien.Prenom,
				Nom = soutien.Nom,
				DateEmbauche = soutien.DateEmbauche,
				Poste = soutien.Poste
			};
		}

		public async Task Create(SoutienVM vm)
		{
			await _unitOfWork.Soutiens.AddAsync(new Soutien
			{
				Id = vm.Id,
				Prenom = vm.Prenom,
				Nom = vm.Nom,
				DateEmbauche = vm.DateEmbauche,
				Poste = vm.Poste
			});

			_unitOfWork.save();
		}

		public async Task Update(SoutienVM vm)
		{
			Soutien? soutien = await _unitOfWork.Soutiens.GetFirstOrDefaultAsync(s => s.Id == vm.Id);

			if (soutien == null)
				return;

			soutien.Prenom = vm.Prenom;
			soutien.Nom = vm.Nom;
			soutien.Poste = vm.Poste;
			soutien.DateEmbauche = vm.DateEmbauche;

			_unitOfWork.Soutiens.Update(soutien);
			_unitOfWork.save();
		}

		public async Task Delete(int id, bool confirmed)
		{
			Soutien? soutien = await _unitOfWork.Soutiens.GetFirstOrDefaultAsync(s => s.Id == id);

			if (soutien == null)
				return;

			_unitOfWork.Soutiens.Remove(soutien);
			_unitOfWork.save();
		}

		public async Task<Soutien> Delete(int id)
		{
			return await _unitOfWork.Soutiens.GetFirstOrDefaultAsync(s => s.Id == id);
		}

		public async Task<bool> EntityIsEmpty()
		{
			return _unitOfWork.Soutiens == null;
		}

		public async Task<bool> IsExist(int id)
		{
			return await _unitOfWork.Soutiens.GetFirstOrDefaultAsync(s => s.Id == id) != null;
		}
	}
}
