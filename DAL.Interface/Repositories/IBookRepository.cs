using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interface.Repositories
{
    public interface IBookRepository : IRepository<DtoBook>
    {
        bool Create(DtoBook entity, IEnumerable<string> newAuthors, IEnumerable<string> newGenres);
        IEnumerable<DtoBook> GetRange(int skipCount, int count);
        int Count();
    }
}
