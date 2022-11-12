using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.Web.Models;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using AutoMapper;
using BookReadingEvent.Web.Infrastructure;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;
using BookReadingEvent.Web.Subject;
using System.Xml.Linq;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="user,admin")]
    public class EventController : Controller,INotifyObservable
    {
        // private readonly IEventFacade _eventFacade;
        private readonly FacadeFactory _facadeFactory;
        private readonly IMapper _mapper;
        private readonly INotifySubject _notifySubject;
      /* public EventController(IEventFacade eventFacade,IMapper mapper)
        {
            _mapper = mapper;
            _eventFacade = eventFacade;
        }*/
        public EventController(FacadeFactory facadeFactory,IMapper mapper,INotifySubject notifySubject)
        {
            _facadeFactory = facadeFactory;
            _mapper = mapper;
            _notifySubject = notifySubject;
        }
        public IActionResult Index()
        {
          
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.UpcomingEvents = GetUpComingEvents();
            ViewBag.PastEvents = GetPastEvents();
            var data = GetAllEvents();
            return View(data);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public List<Event> GetAllEvents()
        {
            
            List<Event> result = new List<Event>();
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            List<CreateEventDTO> store = _eventFacade.GetAllPublicEvent();
       
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            return result;
        }
        public List<Event> GetUpComingEvents()
        {
            List<Event> result = new List<Event>();
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            List<CreateEventDTO> store = _eventFacade.GetUpcomingEvents();
      
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            SortByDate sortEventByDate = new SortByDate();
            result.Sort(sortEventByDate);
            result.Reverse();
            return result;
            
        }
        public List<Event> GetPastEvents()
        {
            List<Event> result = new List<Event>();
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            List<CreateEventDTO> store = _eventFacade.GetPastEvents();
        
            foreach (var x in store)
            {
                result.Add(_mapper.Map<CreateEventDTO, Event>(x));
            }
            SortByDate sortEventByDate = new SortByDate();
            result.Sort(sortEventByDate);
            result.Reverse();
            return result;
        }
        public IActionResult Show()
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            _notifySubject.AddObserver(this);
            return View("Index1");
        }
        public void Notify() 
        {

            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            List<CommentDTO> store = _eventFacade.GetCreatorEventComment(HttpContext.Session.GetString("EmailId"));
        
            List<Comment> CommentEvent = _mapper.Map<List<CommentDTO>, List<Comment>>(store);
            ViewBag.CommentOfPeople = CommentEvent;

        }
      
    }
}
