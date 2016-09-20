using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IBookService
    {
        bool AddBook(DtoBook dtoBook, IEnumerable<string> newAuthors, IEnumerable<string> newGenres);
        int BookCount();
        IEnumerable<DtoBook> GetBookRange(int skipCount, int count);
        IEnumerable<DtoBook> GetBooksByName(int skipCount, int count, string name);
        DtoBook GetBookById(int id);
        DtoBookContent GetBookContent(int id);
    }
}
