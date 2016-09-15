using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DTO;
using System.Data.Entity;
using ORM;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dataBase;

        public UserRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public bool Create(DtoUser entity)
        {
            var ormUsers = entity.ToOrmUser();
            if (ReferenceEquals(entity.Roles, null) && entity.Roles.Count == 0)
                return false;
            var rolesId = ormUsers.Roles.Select(eR => eR.Id);
            var rolesExists = _dataBase.Set<Role>()
                                 .Where(r => rolesId
                                     .Any(rI => rI == r.Id)).ToArray();

            if (rolesExists.Count() != entity.Roles.Count())
                return false;
            ormUsers.Roles = rolesExists;
            _dataBase.Set<User>().Add(ormUsers);
            return true;
        }

        public IEnumerable<DtoUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoUser GetByEmail(string email)
        {
            return GetUser(email)?.ToDtoUser();
        }

        public DtoUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoRole> GetRolesForUser(string email)
        {
            return GetUser(email)?.Roles.Select(r => r.ToDtoRole());
        }

        private User GetUser(string email)
        {
            return _dataBase.Set<User>().FirstOrDefault(u => u.Email == email);
        }
    }
}
