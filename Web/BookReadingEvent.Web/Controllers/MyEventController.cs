using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="admin,user")]
    public class MyEventController : Controller
    {
        /* private readonly ICreateEventService _eventServices;
         public MyEventController(ICreateEventService eventser)
         {
             _eventServices = eventser;
         }*/
        //  private readonly IEventFacade _eventFacade;
        private readonly FacadeFactory _facadeFactory;
       /* public MyEventController(IEventFacade eventFacade)
        {
            _eventFacade = eventFacade;
        }*/
        public MyEventController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }
        public IActionResult Index()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.MyEvents = MyEvents();
            return View();
        }
        public List<Event> MyEvents()
        {
            List<Event> result = new List<Event>();
            var email = HttpContext.Session.GetString("EmailId");
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            List<CreateEventDTO> store = _eventFacade.MyEvents(email);
            foreach (var x in store)
            {
                Event showEvent = new Event();
                showEvent.Date = x.Date;
                showEvent.Description = x.Description;
                showEvent.Duration = x.Duration;
                showEvent.InviteByEmail = x.InviteByEmail;
                showEvent.Location = x.Location;
                showEvent.OtherDetails = x.OtherDetails;
                showEvent.StartTime = x.StartTime;
                showEvent.Title = x.Title;
                showEvent.Type = x.Type;
                showEvent.EventId = x.EventId;
                result.Add(showEvent);
            }
            return result;
        }
    }
}
