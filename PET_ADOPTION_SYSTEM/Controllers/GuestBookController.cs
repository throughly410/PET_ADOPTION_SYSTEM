using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class GuestBookController:_Controller
    {
        /// <summary>
        /// 留言版頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult GuestBook()
        {
            return View();
        }
    }
}
