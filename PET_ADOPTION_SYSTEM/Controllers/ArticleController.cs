using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PET_ADOPTION_SYSTEM.Models;
using PET_ADOPTION_SYSTEM.Services;
using System;
using System.Linq;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class ArticleController : _Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;
        public IConfiguration configuration { get; }
        public IParamService paramSerivce { get; }
        public IArticleSerivce articleService { get; }

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
        public IActionResult PostArticle(int POST_ID, string actionType)
        {
            string path = hostEnvironment.ContentRootPath;
            ViewBag.AnimalSex = new SelectList(paramSerivce.GetSET_PARAM("AnimalSex"), "PARAM_VALUE", "PARAM_DESC");
            ViewBag.AnimalKind = new SelectList(paramSerivce.GetSET_PARAM("AnimalKind"), "PARAM_VALUE", "PARAM_DESC");
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
        public JsonResult PostArticle([FromBody]ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var user = GetLoginUser();
            aNIMAL_POST_MODEL.CRT_USER = user.ACCOUNT;
            aNIMAL_POST_MODEL.MDF_USER = user.ACCOUNT;
            aNIMAL_POST_MODEL.CRT_DATE = DateTime.Now;
            aNIMAL_POST_MODEL.MDF_DATE = DateTime.Now;
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.CRT_USER = user.ACCOUNT;
                item.MDF_USER = user.ACCOUNT;
                item.CRT_DATE = DateTime.Now;
                item.MDF_DATE = DateTime.Now;
            }
            string path = hostEnvironment.WebRootPath;
            RESULT_MODEL result = articleService.CreateArticle(aNIMAL_POST_MODEL, path);
            return Json(result);
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <returns></returns>
        public JsonResult EditArticle([FromBody] ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var user = GetLoginUser();
            aNIMAL_POST_MODEL.CRT_USER = user.ACCOUNT;
            aNIMAL_POST_MODEL.MDF_USER = user.ACCOUNT;
            aNIMAL_POST_MODEL.CRT_DATE = DateTime.Now;
            aNIMAL_POST_MODEL.MDF_DATE = DateTime.Now;
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.CRT_USER = user.ACCOUNT;
                item.MDF_USER = user.ACCOUNT;
                item.CRT_DATE = DateTime.Now;
                item.MDF_DATE = DateTime.Now;
            }
            string path = hostEnvironment.WebRootPath;
            RESULT_MODEL result = articleService.UpdateArticle(aNIMAL_POST_MODEL, path);
            return Json(result);
        }
        /// <summary>
        /// 取得動物品種
        /// </summary>
        /// <param name="ANIMAL_KIND"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAnimalBreed([FromBody] string ANIMAL_KIND)
        {
            var result = paramSerivce.GetANIMAL_BREED(ANIMAL_KIND);
            return Json(result);
        }
        /// <summary>
        /// 取得縣市資料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetCity()
        {
            var result = paramSerivce.GetCity();
            return Json(result);
        }
        [HttpPost]
        public JsonResult GetArea([FromBody]int CITY_ID)
        { 
            var result = paramSerivce.GetArea(CITY_ID);
            return Json(result);
        }
        /// <summary>
        /// 取得個人文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
        public JsonResult GetArticleDetail([FromBody]int POST_ID)
        {
            var result = articleService.GetArticleDetail (POST_ID);
            if(result is ANIMAL_POST_MODEL)
            {
                result.ANIMAL_IMAGE_MODELs = articleService.GetANIMAL_IMAGE(POST_ID).ToList();
            }
            return Json(result);
        }
    }
}
