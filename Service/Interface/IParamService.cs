using PET_ADOPTION_SYSTEM.Models;
using System.Collections;
using System.Collections.Generic;

namespace PET_ADOPTION_SYSTEM.Services
{
    public interface IParamService
    {
        IEnumerable<SET_PARAM_Model> GetSET_PARAM(string SET_TYPE);
        IEnumerable<ANIMAL_BREED_MODEL> GetANIMAL_BREED(string ANIMAL_KIND);
        IEnumerable<CITY_MODEL> GetCity();
        IEnumerable<AREA_MODEL> GetArea(int CITY_ID);

    }
}