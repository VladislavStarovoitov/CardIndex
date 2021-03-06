﻿using System;
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
                Cover = book.CoverFile.ToBytes(),
                CoverMimeType = book.CoverFile.ContentType,
                Content = book.ContentFile.ToBytes(),
                ContentMimeType = book.ContentFile.ContentType,
                Genres = new List<DtoGenre>(book.GenresSelected.Select(a => new DtoGenre() { Id = a, Name = String.Empty })),
                Authors = new List<DtoAuthor>(book.AuthorsSelected.Select(a => new DtoAuthor() { Id = a, Name = String.Empty })),
            };
        }

        public static BookViewModel ToBookViewModel(this DtoBook dtoBook)
        {
            return new BookViewModel()
            {
                Id = dtoBook.Id,
                Name = dtoBook.Name,
                Authors = dtoBook.Authors.Select(a => a.ToAuthorViewModel()).ToList(),
                Genres = dtoBook.Genres.Select(a => a.ToGenreViewModel()).ToList(),
                Description = dtoBook.Description,
                Year = dtoBook.Year,
                Cover = dtoBook.Cover
            };
        }

        public static Author ToAuthorViewModel(this DtoAuthor dtoAuthor)
        {
            return new Author
            {
                Id = dtoAuthor.Id,
                Name = dtoAuthor.Name
            };
        }

        public static Genre ToGenreViewModel(this DtoGenre dtoGenre)
        {
            return new Genre
            {
                Id = dtoGenre.Id,
                Name = dtoGenre.Name
            };
        }

        public static CommentViewModel ToCommentViewModel(this DtoComment dtoComment)
        {
            return new CommentViewModel
            {
                Id = dtoComment.Id,
                AuthorId = dtoComment.UserId,
                AuthorName = dtoComment.UserEmail,
                BookId = dtoComment.BookId,
                Text = dtoComment.Text,
                Avatar = dtoComment.Avatar,
                CreationDate = dtoComment.CreationDate
            };
        }

        public static DtoComment ToDtoComment(this CommentViewModel comment)
        {
            return new DtoComment
            {
                Id = comment.Id,
                BookId = comment.BookId,
                UserEmail = comment.AuthorName,
                Text = comment.Text,
                UserId = comment.AuthorId,
                CreationDate = comment.CreationDate
            };
        }

        public static byte[] ToBytes(this HttpPostedFileBase httpFile)
        {
            byte[] file = new byte[httpFile.ContentLength];
            httpFile.InputStream.Read(file, 0, httpFile.ContentLength);
            return file;
        }
    }
}