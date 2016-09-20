using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DTO;

namespace DAL.Interface.Repositories
{
    public interface ICommentRepository : IRepository<DtoComment>
    {
        IEnumerable<DtoComment> GetByBookId(int bookId);
        void Delete(int id);
    }
}
