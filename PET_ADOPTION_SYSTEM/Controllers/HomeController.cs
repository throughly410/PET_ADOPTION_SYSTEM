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

namespace PET_ADOPTION_SYSTEM.Controllers
{
    
    [AllowAnonymous]
    public class HomeController:_Controller
    {
        public IConfiguration configuration { get; }
        public IMemberService memberService { get; }

        public HomeController(IConfiguration configuration, IMemberService memberService)
        {
            this.configuration = configuration;
            this.memberService = memberService;
        }
        public IActionResult Index()
        {
            //GetLoginUser();
            return View();
        }
       
        public JsonResult GetAllMembers(MEMBER_MODEL mEMBER_MODEL)
        {
            var member = memberService.GetMember(mEMBER_MODEL);
            return Json(member);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(MEMBER_MODEL memberModel)
        {
            memberService.InsertMember(memberModel);
            return View();
        }

        [HttpPost]
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
        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UploadImage()
        {
            return View();
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
