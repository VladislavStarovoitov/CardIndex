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
                Year = dalBook.Year,
                Authors = dalBook.Authors.Select(a => new Author() { Name = a.Name, Id = a.Id }).ToList(),
                Genres = dalBook.Genres.Select(a => new Genre() { Name = a.Name, Id = a.Id }).ToList() //List из-за Icollection
            };
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
                Authors = book.Authors.Select(a => new DtoAuthor { Name = a.Name, Id = a.Id }).ToList(),
                Genres = book.Genres.Select(g => new DtoGenre { Name = g.Name, Id = g.Id }).ToList()
            };
        }
    }
}
