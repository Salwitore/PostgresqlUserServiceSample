using AutoMapper;
using Data.Dtos.MapperDto;
using Data.EntityClasses;
using Data.Results;
using DataAccess.Repositories.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private readonly IMapper mapper;

        public UserBusiness(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IDataResult<User> AddUser(UserDto userDto) 
        {

            var mappedUser = mapper.Map<User>(userDto);

            using (UnitOfWork uow = new UnitOfWork(new Data.ContextClasses.MasterContext()))
            {
                uow.UserRepository.Add(mappedUser);
                uow.SaveChanges();
            }
            return new SuccessDataResult<User>(mappedUser);
        }

        public IDataResult<User> DeleteUser(string email)
        {

            using (UnitOfWork uow = new UnitOfWork(new Data.ContextClasses.MasterContext()))
            {
                var user = uow.UserRepository.GetAll(u => u.Email.Equals(email)).FirstOrDefault();
                if (user == null)
                {
                    return new ErrorDataResult<User>("User not found!");
                }
                uow.UserRepository.Delete(user);
                uow.SaveChanges();
                return new SuccessDataResult<User>(user);
            }

        }
        public IDataResult<User> SafeDelete(string email)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.ContextClasses.MasterContext()))
            {
                var user = uow.UserRepository.GetAll(u => u.Email.Equals(email)).FirstOrDefault();
                if (user == null)
                {
                    return new ErrorDataResult<User>("User not found!");
                }
                user.DeletedTime = DateTime.UtcNow;
                uow.SaveChanges();
                return new SuccessDataResult<User>(user);
            }
        }

        public IDataResult<List<User>> GetAllUser()
        {

            using (UnitOfWork uow = new UnitOfWork(new Data.ContextClasses.MasterContext()))
            {
                var users = uow.UserRepository.GetAll();
                return new SuccessDataResult<List<User>>(users.ToList());
            }

        }

        public IDataResult<User> GetUser(string email)
        {
            using (UnitOfWork uow = new UnitOfWork(new Data.ContextClasses.MasterContext()))
            {
                var user = uow.UserRepository.GetAll(u => u.Email.Equals(email)).FirstOrDefault();

                return user != null ? new SuccessDataResult<User>(user) : new ErrorDataResult<User>("User not found!");
            } 
        }

    }
}
