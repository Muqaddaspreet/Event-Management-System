using BookReadingEvent.ProductDomain.AppServices.DTOs;
using System.Collections.Generic;

namespace BookReadingEvent.ProductDomain.Repository
{
    public interface ICreateEventRepositry
    {
        void AddEvent(CreateEventDTO eventDetails);
         List<CreateEventDTO> UpcomingEvents();
        List<CreateEventDTO> MyEvents(string email);
        CreateEventDTO GetEventById(int id);
        void TagInvitedEventToUser(List<string> AllMailID);
        void DeleteByEventId(int id);
        void UpdateEvent(CreateEventDTO eventDetails);
        List<CreateEventDTO> GetAllEvent();
        void AddComment(CommentDTO commentDetails);
        List<CommentDTO> GetAllComments(int ID);
        List<CommentDTO> GetCreatorEventComment(string loginemailid);
    }
}