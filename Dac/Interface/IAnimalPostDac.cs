using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IAnimalPostDac:IGenericRepository<ANIMAL_POST_MODEL>
    {
        IEnumerable<ANIMAL_POST_MODEL> GetANIMAL_POST_ByMember(string CRT_USER);
        IEnumerable<ANIMAL_POST_MODEL> GetANIMLA_POST_ByPage(ANIMAL_POST_MODEL aNIMAL_POST_MODEL);
    }
}