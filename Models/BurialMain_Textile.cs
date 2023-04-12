using INTEX2.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEX2.Models
{
    public class BurialMain_Textile
    {

        //public long main$textileid { get; set; }

        [Column("main$textileid")]
        public long textileid { get; set; }
        [Column("main$burialmainid")]
        public long burialmainid { get; set; }
        public Textile Textile { get; set; }
        public Mummy Mummy { get; set; }


    }
}
