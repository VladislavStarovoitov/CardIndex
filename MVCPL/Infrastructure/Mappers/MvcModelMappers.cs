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
        public static DtoBook ToDtoBook(this Book book)
        {
            return new DtoBook()
            {
                Id = book.Id,
                Name = book.Name,
                Authors = book.Authors,
                Description = book.Description,
                Year = book.Year,
                Image = book.Image
            };
        }

        public static Book ToMvcModelBook(this DtoBook dtoBook)
        {
            return new Book()
            {
                Id = dtoBook.Id,
                Name = dtoBook.Name,
                Authors = dtoBook.Authors,
                Description = dtoBook.Description,
                Year = dtoBook.Year,
                Image = dtoBook.Image
            };
        }
    }
}