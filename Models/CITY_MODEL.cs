using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class CITY_MODEL
    {
        public int CITY_ID { get; set; }
        public string CITY_NAME {get;set;}
        public string CITY_ENG_NAME {get;set;}

    }

    public class AREA_MODEL
    {
        public int AREA_ID { get; set; }
        public int CITY_ID { get; set; }
        public string ZIP_CODE { get; set; }
        public string AREA_NAME { get; set; }
        public string AREA_ENG_NAME { get; set; }
    }
}
