using BookReadingEvent.Core.AppServices;
using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices
{
    public interface IUserLoginService : IAppService
    {
        bool AddUser(LoginDTO item);

    }
}
