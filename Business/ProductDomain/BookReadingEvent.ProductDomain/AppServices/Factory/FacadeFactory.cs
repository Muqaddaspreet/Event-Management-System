using BookReadingEvent.ProductDomain.AppServices.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Factory
{
    
    public class FacadeFactory
    {
        private readonly ICreateEventService _createEventService;
        private readonly IUserService _userService;
        private readonly IUserLoginService _userLoginService;
        public  FacadeFactory(ICreateEventService createEventService,IUserLoginService userLoginService,IUserService userService)
        {
            _createEventService = createEventService;
            _userLoginService = userLoginService;
            _userService = userService;
        }
        public CommonFacade GetFacade(String facadename)
        {
            if(facadename == "IEventFacade")
            {
                return new EventFacade(_createEventService,_userService);
            }
            return new UserLoginFacade(_userLoginService);
        }

    }
}
