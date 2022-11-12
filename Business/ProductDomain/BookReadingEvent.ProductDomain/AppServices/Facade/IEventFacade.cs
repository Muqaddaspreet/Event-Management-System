using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.Facade
{
    public interface IEventFacade
    {
        void AddEvent(CreateEventDTO obj);
        void TagInvitedEventToUser(string InvitedUsers, string authorEmailID);
        List<CreateEventDTO> GetAllEvent();
        List<CommentDTO> GetAllComments(int ID);
        void AddComment(CommentDTO commentDetails);
        List<CreateEventDTO> GetAllPublicEvent();
        List<CreateEventDTO> GetUpcomingEvents();
        List<CreateEventDTO> GetPastEvents();
        CreateEventDTO GetEventById(int id);
        void UpdateEvent(CreateEventDTO newEvent);
        void DeleteByEventId(int id);
        string GetInvitedEventId(string Email);
        bool AddUser(SignUpDTO item);
        List<CreateEventDTO> MyEvents(string email);
        List<CommentDTO> GetCreatorEventComment(string loginemailid);

    }
}
