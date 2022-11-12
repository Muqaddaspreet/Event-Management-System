using BookReadingEvent.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace BookReadingEvent.Web.Infrastructure
{
    public class DecoratorRole
    {
        public UserLogin user = new UserLogin();
        public string role = null;
        public DecoratorRole(UserLogin UserDetails)
        {
            user = UserDetails;
            if (UserDetails.EmailID != "myadmin@bookevents.com")
            {
                role = "user";
            }
            else
            {
                role = "admin";
            }

        }
    }
}