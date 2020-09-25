using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IArticleDac
    {
        int Create(ANIMAL_POST_MODEL aNIMAL_POST_MODEL);
        void Update(ANIMAL_POST_MODEL aNIMAL_POST_MODEL);
        void UpdateImage(ANIMAL_IMAGE_MODEL aNIMAL_IMAGE_MODEL);
        IEnumerable<ANIMAL_POST_MODEL> GetANIMAL_POST_ByMember(string CRT_USER);
        ANIMAL_POST_MODEL GetANIMAL_POST_Detail(int POST_ID);
        IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE(int POST_ID);
    }
}