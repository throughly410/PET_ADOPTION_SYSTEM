using PET_ADOPTION_SYSTEM.Models;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IParamDac
    {
        IEnumerable<SET_PARAM_Model> GetSET_PARAM(string SET_TYPE);
         IEnumerable<CITY_MODEL> GetCITY();
         IEnumerable<AREA_MODEL> GetSET_PARAM(int CITY_ID);
        IEnumerable<ANIMAL_BREED_MODEL> GetANIMAL_BREED(string ANIMAL_KIND);
        IEnumerable<AREA_MODEL> GetAREA(int CITY_ID);
        IEnumerable<SHELTER_MODEL> GetSHELTER();
        IEnumerable<ANNOUNCEMENT_MODEL> GetANNOUNCEMENT();
    }
}