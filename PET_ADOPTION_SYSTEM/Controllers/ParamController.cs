using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PET_ADOPTION_SYSTEM.Models;
using PET_ADOPTION_SYSTEM.Services;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    [AllowAnonymous]
    public class ParamController : _Controller
    {
        private readonly IParamService paramSerivce;
        private readonly IArticleSerivce articleService;
        public ParamController(IParamService paramSerivce, IArticleSerivce articleService)
        {
            this.paramSerivce = paramSerivce;
            this.articleService = articleService;
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
        public JsonResult GetArea([FromBody] int CITY_ID)
        {
            var result = paramSerivce.GetArea(CITY_ID);
            return Json(result);
        }
        /// <summary>
        /// 取得公告事項
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAnnouncement()
        {
            var result = paramSerivce.GetAnnouncement();
            return Json(result);
        }
    }
}
