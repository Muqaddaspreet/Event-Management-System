using BookReadingEvent.Core.ValueObjects;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly FacadeFactory _facadeFactory;
        //private readonly IUserLoginFacade _userLoginFacade;  
       /* public LoginController(IUserLoginFacade userLoginFacade)
        {
            _userLoginFacade = userLoginFacade;
        }*/
        public LoginController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }
        public IActionResult Index(bool isSucess = false)
        {
            ViewBag.IsSucess = isSucess;
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserLogin userDetails)
        {
           
            LoginDTO obj = new LoginDTO
            {
                EmailID = userDetails.EmailID,
                Password = userDetails.Password

            };
            if (userDetails.EmailID== "myadmin@bookevents.com" && userDetails.Password=="admin")
            {
                DecoratorRole decoratorRole = new DecoratorRole(userDetails);
                HttpContext.Session.SetString("Role", decoratorRole.role);
                HttpContext.Session.SetString("EmailId", userDetails.EmailID);
                return RedirectToAction("Index","Admin");
            }
            UserLoginFacade _userLoginFacade = (UserLoginFacade)_facadeFactory.GetFacade("");
            bool user = _userLoginFacade.LoginUser(obj);
           // bool user = _userLogin.AddUser(obj);
            if(user== true)
            {
                DecoratorRole decoratorRole = new DecoratorRole(userDetails);
                HttpContext.Session.SetString("Role", decoratorRole.role);
                HttpContext.Session.SetString("EmailId",userDetails.EmailID);
                return RedirectToAction("Index","Event");
            }
            else
            {
                ViewBag.IsSucess = true;
                return View();
            }    
     
        }
    }
}
