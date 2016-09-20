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
                Cover = dalBook.Cover,
                Year = dalBook.Year,
                CoverMimeType = dalBook.CoverMimeType,
                Content = dalBook.Content,
                ContentMimeType = dalBook.ContentMimeType,
                CreationDate = dalBook.CreationDate,
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
                Cover = book.Cover,
                Year = book.Year,
                CoverMimeType = book.CoverMimeType,
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
            var dtoUser = new DtoUser();

            dtoUser.Id = user.Id;
            dtoUser.Email = user.Email;
            dtoUser.Password = user.Password;
            dtoUser.CreationDate = user.CreationDate;
            dtoUser.Avatar = user.Avatar ?? new byte[0];
            return dtoUser;
        }

        public static User ToOrmUser(this DtoUser dtoUser)
        {
            return new User
            {
                Id = dtoUser.Id,
                Email = dtoUser.Email,
                Password = dtoUser.Password,
                CreationDate = dtoUser.CreationDate,
                Roles = dtoUser.Roles.Select(r => r.ToOrmRole()).ToList(),
                Avatar = dtoUser.Avatar
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

        public static DtoComment ToDtoComment(dynamic comment)
        {
            DtoComment dtoComment = new DtoComment
            {
                Id = comment.Id,
                BookId = comment.BookId,
                UserId = comment.UserId,
                Text = comment.Text,
                CreationDate = comment.CreationDate,
                UserEmail = comment.UserEmail,
                Avatar = comment.Avatar ?? new byte[0]
            };
            return dtoComment;
        }

        public static Comment ToOrmComment(this DtoComment dtoComment)
        {
            return new Comment
            {
                Id = dtoComment.Id,
                BookId = dtoComment.BookId,
                UserId = dtoComment.UserId,
                Text = dtoComment.Text,
                CreationDate = dtoComment.CreationDate
            };
        }
    }
}
