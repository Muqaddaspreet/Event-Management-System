using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System.Collections.Generic;

namespace BookReadingEvent.ProductDomain.AppServices
{
    public interface ICreateEventService
    {
        bool AddEvent(CreateEventDTO item);
        List<CreateEventDTO> GetAllPublicEvent();
        List<CreateEventDTO> GetUpcomingEvents();
        List<CreateEventDTO> GetPastEvents();
        List<CreateEventDTO> MyEvents(string email);
        CreateEventDTO GetEventById(int id);
         void TagInvitedEventToUser(string InvitedUsers, string authorEmailID);
        void DeleteByEventId(int id);
        void UpdateEvent(CreateEventDTO newEvent);
        List<CreateEventDTO> GetAllEvent();
        void AddComment(CommentDTO commentDetails);
        List<CommentDTO> GetAllComments(int ID);
        List<CommentDTO> GetCreatorEventComment(string loginemailid);
    }
}