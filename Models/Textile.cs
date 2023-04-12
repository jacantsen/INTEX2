using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INTEX2.Models
{
    public class Textile
    {
        //[Key]
        public long id { get; set; }
        //public long textileid { get; set; }
        public string burialnumber { get; set; }
        public string direction { get; set; }
        public string locale { get; set; }
        public string description { get; set; }
        public string estimatedperiod { get; set; }
        public DateTime photographeddate { get; set; }
        public DateTime sampledate { get; set; }
        //mabye named wrong?

        // Navigation property for the related Mummy
        public ColorTextile ColorTextile { get; set;}

        public BurialMain_Textile BurialMain_Textile { get; set; }
    }

}
