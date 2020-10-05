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
        /// <summary>
        /// 取得登入者資訊
        /// </summary>
        /// <returns></returns>
        public MEMBER_MODEL GetLoginUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity.Claims;
            MEMBER_MODEL user = null;
            if (claims.Any())
            {
                user = new MEMBER_MODEL();
                user.NAME = claims.Where(m=>m.Type== "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault().Value.ToString();
                user.ROLE = int.Parse(claims.Where(m=>m.Type== "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault().Value);
                user.ACCOUNT = claims.Where(m=>m.Type=="Account").FirstOrDefault().Value.ToString();
            }
            return user;
        }
    }
}
