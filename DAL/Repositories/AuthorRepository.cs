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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbContext _dataBase;

        public AuthorRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public IEnumerable<DtoAuthor> GetAll()
        {
            return _dataBase.Set<Author>().Select(a => a)?.ToList().Select(a => a.ToDtoAuthor());
        }
    }
}
