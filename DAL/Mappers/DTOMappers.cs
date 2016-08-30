using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DTO;

namespace DAL.Mappers
{
    public static class DTOMappers
    {
        public static Book ToOrmBook(this DtoBook dalBook)
        {
            var book = new Book()
            {
                Id = dalBook.Id,
                Name = dalBook.Name,
                Description = dalBook.Description,
                Image = dalBook.Image,
                Year = dalBook.Year
            };
            foreach (var author in dalBook.Authors)
            {
                book.Authors.Add(new Author() { Name = author });
            }
            return book;            
        }

        public static DtoBook ToDtoBook(this Book book)
        {
            return new DtoBook()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Image = book.Image,
                Year = book.Year,
                Authors = book.Authors.Select(a => a.Name)
            };
        }
    }
}
