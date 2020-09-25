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
        //新增文章
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

        //修改文章
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

        //圖片更新
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
                    image.Save(path + imgName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    return "~/img/"+ imgName+ ".jpg";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetGuidString()
        {
            return Guid.NewGuid().ToString("N");
        }


        public IEnumerable<ANIMAL_POST_MODEL> GetArticleByMember(string CRT_USER)
        {
            var result = articleDac.GetANIMAL_POST_ByMember(CRT_USER);
            return result;
        }

        public ANIMAL_POST_MODEL GetArticleDetail(int POST_ID)
        {
            var result = articleDac.GetANIMAL_POST_Detail(POST_ID);
            return result;
        }

        public IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID)
        {
            var result = articleDac.GetANIMAL_IMAGE(POST_ID);
            return result;
        }
    }
}
