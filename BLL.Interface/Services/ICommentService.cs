using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.Interface.Services
{
    public interface ICommentService
    {
        IEnumerable<DtoComment> GetCommentsByBookId(int bookId);
        bool CreateComment(DtoComment dtoComment);
    }
}
