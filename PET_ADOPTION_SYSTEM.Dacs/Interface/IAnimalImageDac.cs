using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IAnimalImageDac:IGenericRepository<ANIMAL_IMAGE_MODEL>
    {
        IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGEs_ById(int POST_ID);
        IEnumerable<ANIMAL_IMAGE_MODEL> GetANIMAL_IMAGE_ByPage(List<int> postIds);
    }
}