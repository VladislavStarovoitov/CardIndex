﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface;
using DAL.Interface.Repositories;

using DTO;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddBook(DtoBook dtoBook, IEnumerable<string> newAuthors, IEnumerable<string> newGenres)
        {
            var result = false;
            result = _unitOfWork.Books.Create(dtoBook, newAuthors, newGenres);          
            if (result)
            {
                _unitOfWork.Commit();
            }
            return result;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
