using BookReadingEvent.ProductDomain.Data;
using BookReadingEvent.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookReadingEvent.ProductDomain.UoW.Files;
using BookReadingEvent.Core.Data.DataAccess;
using BookReadingEvent.ProductDomain.Domain;
using BookReadingEvent.ProductDomain.AppServices.DTOs;

namespace BookReadingEvent.ProductDomain.Repository
{
     public class UserRepository: Repository<User>, IUserRepository
     {
        public ProductDomainDbContext _obj;
        public UserRepository(ProductDomainDbContext context) : base(context)
        {
            _obj = context;
        }

        public string AddUser(SignUpDTO UserDetails)
        {

            var checkUser = _obj.UserAccounts.Where(x => x.EmailID == UserDetails.EmailID).FirstOrDefault();
            if (checkUser == null)
            {
                User newUser = new User();
                newUser.FirstName = UserDetails.FirstName;
                newUser.LastName = UserDetails.LastName;
                newUser.EmailID = UserDetails.EmailID;
                newUser.Password = UserDetails.Password;
                 _obj.UserAccounts.Add(newUser);
                _obj.SaveChanges();
                return newUser.EmailID;
            }
            else
            {
                return null;
            }
        }
        public bool  LoginUser(LoginDTO UserDetails)
        {
            var checkUser = _obj.UserAccounts.Where(x => x.EmailID == UserDetails.EmailID && x.Password == UserDetails.Password).FirstOrDefault();
            if (checkUser != null)
                return true;
            else
                return false;

        }
        public string GetInvitedEventsString(string Email)
        {
            var user = _obj.UserAccounts.Where(x => x.EmailID.Equals(Email)).FirstOrDefault();
            if (user.InvitedEvent == null)
                return "";
            return user.InvitedEvent;
        }
    }
}
