using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DTO;
using DAL.Interface.Repositories;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DtoAuthor> GetAllAuthors()
        {
            return _unitOfWork.Authors.GetAll();
        }
    }
}
