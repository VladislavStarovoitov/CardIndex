using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public void CreateUser(DtoUser dtoUser)
        {
            throw new NotImplementedException();
        }

        public DtoUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
