using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DAL.Interface.Repositories;
using DTO;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DtoRole GetRoleById(int id)
        {
            return _unitOfWork.Roles.GetById(id);
        }

        public DtoRole GetRoleByName(string name)
        {
            return _unitOfWork.Roles.GetByName(name);
        }
    }
}
