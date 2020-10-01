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
        /// <summary>
        /// 取得參數
        /// </summary>
        /// <param name="SET_TYPE"></param>
        /// <returns></returns>
        public IEnumerable<SET_PARAM_Model> GetSET_PARAM(string SET_TYPE)
        {
            var result = paramDac.GetSET_PARAM(SET_TYPE);
            return result;
        }
        /// <summary>
        /// 取得動物品種
        /// </summary>
        /// <param name="ANIMAL_KIND"></param>
        /// <returns></returns>
        public IEnumerable<ANIMAL_BREED_MODEL> GetANIMAL_BREED(string ANIMAL_KIND)
        {
            var result = paramDac.GetANIMAL_BREED(ANIMAL_KIND);
            return result;
        }
        /// <summary>
        /// 取得縣市資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CITY_MODEL> GetCity()
        {
            var result = paramDac.GetCITY();
            return result;
        }
        /// <summary>
        /// 取得某縣市的鄉鎮市區
        /// </summary>
        /// <param name="CITY_ID"></param>
        /// <returns></returns>
        public IEnumerable<AREA_MODEL> GetArea(int CITY_ID)
        {
            var result = paramDac.GetAREA(CITY_ID);
            return result;
        }

        //public IEnumerable<SHELTER_PARAM_MODEL> GetAnimalBodytype()
        //{

        //}
        //public IEnumerable<SHELTER_PARAM_MODEL> GetAnimalStatus()
        //{

        //}
        //public IEnumerable<SHELTER_PARAM_MODEL> GetAnimal_kind()
        //{

        //}
        public IEnumerable<SHELTER_MODEL> GetAnimalShelter()
        {
            var result = paramDac.GetSHELTER();
            return result;
        }

        public IEnumerable<ANNOUNCEMENT_MODEL> GetAnnouncement()
        {
            var result = paramDac.GetANNOUNCEMENT();
            return result;
        }


    }
}
