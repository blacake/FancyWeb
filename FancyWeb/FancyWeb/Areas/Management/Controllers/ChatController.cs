﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FancyWeb.Areas.Management.Controllers
{
    public class ChatController : Controller
    {
        // GET: Management/Chat
        public ActionResult Index()
        {
            return View();
        }
    }
}