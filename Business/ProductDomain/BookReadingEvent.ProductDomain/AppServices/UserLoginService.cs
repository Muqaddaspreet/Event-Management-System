using BookReadingEvent.Core.AppServices;
using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.Repository;
using BookReadingEvent.ProductDomain.UoW.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices
{
    public class UserLoginService : AppService, IUserLoginService, IServiceInterface
    {
        
        private readonly ICustomUnitOfWork _customUnitOfWork;
        public UserLoginService(ICustomUnitOfWork customUnitOfWork)
        {
            _customUnitOfWork = customUnitOfWork;
        }
        public bool AddUser(LoginDTO item)
        {
            bool result = _customUnitOfWork.userRepository.LoginUser(item);
            //bool result = userRepositry.LoginUser(item);
            return result;
        }
    }
}
