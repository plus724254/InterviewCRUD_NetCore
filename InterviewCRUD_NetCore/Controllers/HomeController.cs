using InterviewCRUD_NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewCRUD_NetCore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }

        public ActionResult CourseSelection()
        {
            return View();
        }
    }
}
