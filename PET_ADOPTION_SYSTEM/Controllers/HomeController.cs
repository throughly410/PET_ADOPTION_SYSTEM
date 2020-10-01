using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Security.Claims;
using PET_ADOPTION_SYSTEM.Services;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace PET_ADOPTION_SYSTEM.Controllers
{

    [AllowAnonymous]
    public class HomeController : _Controller
    {
        private readonly ILogger logger;
        public IConfiguration configuration { get; }
        public IMemberService memberService { get; }

        public HomeController(ILogger<HomeController> _logger, IConfiguration configuration, IMemberService memberService)
        {
            this.logger = _logger;
            this.configuration = configuration;
            this.memberService = memberService;
        }
        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            logger.LogTrace("Loggin Level = 0 (Trace)");
            logger.LogDebug("Loggin Level = 1 (Debug)");
            logger.LogInformation("Loggin Level = 2 (Information)");
            logger.LogWarning("Loggin Level = 3 (Warning )");
            logger.LogError("Loggin Level = 4 (Error)");
            logger.LogCritical("Loggin Level = 5 (Critical)");
            //GetLoginUser();
            return View();
        }
       
        public JsonResult GetAllMembers(MEMBER_MODEL mEMBER_MODEL)
        {
            var member = memberService.GetMember(mEMBER_MODEL);
            return Json(member);
        }
        /// <summary>
        /// 註冊頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(MEMBER_MODEL memberModel)
        {
            memberService.InsertMember(memberModel);
            return View();
        }
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(MEMBER_MODEL model)
        {
            var user = memberService.GetMember(model);
            if (user != null)
            {
                Claim[] claims = new[] 
                { 
                    new Claim(ClaimTypes.Name, user.NAME), 
                    new Claim(ClaimTypes.Role, user.ROLE.ToString()), 
                    new Claim("Account", user.ACCOUNT) 
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties()
                {
                    AllowRefresh = false,
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                });
            }
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult AdminManage()
        {
            return View();
        }
        public IActionResult GuestBook()
        {
            return View();
        }
        public IActionResult MyPost()
        {
            return View();
        }
        public IActionResult PetAdopt()
        {
            return View();
        }
        public IActionResult PetAdoptDetail()
        {
            return View();
        }


    }
}
