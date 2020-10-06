using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PET_ADOPTION_SYSTEM.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PET_ADOPTION_SYSTEM.Filters
{
    public class ActionFilter:IActionFilter
    {
        /// <summary>
        /// 將登入使用者資料拋到前端
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Controller is Controller controller)
            {
                
                controller.ViewBag.loginUser = null;
                controller.ViewBag.role = "0";
                var result = context.Result as ViewResult;
                var c = context.HttpContext.User.Identity as ClaimsIdentity;
                if (c.Claims.Any())
                {
                    controller.ViewBag.name = c.Claims.First().Value.ToString();
                    controller.ViewBag.role = c.Claims.Skip(1).First().Value.ToString(); 
                    controller.ViewBag.loginUser = c.Claims.Skip(2).First().Value.ToString(); 

                }
                if (result != null)
                {
                    switch (controller.ViewBag.role)
                    {
                        case "0":
                            result.ViewData["LayoutName"] = "_Layout";
                            break;
                        case "1":
                            result.ViewData["LayoutName"] = "_LayoutUser";
                            break;
                        case "2":
                            result.ViewData["LayoutName"] = "_LayoutAdmin";
                            break;
                        default:
                            break;
                    }
                }
            }


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
