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
        public IArticleDac articleDac { get; }
        public ArticleSerivce(IArticleDac articleDac)
        {
            this.articleDac = articleDac;
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="aNIMAL_POST_MODEL"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public RESULT_MODEL CreateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path)
        {
            int id = articleDac.Create(aNIMAL_POST_MODEL);
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.POST_ID = id;
                item.IMAGE_ADDRESS = ByteStrToImage(item, path);
                UpdateImage(item);
            }
            
            var result = new RESULT_MODEL()
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
        public RESULT_MODEL UpdateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path)
        {
            articleDac.Update(aNIMAL_POST_MODEL);
            foreach (var item in aNIMAL_POST_MODEL.ANIMAL_IMAGE_MODELs)
            {
                item.POST_ID = aNIMAL_POST_MODEL.POST_ID;
                item.IMAGE_ADDRESS = ByteStrToImage(item, path);
                UpdateImage(item);
            }
            var result = new RESULT_MODEL()
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
            articleDac.UpdateImage(aNIMAL_IMAGE_MODEL);
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
            var result = articleDac.GetANIMAL_POST_ByMember(CRT_USER);
            return result;
        }
        /// <summary>
        /// 取得單一文章詳細
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public ANIMAL_POST_MODEL GetArticleDetail(int POST_ID)
        {
            var result = articleDac.GetANIMAL_POST_Detail(POST_ID);
            return result;
        }
        /// <summary>
        /// 取得動物照片
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID)
        {
            var result = articleDac.GetANIMAL_IMAGE(POST_ID);
            return result;
        }
        /// <summary>
        /// 確認文章擁有者
        /// </summary>
        /// <param name="POST_ID"></param>
        /// <param name="ACCOUNT"></param>
        /// <returns></returns>
        public RESULT_MODEL CheckArticleOwner(int POST_ID, string ACCOUNT)
        {
            var article = articleDac.GetANIMAL_POST_Detail(POST_ID);
            var result = new RESULT_MODEL();
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
        public RESULT_MODEL DeleteArticle(int POST_ID)
        {
            articleDac.DeleteANIMAL_POST(POST_ID);
            var result = new RESULT_MODEL()
            {
                message = "刪除文章成功",
                responseStatus = 1

            };
            return result;
        }
        public IEnumerable<ANIMAL_POST_MODEL> GetArticleByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL)
        {
            var result = articleDac.GetANIMLA_POST_ByPage(aNIMAL_POST_MODEL);
            return result;
        }

        public IEnumerable<ANIMAL_POST_MODEL> GetArticleImageByPage(IEnumerable<ANIMAL_POST_MODEL> aNIMAL_POST_MODELs)
        {
            var postIds = aNIMAL_POST_MODELs.Select(m => m.POST_ID).ToList();
            var images = articleDac.GetANIMAL_IMAGE_ByPage(postIds);
            foreach (var post in aNIMAL_POST_MODELs)
            {
                post.ANIMAL_IMAGE_MODELs = images.Where(m => m.POST_ID == post.POST_ID).ToList();
            }
            return aNIMAL_POST_MODELs;
        }


    }
}
