using BookReadingEvent.ProductDomain.AppServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.Web.Models;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="user")]
    public class InvitedEventController : Controller
    {
        private readonly FacadeFactory _facadeFactory;
     //   private readonly IEventFacade _eventFacade;
      /*  public InvitedEventController(IEventFacade eventFacade)
        {
            _eventFacade = eventFacade;
        }*/
        public InvitedEventController(FacadeFactory facadeFactory)
        {
            _facadeFactory = facadeFactory;
        }

        public IActionResult Index()
        {
            string Email = HttpContext.Session.GetString("EmailId");
            @ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            string AllEventId = _eventFacade.GetInvitedEventId(Email);
       
            List<int> allEventIds = FilterInvitedEventsString(AllEventId);
            List<CreateEventDTO> store = new List<CreateEventDTO>();
            foreach(int id in allEventIds)
            {
               store.Add(_eventFacade.GetEventById(id));
            }
            List<Event> result = new List<Event>();
            foreach(var item in store)
            {
                if(item == null)
                {
                    continue;
                }
                Event e = new Event();
                e.Creator = item.Creator;
                e.Date = item.Date;
                e.Description = item.Description;
                e.Duration = item.Duration;
                e.EventId = item.EventId;
                e.Location = item.Location;
                e.OtherDetails = item.OtherDetails;
                e.StartTime = item.StartTime;
                e.Title = item.Title;
                result.Add(e);
            }
            ViewBag.AllEvents = result;
            return View();
        }

        public List<int> FilterInvitedEventsString(string invitedEvents)
        {
            List<int> AllEventID = new List<int>();
            string newID = "";

            for (int i = 0; i < invitedEvents.Length; i++)
            {
                if (invitedEvents[i] != ',')
                {
                    newID += invitedEvents[i];
                }
                else if (invitedEvents[i] == ',')
                {
                    var temp = int.Parse(newID);
                    AllEventID.Add(temp);
                    newID = "";
                }
            }
            return AllEventID;
        }
    }
}
