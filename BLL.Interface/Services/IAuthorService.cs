using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.Interface.Services
{
    public interface IAuthorService
    {
        IEnumerable<DtoAuthor> GetAllAuthors();
    }
}
