using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPL.Models;
using DTO;

namespace MVCPL.Infrastructure.Mappers
{
    public static class MvcModelMappers
    {
        public static DtoBook ToDtoBook(this BookViewModel book)
        {
            return new DtoBook()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Year = book.Year,
                Image = book.Image,
                //Genres = new List<DtoGenre>(book.GenreIds.Select(a => new DtoGenre() { Id = a, Name = String.Empty })),
                //Authors = new List<DtoAuthor>(book.AuthorIds.Select(a => new DtoAuthor() { Id = a, Name = String.Empty })),
            };
        }

        public static BookViewModel ToBookViewModel(this DtoBook dtoBook)
        {
            return new BookViewModel()
            {
                Id = dtoBook.Id,
                Name = dtoBook.Name,
                Authors = dtoBook.Authors.Select(a => a.ToMvcModelAuthor()).ToList(),
                Description = dtoBook.Description,
                Year = dtoBook.Year,
                Image = dtoBook.Image
            };
        }

        public static Author ToMvcModelAuthor(this DtoAuthor dtoAuthor)
        {
            return new Author
            {
                Id = dtoAuthor.Id,
                Name = dtoAuthor.Name
            };
        }

        public static Genre ToMvcModelAuthor(this DtoGenre dtoGenrer)
        {
            return new Genre
            {
                Id = dtoGenrer.Id,
                Name = dtoGenrer.Name
            };
        }
    }
}