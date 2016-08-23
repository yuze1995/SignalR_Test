using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR_Test.Controllers
{
    public class ChatController : Controller
    {
        public ActionResult Chat_All()
        {
            return View();
        }

        public ActionResult Chat_Group()
        {
            return View();
        }
    }
}