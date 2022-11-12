using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Newtonsoft.Json;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="admin,user")]
    public class UpdateEventController : Controller
    {
        // private readonly IEventFacade _eventFacade;

        private readonly FacadeFactory _facadeFactory;
        private readonly IMapper _mapper;


       /* public UpdateEventController(IEventFacade eventFacade,IMapper mapper)
        {
            _mapper = mapper;
            _eventFacade = eventFacade;
        }*/
       public UpdateEventController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }
        public IActionResult Index(int id)
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            HttpContext.Session.SetString("EventId", id.ToString());
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event EventDetails)
        {
            CreateEventDTO newEvent = new CreateEventDTO();
            newEvent.Date = EventDetails.Date; 
            newEvent.Description = EventDetails.Description;
            newEvent.Duration = EventDetails.Duration;
            newEvent.Location = EventDetails.Location; 
            newEvent.StartTime = EventDetails.StartTime;
            newEvent.Title = EventDetails.Title; 
            newEvent.Type = EventDetails.Type;
            newEvent.EventId = int.Parse(HttpContext.Session.GetString("EventId"));
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            _eventFacade.UpdateEvent(newEvent);
            return RedirectToAction("Index","MyEvent");
        }
        public JsonResult GetEventById()
        {
            int eventid = int.Parse(HttpContext.Session.GetString("EventId"));
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            CreateEventDTO eventDetailsStore  =_eventFacade.GetEventById(eventid);
            Event eventdetails=_mapper.Map<CreateEventDTO, Event>(eventDetailsStore);

            var json = JsonConvert.SerializeObject(eventdetails);
            
            return Json(json);
        }
    }
}
