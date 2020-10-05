using Microsoft.AspNetCore.Hosting;
using PET_ADOPTION_SYSTEM.Dacs;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Services
{
    public class ArticleSerivce : IArticleSerivce
    {
        private IUnitOfWork uow { get; }
        public IArticleDac articleDac { get; }
        public ArticleSerivce(IUnitOfWork uow, IArticleDac articleDac)
        {
            this.uow = uow;
            this.articleDac = articleDac;
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public ResultModel CreateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path, string account)
        {
            aNIMAL_POST_MODEL.CRT_USER = account;
            aNIMAL_POST_MODEL.MDF_USER = account;
            aNIMAL_POST_MODEL.CRT_DATE = DateTime.Now;
            aNIMAL_POST_MODEL.MDF_DATE = DateTime.Now;
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.CRT_USER = account;
                item.MDF_USER = account;
                item.CRT_DATE = DateTime.Now;
                item.MDF_DATE = DateTime.Now;
            }

            uow.Begin();
            uow.Open();
            int id = uow.animalPostDac.Create(aNIMAL_POST_MODEL);
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.POST_ID = id;
                item.IMAGE_ADDRESS = ByteStrToImage(item, path);
                UpdateImage(item);
            }
            uow.Commit();
            var result = new ResultModel()
            {
                message = "新增成功",
                responseStatus = 1
            };
            return result;
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public ResultModel UpdateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path, string account)
        {
            aNIMAL_POST_MODEL.CRT_USER = account;
            aNIMAL_POST_MODEL.MDF_USER = account;
            aNIMAL_POST_MODEL.CRT_DATE = DateTime.Now;
            aNIMAL_POST_MODEL.MDF_DATE = DateTime.Now;
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.CRT_USER = account;
                item.MDF_USER = account;
                item.CRT_DATE = DateTime.Now;
                item.MDF_DATE = DateTime.Now;
            }

            uow.Begin();
            uow.Open();
            articleDac.Update(aNIMAL_POST_MODEL);
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.POST_ID = aNIMAL_POST_MODEL.POST_ID;
                item.IMAGE_ADDRESS = ByteStrToImage(item, path);
                UpdateImage(item);
            }
            uow.Commit();
            var result = new ResultModel()
            {
                message = "編輯成功",
                responseStatus = 1
            };
            return result;
        }

        /// <summary>
        /// 圖片更新
        /// </summary>
        /// <param name="aNIMAL_IMAGE_MODEL"></param>
        public void UpdateImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL)
        {
            uow.animalImageDac.Update(aNIMAL_IMAGE_MODEL);
            //articleDac.UpdateImage(aNIMAL_IMAGE_MODEL);
        }

        public string ByteStrToImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL, string path)
        {
            string iconString = aNIMAL_IMAGE_MODEL.IMAGE_UINT8ARRAY;
            string[] textArray = iconString.Split(',');
            var byt = textArray.Select(byte.Parse).ToArray();
            string imgName = GetGuidString();
            path = path + @"\img\";
            Image image = null;
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(byt))
                {
                    memoryStream.Position = 0;
                    image = Image.FromStream(memoryStream);
                    image.Save(path + imgName + aNIMAL_IMAGE_MODEL.EXTENSION, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return "~/img/"+ imgName+ aNIMAL_IMAGE_MODEL.EXTENSION;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 取得GUID隨機字串
        /// </summary>
        /// <returns></returns>
        public string GetGuidString()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 取得個人文章
        /// </summary>
        /// <param name="CRT_USER"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_POST_MODEL> GetArticleByMember(string CRT_USER)
        {

            //var result = articleDac.GetANIMAL_POST_ByMember(CRT_USER);
            var result = uow.animalPostDac.GetANIMAL_POST_ByMember(CRT_USER);
            return result;
        }
        /// <summary>
        /// 取得單一文章詳細
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public ANIMAL_POST_MODEL GetArticleDetail(int POST_ID)
        {
            var postModel = new ANIMAL_POST_MODEL() { POST_ID = POST_ID };
            var result = uow.animalPostDac.GetById(postModel);
            return result;
        }
        /// <summary>
        /// 取得動物照片
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID)
        {

            //var result = articleDac.GetANIMAL_IMAGE(POST_ID);
            var result = uow.animalImageDac.GetANIMAL_IMAGEs_ById(POST_ID);
            return result;
        }
        /// <summary>
        /// 確認文章擁有者
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <param name="ACCOUNT"></param>
        /// <returns></returns>
        public ResultModel CheckArticleOwner(int POST_ID, string ACCOUNT)
        {
            var postModel = new ANIMAL_POST_MODEL() { POST_ID = POST_ID };
            var article = uow.animalPostDac.GetById(postModel);
            var result = new ResultModel();
            if(article.CRT_USER != ACCOUNT)
            {
                result.responseStatus = 2;
                result.message = "非此文章作者，無法刪除文章";
            }
            else
            {
                result.responseStatus = 1;
            }
            return result;
        }
        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public ResultModel DeleteArticle(int POST_ID)
        {
            uow.Begin();
            uow.Open();
            var delArticle = new ANIMAL_POST_MODEL() { POST_ID = POST_ID };
            uow.animalPostDac.Delete(delArticle);
            uow.Commit();
            var result = new ResultModel()
            {
                message = "刪除文章成功",
                responseStatus = 1

            };
            return result;
        }
        public IEnumerable<ANIMAL_POST_MODEL> GetArticleByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            //var result = articleDac.GetANIMLA_POST_ByPage(aNIMAL_POST_MODEL);
            var result = uow.animalPostDac.GetANIMLA_POST_ByPage(aNIMAL_POST_MODEL);
            return result;
        }

        public IEnumerable<ANIMAL_POST_MODEL> GetArticleImageByPage(IEnumerable<ANIMAL_POST_MODEL> aNIMAL_POST_MODELs)
        {
            var postIds = aNIMAL_POST_MODELs.Select(m => m.POST_ID).ToList();
            //var images = articleDac.GetANIMAL_IMAGE_ByPage(postIds);
            var images = uow.animalImageDac.GetANIMAL_IMAGE_ByPage(postIds);
            foreach (var post in aNIMAL_POST_MODELs)
            {
                post.ANIMAL_IMAGE_MODELs = images.Where(m => m.POST_ID == post.POST_ID).ToList();
            }
            return aNIMAL_POST_MODELs;
        }


    }
}
