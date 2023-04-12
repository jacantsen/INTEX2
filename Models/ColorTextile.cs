using System.Linq;
using INTEX2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEX2.Models
{
    public class ColorTextile
    {

        //public long main$colorid { get; set; }
       
        [Column("main$colorid")]
        public long colorid { get; set; }
        [Column("main$textileid")]
        public long textileid { get; set; }

        public Color Color { get; set; }
        public Textile Textile { get; set; }

    }
}
