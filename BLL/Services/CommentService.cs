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

        public bool CreateComment(DtoComment dtoComment)
        {
            var result = _unitOfWork.Comments.Create(dtoComment);
            if (result)
            {
                _unitOfWork.Commit();
            }
            return result;
        }

        public void Delete(int id)
        {
            _unitOfWork.Comments.Delete(id);
            _unitOfWork.Commit();
        }

        public IEnumerable<DtoComment> GetCommentsByBookId(int bookId)
        {
            return _unitOfWork.Comments.GetByBookId(bookId);
        }
    }
}
