using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Facade
{
    public class UserLoginFacade:IUserLoginFacade, CommonFacade
    {
       private readonly IUserLoginService _userloginservice;
        public UserLoginFacade(IUserLoginService userLoginService)
        {
            _userloginservice = userLoginService;
        }
        public bool LoginUser(LoginDTO item)
        {
            bool result = _userloginservice.AddUser(item);
            return result;
        }
    }
}
