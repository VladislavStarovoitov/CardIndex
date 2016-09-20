using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Repositories;
using DAL.Repositories;
using ORM;
using BLL.Interface.Services;
using BLL.Services;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void Configurate(this IKernel kernel)
        {
            kernel.Bind<DbContext>().To<CardIndex>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            #region Services
            kernel.Bind<IBookService>().To<BookService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IAuthorService>().To<AuthorService>();
            kernel.Bind<IGenreService>().To<GenreService>();
            #endregion

            #region Repositories
            //kernel.Bind<IUserRepository>().To<UserRepository>();
            //kernel.Bind<IBookRepository>().To<BookRepository>();
            //kernel.Bind<IRoleRepository>().To<RoleRepository>();
            //kernel.Bind<ICommentRepository>().To<CommentRepository>();
            //kernel.Bind<IGenreRepository>().To<GenreRepository>();
            //kernel.Bind<IAuthorRepository>().To<AuthorRepository>();
            #endregion
        }
    }
}
