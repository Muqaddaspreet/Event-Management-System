using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Facade
{
   public  class EventFacade:IEventFacade, CommonFacade
    {
        private readonly ICreateEventService _usereventService;
        private readonly IUserService _userService;

        // userservice is called dependency is injected 
        public EventFacade(ICreateEventService usereventService,IUserService userService)
        {
            _usereventService = usereventService;
            _userService = userService;
        }
        public void AddEvent(CreateEventDTO obj)
        {
            _usereventService.AddEvent(obj);
        }
        public void TagInvitedEventToUser(string InvitedUsers, string authorEmailID)
        {
            _usereventService.TagInvitedEventToUser(InvitedUsers, authorEmailID);
        }
        public List<CreateEventDTO> GetAllEvent()
        {
            return _usereventService.GetAllEvent();
        }
        public void AddComment(CommentDTO commentDetails)
        {
           _usereventService.AddComment(commentDetails);
        }
        public List<CommentDTO> GetAllComments(int ID)
        {
            return _usereventService.GetAllComments(ID);
        }
        public List<CreateEventDTO> GetAllPublicEvent()
        {
            return _usereventService.GetAllPublicEvent();
        }
        public List<CreateEventDTO> GetUpcomingEvents()
        {
            return _usereventService.GetUpcomingEvents();
        }
        public List<CreateEventDTO> GetPastEvents()
        {
            return _usereventService.GetPastEvents();
        }
        public CreateEventDTO GetEventById(int id)
        {
            return _usereventService.GetEventById(id);
        }
        public void DeleteByEventId(int id)
        {
            _usereventService.DeleteByEventId(id);
        }
        public void UpdateEvent(CreateEventDTO newEvent)
        {
          _usereventService.UpdateEvent(newEvent);
        }
        public bool AddUser(SignUpDTO item)
        {
            bool result = _userService.AddUser(item);
            return true;
        }
        public string GetInvitedEventId(string Email)
        {
            return _userService.GetInvitedEventId(Email);
        }
        public List<CreateEventDTO> MyEvents(string email)
        {
            return _usereventService.MyEvents(email);
        }
        public List<CommentDTO> GetCreatorEventComment(string loginemailid)
        {
            return _usereventService.GetCreatorEventComment(loginemailid);
        }
    }
}
