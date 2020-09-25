using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PET_ADOPTION_SYSTEM.Models;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class _Controller : Controller
    {
        public MEMBER_MODEL GetLoginUser()
        {
            var a = HttpContext.User.Identity as ClaimsIdentity;
            MEMBER_MODEL user = null;
            if (a.Claims.Any())
            {
                user = new MEMBER_MODEL();
                user.NAME = a.Claims.First().Value.ToString();
                user.ROLE = int.Parse(a.Claims.Skip(1).First().Value);
                user.ACCOUNT = a.Claims.Skip(2).First().Value.ToString();


            }
            return user;
        }
    }
}
