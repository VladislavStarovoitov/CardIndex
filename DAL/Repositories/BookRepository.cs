using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DAL.Interface.DTO;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class BookRepository : IRepository<DALBook>
    {
        public void Create(DALBook entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DALBook> GetAll()
        {
            throw new NotImplementedException();
        }

        public DALBook GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
