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

        public IBookRepository GetBooks()
        {
            //get
            //{
                if (ReferenceEquals(_bookRespository, null))
                    _bookRespository = new BookRepository(_dataBase);
                return _bookRespository;
            //}
        }

        public void Commit()
        {
            bool result = false;
            if (!ReferenceEquals(_dataBase, null))
            {
                result = _dataBase.SaveChanges() > 0;
            }
            //return false;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _dataBase.Dispose();
                _disposed = true;
            }
        }
    }
}
