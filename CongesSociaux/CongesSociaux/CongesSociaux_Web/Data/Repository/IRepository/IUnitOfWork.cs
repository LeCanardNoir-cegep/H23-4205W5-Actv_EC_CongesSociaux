using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongesSociaux_Web.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        public IDepartementRepository Departements { get; }
        public IEnseignantRepository Enseignants { get; }
        public ISoutienRepository Soutiens { get; }

        void save();
    }
}
