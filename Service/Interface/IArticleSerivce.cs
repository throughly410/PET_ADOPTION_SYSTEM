using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Services
{
    public interface IArticleSerivce
    {
        ResultModel CreateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path, string account);
        ResultModel UpdateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path, string account);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleByMember(string CRT_USER);
        ANIMAL_POST_MODEL GetArticleDetail(int POST_ID);
        IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID);
        ResultModel CheckArticleOwner(int POST_ID, string ACCOUNT);
        ResultModel DeleteArticle(int POST_ID);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleImageByPage(IEnumerable<ANIMAL_POST_MODEL> aNIMAL_POST_MODELs);
    }
}