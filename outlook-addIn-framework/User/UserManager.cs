using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using OAFramework.Configuration;

namespace OAFramework.User
{
    public static class UserManager
    {
        private static OAObjectsContext Context = OADBManager.Instance.DBContext;

        private static string userName;
        private static EFUserGroup userGroup;
        private static EFUser user;
        
        public static EFUser GetUserByLogin(string login)
        {
            var findUserSqlQry = string.Format("SELECT UserId from dbo.AddInUser where UserName='{0}'", login);
            var userId = Context.Database.SqlQuery<int>(findUserSqlQry).FirstOrDefault();
            if (userId==0) 
            {
                findUserSqlQry = string.Format("SELECT UserId from dbo.AddInUser where UserName='{0}'", "UnknowUser");
                userId = Context.Database.SqlQuery<int>(findUserSqlQry).FirstOrDefault();
            }
            return Context.Users.Include("UserGroup").ToList().First(x => x.UserId==userId);
        }

        public static string UserName
        {
            get
            {
                if (userName == null)
                {
                    if (WindowsIdentity.GetCurrent() != null)
                    {
                        userName = WindowsIdentity.GetCurrent().Name ?? "UnknowUser";
                        //userName = @"CIB\thinguyen";
                    }
                    else
                    {
                        userName = "UnknowUser";
                    }
                }
                return userName;
            }
        }
        
        public static EFUser User
        {
            get
            {
                return user ?? (user = GetUserByLogin(UserName));
            }
        }

        public static EFUserGroup UserGroup
        {
            get
            {
                return userGroup ?? (userGroup = User.UserGroup);
            }
        }
    }
}
