using Data.ContextClasses;
using DataAccess.Repositories.Interface;
using DataAccess.Repositories.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private MasterContext masterContext;

        public UnitOfWork(MasterContext masterContext)
        {
            this.masterContext = masterContext;
        }

        private IUserRepository userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(masterContext);
                }
                return userRepository;
            }
        }

        public void Dispose()
        {
            masterContext.Dispose();
        }

        public int SaveChanges()
        {
            return masterContext.SaveChanges();
        }

    }
}
