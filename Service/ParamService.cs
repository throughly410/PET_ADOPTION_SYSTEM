using PET_ADOPTION_SYSTEM.Dacs;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Services
{
    public class ParamService : IParamService
    {
        private readonly IParamDac paramDac;
        public ParamService(IParamDac paramDac)
        {
            this.paramDac = paramDac;
        }
        public IEnumerable<SET_PARAM_Model> GetSET_PARAM(string SET_TYPE)
        {
            var result = paramDac.GetSET_PARAM(SET_TYPE);
            return result;
        }
        public IEnumerable<ANIMAL_BREED_MODEL> GetANIMAL_BREED(string ANIMAL_KIND)
        {
            var result = paramDac.GetANIMAL_BREED(ANIMAL_KIND);
            return result;
        }
        public IEnumerable<CITY_MODEL> GetCity()
        {
            var result = paramDac.GetCITY();
            return result;
        }
        public IEnumerable<AREA_MODEL> GetArea(int CITY_ID)
        {
            var result = paramDac.GetAREA(CITY_ID);
            return result;
        }
    }
}
