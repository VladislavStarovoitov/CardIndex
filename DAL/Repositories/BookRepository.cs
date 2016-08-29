using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DTO;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContext _dataBase;

        public BookRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(DtoBook entity)////////////////////////////////////////
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DtoBook GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
