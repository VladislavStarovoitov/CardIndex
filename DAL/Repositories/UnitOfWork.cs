using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using System.Data.Entity;

namespace DAL.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dataBase;
        private IBookRepository _bookRespository;
        private IUserRepository _userRespository;
        private IRoleRepository _roleRespository;
        private IAuthorRepository _authorRespository;
        private IGenreRepository _genreRespository;
        private ICommentRepository _commentRespository;

        public UnitOfWork(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public IBookRepository Books
        {
            get
            {
                if (ReferenceEquals(_bookRespository, null))
                    _bookRespository = new BookRepository(_dataBase);
                return _bookRespository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (ReferenceEquals(_userRespository, null))
                    _userRespository = new UserRepository(_dataBase);
                return _userRespository;
            }
        }

        public IRoleRepository Roles 
        {
            get
            {
                if (ReferenceEquals(_roleRespository, null))
                    _roleRespository = new RoleRepository(_dataBase);
                return _roleRespository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (ReferenceEquals(_commentRespository, null))
                    _commentRespository = new CommentRepository(_dataBase);
                return _commentRespository;
            }
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (ReferenceEquals(_authorRespository, null))
                    _authorRespository = new AuthorRepository(_dataBase);
                return _authorRespository;
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                if (ReferenceEquals(_genreRespository, null))
                    _genreRespository = new GenreRepository(_dataBase);
                return _genreRespository;
            }
        }

        public void Commit()
        {
            if (!ReferenceEquals(_dataBase, null))
            {
                _dataBase.SaveChanges();
            }
        }
    }
}
