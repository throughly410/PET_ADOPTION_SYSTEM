﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class ManageController : _Controller
    {
        /// <summary>
        /// 後臺管理頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult AdminManage()
        {
            return View();
        }
    }
}
