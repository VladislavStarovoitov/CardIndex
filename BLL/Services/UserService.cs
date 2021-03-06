﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DAL.Interface.Repositories;
using DTO;
using System.IO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateUser(DtoUser dtoUser)
        {
            bool result = false;
            result = _unitOfWork.Users.Create(dtoUser);
            if (result)
            {
                _unitOfWork.Commit();
            }
            return result;
        }

        public IEnumerable<DtoRole> GetRolesForUser(string email)
        {
            return _unitOfWork.Users.GetRolesForUser(email);
        }

        public DtoUser GetUserByEmail(string email)
        {
            return _unitOfWork.Users.GetByEmail(email);
        }
    }
}
