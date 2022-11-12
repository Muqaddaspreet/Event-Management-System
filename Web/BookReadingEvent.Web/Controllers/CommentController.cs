using AutoMapper;
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
using BookReadingEvent.Web.Subject;

namespace BookReadingEvent.Web.Controllers
{
    [CustomAuthFilter(Roles ="user,admin")]
    public class CommentController : Controller
    {
      
        private readonly FacadeFactory _facadeFactory;
        private readonly IMapper _mapper;
        public CommentController(FacadeFactory facadeFactory ,IMapper mapper)
        {
            _mapper = mapper;
            _facadeFactory = facadeFactory;
        }

       

        public IActionResult Index(int id)
        {
            HttpContext.Session.SetString("Id", id.ToString());
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Comment commentDetails)
        {
            commentDetails.Email= HttpContext.Session.GetString("EmailId");
            commentDetails.EventID = int.Parse(HttpContext.Session.GetString("Id"));
            CommentDTO store = _mapper.Map<Comment, CommentDTO>(commentDetails);
            EventFacade _eventFacade = (EventFacade)_facadeFactory.GetFacade("IEventFacade");
            _eventFacade.AddComment(store);
            return RedirectToAction("Index", "Event");
          
        }

    }
}