using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class ANIMAL_IMAGE_MODEL:_MODEL
    {
        public int POST_ID { get; set; }
        public int SEQ { get; set; }
        public string IMAGE_ADDRESS { get; set; }
        public string IMAGE_UINT8ARRAY { get; set; }
    }
}
