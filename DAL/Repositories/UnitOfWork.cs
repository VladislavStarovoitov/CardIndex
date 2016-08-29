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
        private BookRepository _bookRespository;

        private bool _disposed = false;

        public UnitOfWork(DbContext dataBase)
        {
            _dataBase = dataBase;
        }

        public IBookRepository Books
        {
            get
            {
                if (_bookRespository == null)
                    _bookRespository = new BookRepository(_dataBase);
                return _bookRespository;
            }
        }

        public void Commit()
        {
            if (!ReferenceEquals(_dataBase, null))
            {
                _dataBase.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _dataBase.SaveChanges();
                _disposed = true;
            }
        }
    }
}
