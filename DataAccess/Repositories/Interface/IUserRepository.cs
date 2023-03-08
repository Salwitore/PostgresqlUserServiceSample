using Data.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User UpdateUser(User updateUser, int userId);
    }
}
