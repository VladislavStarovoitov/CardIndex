using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
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

        public bool AddBook(DtoBook dtoBook, string newAuthors, string newGenres)
        {
            var result = false;
            if (newAuthors.Equals(string.Empty) && newGenres.Equals(string.Empty))
                result = _unitOfWork.Books.Create(dtoBook);
            else
                result = _unitOfWork.Books.Create(dtoBook, newAuthors.ToTagArray(), newGenres.ToTagArray());          
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
