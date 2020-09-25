using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PET_ADOPTION_SYSTEM.Models
{
    public class DropDownItem
    {
        public DropDownItem(string ID, String VAL) 
        {
            this.ID = ID;
            this.VALUE = VAL;
        }
        public string ID { get; set; }
        public string VALUE { get; set; }
    }
}
