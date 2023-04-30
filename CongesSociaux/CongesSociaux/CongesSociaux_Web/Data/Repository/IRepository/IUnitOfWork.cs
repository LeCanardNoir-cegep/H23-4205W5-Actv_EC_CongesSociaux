using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongesSociaux_Web.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //IEnterpriseRepository Enterprise { get; }
        //IEquipmentRecordRepository EquipmentRecord { get; }
        //IEquipmentRepository Equipment { get; }   
        //IGroupRepository Group { get; }

        void save();
    }
}
