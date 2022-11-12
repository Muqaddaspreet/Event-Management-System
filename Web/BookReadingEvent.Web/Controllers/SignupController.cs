using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookReadingEvent.Web.Controllers
{
    public class SignupController : Controller
    {

        /* private readonly IUserService _userService;
         // userservice is called dependency and get  injected 
         public SignupController(IUserService userService)
         {
             _userService = userService;
         }
         */
        //        private readonly IEventFacade _eventFacade; 
        private readonly FacadeFactory _facadeFactory;
        /*public SignupController(IEventFacade eventFacade)
        {
            _eventFacade = eventFacade;
        }*/
        public SignupController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Index(SignUp userDetails)  
        {
            if (ModelState.IsValid)
            {
                SignUpDTO obj = new SignUpDTO
                {
                    EmailID = userDetails.EmailID,
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    Password = userDetails.Password
                };
                EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
                bool user = _eventFacade.AddUser(obj);
                if (user == true)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }
    }
}
