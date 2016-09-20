using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using DTO;
using ORM;
using System.Data.Entity;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _dataBase;

        public CommentRepository(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public bool Create(DtoComment entity)
        {
            _dataBase.Set<Comment>().Add(entity.ToOrmComment());
            return true;
        }

        public void Delete(int id)
        {
            var comment = new Comment { Id = id };
            _dataBase.Set<Comment>().Attach(comment);
            _dataBase.Set<Comment>().Remove(comment);
        }

        public IEnumerable<DtoComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoComment> GetByBookId(int bookId)
        {
            var comments = _dataBase.Set<Comment>()
                .Where(c => c.BookId == bookId)
                .Join(_dataBase.Set<User>(),
                    c => c.UserId,
                    u => u.Id,
                    (c, u) => new
                    {
                        Id = c.Id,
                        Text = c.Text,
                        CreationDate = c.CreationDate,
                        BookId = c.BookId,
                        UserId = c.UserId,
                        UserEmail = u.Email,
                        Avatar = u.Avatar
                    }).AsEnumerable()?.Select(c => DTOMappers.ToDtoComment(c));
            return comments;
        }

        public DtoComment GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
