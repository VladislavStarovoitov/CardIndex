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
                ImageMimeType = dalBook.ImageMimeType,
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
                ImageMimeType = book.ImageMimeType,
                Authors = book.Authors.Select(a => a.ToDtoAuthor()).ToList(),
                Genres = book.Genres.Select(g => g.ToDtoGenre()).ToList()
            };
        }

        public static DtoAuthor ToDtoAuthor(this Author author)
        {
            return new DtoAuthor
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public static DtoGenre ToDtoGenre(this Genre genre)
        {
            return new DtoGenre
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static DtoUser ToDtoUser(this User user)
        {
            var u = new DtoUser();

            u.Id = user.Id;
            u.Email = user.Email;
            u.Password = user.Password;
            u.CreationDate = user.CreationDate;
            //Roles = user.Roles.Select(r => r.ToDtoRole()).ToList()
            return u;
        }

        public static User ToOrmUser(this DtoUser dtoUser)
        {
            return new User
            {
                Id = dtoUser.Id,
                Email = dtoUser.Email,
                Password = dtoUser.Password,
                CreationDate = dtoUser.CreationDate,
                Roles = dtoUser.Roles.Select(r => r.ToOrmRole()).ToList()
            };
        }

        public static DtoRole ToDtoRole(this Role role)
        {
            return new DtoRole
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static Role ToOrmRole(this DtoRole dtoRole)
        {
            return new Role
            {
                Id = dtoRole.Id,
                Name = dtoRole.Name
            };
        }
    }
}
