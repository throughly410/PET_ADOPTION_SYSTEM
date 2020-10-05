using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PET_ADOPTION_SYSTEM.Models;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    /// <summary>
    /// 寵物協尋頁面
    /// </summary>
    public class StrayController : _Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}
