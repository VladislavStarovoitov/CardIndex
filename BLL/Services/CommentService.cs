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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DtoComment> GetCommentsByBookId(int bookId)
        {
            return _unitOfWork.Comments.GetByBookId(bookId);
        }
    }
}
