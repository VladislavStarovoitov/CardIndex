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

            kernel.Bind<IBookService>().To<BookService>();
        }
    }
}
