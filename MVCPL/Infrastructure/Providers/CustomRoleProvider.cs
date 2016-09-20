using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace MVCPL.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IUserService UserService 
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        private IRoleService RoleService 
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));


        public override bool IsUserInRole(string email, string roleName)
        {
            var user = UserService.GetUserByEmail(email);

            if (ReferenceEquals(user, null))
                return false;

            var userRole = RoleService.GetRoleById(user.Id);

            if (!ReferenceEquals(userRole, null) && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            var roles = UserService.GetRolesForUser(email);

            if (ReferenceEquals(roles, null))
                return new string[0];

            return roles.Select(r => r.Name).ToArray();
        }

        #region NotImplemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}