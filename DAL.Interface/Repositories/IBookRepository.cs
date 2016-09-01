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
        bool Create(DtoBook entity, string[] newAuthors, string[] newGenres);
    }
}
