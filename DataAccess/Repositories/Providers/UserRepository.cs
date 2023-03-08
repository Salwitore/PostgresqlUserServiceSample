using Data.ContextClasses;
using Data.EntityClasses;
using DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Providers
{
    public class UserRepository : Repository<User> , IUserRepository
    {

        public UserRepository(MasterContext context) : base(context)
        {

        }

        public MasterContext masterContext { get { return DbContext as MasterContext; } }


        public User UpdateUser(User updateUser, int userId)
        {
            var user = masterContext.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.Name= updateUser.Name;
            user.Surname= updateUser.Surname;

           
            return user;

        }

    }
}
