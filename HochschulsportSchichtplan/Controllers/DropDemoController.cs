using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HochschulsportSchichtplan.Controllers
{
    public class DropDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}