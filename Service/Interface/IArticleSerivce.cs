using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Services
{
    public interface IArticleSerivce
    {
        string ByteStrToImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL, string path);
        RESULT_MODEL CreateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path);
        string GetGuidString();
        RESULT_MODEL UpdateArticle(ANIMAL_POST_MODEL aNIMAL_POST_MODEL, string path);
        void UpdateImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleByMember(string CRT_USER);
        ANIMAL_POST_MODEL GetArticleDetail(int POST_ID);
        IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID);
        RESULT_MODEL CheckArticleOwner(int POST_ID, string ACCOUNT);
        RESULT_MODEL DeleteArticle(int POST_ID);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL);
        IEnumerable<ANIMAL_POST_MODEL> GetArticleImageByPage(IEnumerable<ANIMAL_POST_MODEL> aNIMAL_POST_MODELs);
    }
}