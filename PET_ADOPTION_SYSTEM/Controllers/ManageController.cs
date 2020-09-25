using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class ManageController : _Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
