using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Facade
{
    public interface IUserLoginFacade
    {
        bool LoginUser(LoginDTO item);
    }
}
