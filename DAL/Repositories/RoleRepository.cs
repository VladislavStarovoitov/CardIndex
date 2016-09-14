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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _dataBase;

        public RoleRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public DtoRole GetByName(string name)
        {
            return _dataBase.Set<Role>().FirstOrDefault(r => r.Name == name)?.ToDtoRole();
        }
    }
}
