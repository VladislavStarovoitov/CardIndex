using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interface.Repositories
{
    public interface IUserRepository : IRepository<DtoUser>
    {
        DtoUser GetByEmail(string email);
        IEnumerable<DtoRole> GetRolesForUser(string email);
    }
}
