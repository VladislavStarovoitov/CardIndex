using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository GetBooks();
        void Commit();
    }
}
