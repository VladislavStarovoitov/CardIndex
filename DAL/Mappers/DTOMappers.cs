using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DTOMappers
    {
        public static Book ToORMBook(this DALBook dalBook)
        {
            var book = new Book()
            {
                Id = dalBook.Id,
                Name = dalBook.Name,
                Description = dalBook.Description,
                Image = dalBook.Image,
                Year = dalBook.Year
            };
            return book;            
        }

        public static DALBook ToDALBook(this Book book)
        {
            var dalBook = new DALBook()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Image = book.Image,
                Year = book.Year
            };
            return dalBook;
        }
    }
}
