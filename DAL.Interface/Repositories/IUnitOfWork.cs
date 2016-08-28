using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get;}
        void Commit();
    }
}
