using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Services
{
    public class ShelterService : IShelterService
    {
        public string JoinQueryParam(SHELTER_PARAM_MODEL sHELTER_PARAM_MODEL)
        {
            //可改reflection做法
            //https://dotblogs.com.tw/BenHuang/2019/06/26/CSharpGetClassPropertyNameAndValue
            ArrayList paramList = new ArrayList()
            {
                string.IsNullOrWhiteSpace(sHELTER_PARAM_MODEL.animal_bodytype) ? "" : "animal_bodytype="+sHELTER_PARAM_MODEL.animal_bodytype,
                string.IsNullOrWhiteSpace(sHELTER_PARAM_MODEL.animal_kind) ? "" : "animal_kind="+sHELTER_PARAM_MODEL.animal_kind,
                string.IsNullOrWhiteSpace(sHELTER_PARAM_MODEL.animal_sex) ? "" : "animal_sex="+sHELTER_PARAM_MODEL.animal_sex,
                sHELTER_PARAM_MODEL.animal_shelter_pkid == 0 ? "" : "animal_shelter_pkid="+sHELTER_PARAM_MODEL.animal_shelter_pkid,
                string.IsNullOrWhiteSpace(sHELTER_PARAM_MODEL.animal_status) ? "" : "animal_status="+sHELTER_PARAM_MODEL.animal_status
            };
            string result = "&" + string.Join("&", paramList.ToArray().Where(m => !string.IsNullOrWhiteSpace(m.ToString())));
            result = result.Length == 1 ? "" : result;
            return result;
        }
    }
}
