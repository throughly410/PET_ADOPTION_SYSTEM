using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class MEMBER_MODEL:_MODEL
    {
        [Required]
        public string ACCOUNT { get; set; }
        public string PASSWORD { get; set; }
        [Compare(nameof(PASSWORD))]
        public string VERIFIED_PASSWORD { get; set; }
        public string NAME {get;set;}
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public int ROLE { get; set; }
    }
}
