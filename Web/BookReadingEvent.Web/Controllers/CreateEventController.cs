using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="admin,user")]
    public class CreateEventController : Controller
    {
        private readonly FacadeFactory _facadeFactory;
        //private readonly IEventFacade _eventFacade;
       /* public CreateEventController(IEventFacade eventfacade)
        {
            _eventFacade = eventfacade;
        }*/
        public CreateEventController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Event EventDetails)
        { 
            CreateEventDTO newEvent = new CreateEventDTO();
            newEvent.Date = EventDetails.Date;
            newEvent.Description = EventDetails.Description;
            newEvent.Duration = EventDetails.Duration;
            newEvent.InviteByEmail = EventDetails.InviteByEmail;
            newEvent.Location = EventDetails.Location;
            newEvent.OtherDetails = EventDetails.OtherDetails;
            newEvent.StartTime = EventDetails.StartTime;
            newEvent.Title = EventDetails.Title;
            newEvent.Type = EventDetails.Type;
            newEvent.Creator = HttpContext.Session.GetString("EmailId");
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            _eventFacade.AddEvent(newEvent);
           // _userService.AddEvent(newEvent);
            if (EventDetails.InviteByEmail != null)
            {
                string EmailID = HttpContext.Session.GetString("EmailId");
                //  _userService.TagInvitedEventToUser(EventDetails.InviteByEmail, EmailID);
                _eventFacade.TagInvitedEventToUser(EventDetails.InviteByEmail, EmailID);
            }
            
            return RedirectToAction("Index","MyEvent");
        }
    }
}
