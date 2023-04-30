using CongesSociaux_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongesSociaux_Web.Data.Repository.IRepository
{
    public interface ISoutienRepository : IRepositoryAsync<Soutien>
    {
        //new void Update(Group group);
        //new void UpdateRange(IEnumerable<Group> groups);
    }
}
