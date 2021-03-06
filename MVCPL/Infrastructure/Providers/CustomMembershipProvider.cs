﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Services;
using System.Web.Helpers;
using DTO;
using System.IO;

namespace MVCPL.Infrastructure.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private IUserService UserService 
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        private IRoleService RoleService 
            => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));

        public MembershipUser CreateUser(string email, string password)
        {
            var user = new DtoUser
            {
                Email = email,
                Password = Crypto.HashPassword(password),
                CreationDate = DateTime.Now
            };

            var role = RoleService.GetRoleByName("User");
            if (ReferenceEquals(role, null))
            {
                return null;                
            }
            user.Roles = new List<DtoRole> { role };
            var avatarPath = HttpContext.Current.Server.MapPath("~/Images/nophoto.png");
            using (FileStream anonAvatar = new FileStream(avatarPath, FileMode.Open))
            {
                byte[] array = new byte[anonAvatar.Length];
                anonAvatar.Read(array, 0, array.Length);
                user.Avatar = array;
            }
            bool creationResult = UserService.CreateUser(user);
            if (creationResult)
            {
                var membershipUser = GetUser(email, false);
                return membershipUser;
            }

            return null;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var user = UserService.GetUserByEmail(email);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Email,
                null, null, null, null,
                false, false, user.CreationDate,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        public override bool ValidateUser(string email, string password)
        {
            var user = UserService.GetUserByEmail(email);

            if (!ReferenceEquals(user, null) && Crypto.VerifyHashedPassword(user.Password, password))
            {
                return true;
            }
            return false;
        }

        #region NotImplemented
        public override string ApplicationName { get; set; }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}