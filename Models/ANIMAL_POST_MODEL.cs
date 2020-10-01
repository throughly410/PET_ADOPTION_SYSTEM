using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class ANIMAL_POST_MODEL : _MODEL
    {
        /// <summary>
        /// 文章流水號
        /// </summary>
        public int POST_ID { get; set; }
        public string TITLE { get; set; }
        /// <summary>
        /// 晶片號碼
        /// </summary>
        [StringLength(15, MinimumLength = 10)]
        public string CHIP_NO { get; set; }
        /// <summary>
        /// 動物類別
        /// </summary>

        public string ANIMAL_KIND { get; set; }
        /// <summary>
        /// 動物品種
        /// </summary>
        public string ANIMAL_BREED { get; set; }
        public string ANIMAL_BREED_NAME { get; set; }
        public int CITY_ID { get; set; }
        public int AREA_ID { get; set; }
        public string AREA_NAME { get; set; }
        /// <summary>
        /// 動物性別
        /// </summary>
        public string ANIMAL_SEX { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        [StringLength(72)]
        public string REASON { get; set; }
        /// <summary>
        /// 文章類型
        /// </summary>
        public int POST_TYPE { get; set; }
        /// <summary>
        /// 備注
        /// </summary>
        [StringLength(108)]
        public string MEMO { get; set; }
        /// <summary>
        /// 動物照片
        /// </summary>
        public List<ANIMAL_IMAGE_MODEL> ANIMAL_IMAGE_MODELs {get;set;}
    }
}
