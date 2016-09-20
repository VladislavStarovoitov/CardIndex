using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IAuthorRepository Authors { get; }
        IGenreRepository Genres { get; }
        ICommentRepository Comments { get; }
        void Commit();
    }
}
