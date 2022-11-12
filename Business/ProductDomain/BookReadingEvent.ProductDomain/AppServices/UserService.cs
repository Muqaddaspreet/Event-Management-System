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
    public class UserService : AppService, IUserService, IServiceInterface
    {
        /* private readonly IUserRepository userRepositry = null;
         public UserService(IUserRepository userrepo)
         {
             userRepositry = userrepo;
         }*/
        private readonly ICustomUnitOfWork _customUnitOfWork;
        public UserService(ICustomUnitOfWork customUnitOfWork)
        {
            _customUnitOfWork = customUnitOfWork;
        }
        public bool AddUser(SignUpDTO item)
        {
            string result = _customUnitOfWork.userRepository.AddUser(item);
            //string result = userRepositry.AddUser(item);
            return true;
        }
        public string GetInvitedEventId(string Email)
        {
            return _customUnitOfWork.userRepository.GetInvitedEventsString(Email);
           // return userRepositry.GetInvitedEventsString(Email);
        }
    }
}
