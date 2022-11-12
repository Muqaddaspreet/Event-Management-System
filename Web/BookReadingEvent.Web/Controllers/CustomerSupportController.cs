using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Controllers
{
    public class CustomerSupportController : Controller
    {
        public RedirectResult Index()
        {
           return Redirect("https://www.helpdesk.nagarro.com");
           
        }
    }
}
