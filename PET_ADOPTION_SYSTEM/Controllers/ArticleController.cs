using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PET_ADOPTION_SYSTEM.Models;
using PET_ADOPTION_SYSTEM.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    [Authorize]
    public class ArticleController : _Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IConfiguration configuration;
        public readonly IParamService paramSerivce;
        public readonly IArticleSerivce articleService;

        public ArticleController(IConfiguration configuration, IParamService paramSerivce, IWebHostEnvironment hostEnvironment, IArticleSerivce articleService)
        {
            this.configuration = configuration;
            this.paramSerivce = paramSerivce;
            this.hostEnvironment = hostEnvironment;
            this.articleService = articleService;
        }
        /// <summary>
        /// 發表文章頁面
        ///
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult PostArticle(int POST_ID, string actionType)
        {
            string path = hostEnvironment.ContentRootPath;
            ViewBag.AnimalSex = new SelectList(paramSerivce.GetSET_PARAM("AnimalSex"), "PARAM_VALUE", "PARAM_DESC");
            ViewBag.AnimalKind = new SelectList(paramSerivce.GetSET_PARAM("AnimalKind"), "PARAM_VALUE", "PARAM_DESC");
            ViewBag.PostType = new SelectList(paramSerivce.GetSET_PARAM("PostType"), "PARAM_VALUE", "PARAM_DESC");
            ViewBag.AnimalBreed = new SelectList(paramSerivce.GetANIMAL_BREED("Cat"), "ANIMAL_BREED_ID", "ANIMAL_BREED_NAME");
            
            ViewBag.actionType = actionType;
            
            return View();
        }
        /// <summary>
        /// 發表文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostArticle([FromBody]ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var user = GetLoginUser();
            string path = hostEnvironment.WebRootPath;
            ResultModel result = articleService.CreateArticle(aNIMAL_POST_MODEL, path, user.ACCOUNT);
            return Json(result);
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditArticle([FromBody] ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var user = GetLoginUser();
            string path = hostEnvironment.WebRootPath;
            ResultModel result = articleService.UpdateArticle(aNIMAL_POST_MODEL, path, user.ACCOUNT);
            return Json(result);
        }
        
        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteArticle([FromBody]int POST_ID)
        {
            var user = GetLoginUser();
            var checkResult = articleService.CheckArticleOwner(POST_ID, user.ACCOUNT);
            if (checkResult.responseStatus == 2)
            {
                return Json(checkResult);
            }
            else
            {
               var result = articleService.DeleteArticle(POST_ID);
                return Json(result);
            }
        }
        /// <summary>
        /// 文章頁面資料
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public JsonResult GetArticleByPage([FromBody]ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var result = articleService.GetArticleByPage(aNIMAL_POST_MODEL);
            if (result is IEnumerable<ANIMAL_POST_MODEL>)
            {
                result = articleService.GetArticleImageByPage(result);
            }
            return Json(result);
        }
        /// <summary>
        /// 我的文章頁面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult MyPost()
        {
            return View();
        }
        /// <summary>
        /// 寵物領養頁面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult PetAdopt()
        {
            return View();
        }
        /// <summary>
        /// 取得個人文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public JsonResult GetArticleByMember()
        {
            var user = GetLoginUser();
            var result = articleService.GetArticleByMember(user.ACCOUNT);
            return Json(result);
        }
        /// <summary>
        /// 取得文章詳細
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public JsonResult GetArticleDetail([FromBody] int POST_ID)
        {
            var result = articleService.GetArticleDetail(POST_ID);
            if (result is ANIMAL_POST_MODEL)
            {
                result.ANIMAL_IMAGE_MODELs = articleService.GetANIMAL_IMAGE(POST_ID).ToList();
            }
            return Json(result);
        }
    }
}
