using BookReadingEvent.ProductDomain.AppServices.CustomException;
using BookReadingEvent.ProductDomain.AppServices.DTOs;
using BookReadingEvent.ProductDomain.Repository;
using BookReadingEvent.ProductDomain.UoW.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices
{
    public class CreateEventService : ICreateEventService, IServiceInterface
    {
        /* private readonly ICreateEventRepositry eventRepositry = null;
         public CreateEventService(ICreateEventRepositry eventrepo)
         {
             eventRepositry = eventrepo;
         }*/
        private readonly ICustomUnitOfWork _customUnitOfWork;
        public CreateEventService(ICustomUnitOfWork customUnitOfWork)
        {
            _customUnitOfWork = customUnitOfWork;
        }
        public bool AddEvent(CreateEventDTO item)
        {
            _customUnitOfWork.createEventRepositry.AddEvent(item);
          //  eventRepositry.AddEvent(item);
            return true;
        }
        public List<CreateEventDTO> GetAllPublicEvent()
        {
            List<CreateEventDTO> storeEvent= new List<CreateEventDTO>();
            try
            {
                storeEvent =_customUnitOfWork.createEventRepositry.UpcomingEvents();
                //storeEvent = eventRepositry.UpcomingEvents();
            }
            catch (Exception ex)
            {
                ExceptionDecator exceptionDecator = new ExceptionDecator(ex);
                Console.WriteLine(exceptionDecator.Message);
            }
            return storeEvent;           
        }
        public List<CreateEventDTO> GetUpcomingEvents()
        {
            List<CreateEventDTO> result = new List<CreateEventDTO>();
           
            List<CreateEventDTO> store;
            try
            {
                store = _customUnitOfWork.createEventRepositry.UpcomingEvents();
                //store = eventRepositry.UpcomingEvents();
                foreach (var x in store)
                {
                    TimeSpan time;
                    TimeSpan.TryParse(x.StartTime, out time);
                    if (DateTime.Compare(DateTime.Now.Date, x.Date) < 0)
                        result.Add(x);
                    else if ((DateTime.Compare(DateTime.Now.Date, x.Date) == 0) && (DateTime.Now.TimeOfDay.CompareTo(time) < 0))
                        result.Add(x);
                }
            }
            catch(Exception ex)
            {
                ExceptionDecator exceptionDecator = new ExceptionDecator(ex);
                Console.WriteLine(exceptionDecator.Message);
            }
            return result;
        }
        public List<CreateEventDTO> GetPastEvents()
        {

            List<CreateEventDTO> result = new List<CreateEventDTO>();

            //  List<CreateEventDTO> store = eventRepositry.UpcomingEvents();
            List<CreateEventDTO> store = _customUnitOfWork.createEventRepositry.UpcomingEvents();
            foreach (var x in store)
            {
                TimeSpan time;
                TimeSpan.TryParse(x.StartTime, out time);
                var y = DateTime.Now.TimeOfDay;
                var z = x.StartTime;
                if (DateTime.Compare(DateTime.Now.Date, x.Date) > 0)
                    result.Add(x);
                else if ((DateTime.Compare(DateTime.Now.Date, x.Date) == 0) && (DateTime.Now.TimeOfDay.CompareTo(time) > 0))
                    result.Add(x);
            }
         
            return result;
        }
        public List<CreateEventDTO> MyEvents(string email)
        {
            return _customUnitOfWork.createEventRepositry.MyEvents(email);
       // return eventRepositry.MyEvents(email);
        }

        public CreateEventDTO GetEventById(int id)
        {
            return _customUnitOfWork.createEventRepositry.GetEventById(id);
            //return eventRepositry.GetEventById(id);
        }
        public void TagInvitedEventToUser(string InvitedUsers, string authorEmailID)
        {
            List<string> AllMailID = FilterInviteByMailString(InvitedUsers, authorEmailID);
            _customUnitOfWork.createEventRepositry.TagInvitedEventToUser(AllMailID);
           // eventRepositry.TagInvitedEventToUser(AllMailID);
            return;
        }
        public List<string> FilterInviteByMailString(string InvitedUsers, string authorEmailID)
        {
            List<string> AllMailID = new List<string>();
            string newMail = "";
            for (int i = 0; i < InvitedUsers.Length; i++)
            {
                if (InvitedUsers[i] != ' ' && InvitedUsers[i] != ',')
                {
                    newMail += InvitedUsers[i];
                }
                else if (InvitedUsers[i] == ',')
                {
                    if (newMail != authorEmailID)
                        AllMailID.Add(newMail);
                    newMail = "";
                }
            }
            if (newMail != "")
                if (newMail != authorEmailID)
                    AllMailID.Add(newMail);
            return AllMailID;
        }
        public void DeleteByEventId(int id)
        {
            _customUnitOfWork.createEventRepositry.DeleteByEventId(id);
            //eventRepositry.DeleteByEventId(id);
        }
        public void UpdateEvent(CreateEventDTO newEvent)
        {
            _customUnitOfWork.createEventRepositry.UpdateEvent(newEvent);
           // eventRepositry.UpdateEvent(newEvent);
        }
        public List<CreateEventDTO> GetAllEvent()
        {
            return _customUnitOfWork.createEventRepositry.GetAllEvent();
           // return eventRepositry.GetAllEvent();
        }
        public void AddComment(CommentDTO commentDetails)
        {
            _customUnitOfWork.createEventRepositry.AddComment(commentDetails);
           // eventRepositry.AddComment(commentDetails);
        }
        public List<CommentDTO> GetAllComments(int ID)
        {
            return _customUnitOfWork.createEventRepositry.GetAllComments(ID);
           // return eventRepositry.GetAllComments(ID);
        }
        public List<CommentDTO> GetCreatorEventComment(string loginemailid)
        {
            return _customUnitOfWork.createEventRepositry.GetCreatorEventComment(loginemailid);
            //return eventRepositry.GetCreatorEventComment(loginemailid);
        }
    }
}

