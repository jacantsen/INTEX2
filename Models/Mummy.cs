using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class Mummy
    {
        [Key]
        public long id { get; set; }
        public string fieldbookexcavationyear { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string fieldbookpage { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string dataexpertinitials { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string squarenorthsouth { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string northsouth { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string squareeastwest { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string eastwest { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string area { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string burialnumber { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string westtohead { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string westtofeet { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string southtohead { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string southtofeet { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string depth { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string length { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string headdirection { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string preservation { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string wrapping { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string adultsubadult { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string sex { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string ageatdeath { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string haircolor { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string samplescollected { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string goods { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string facebundles { get; set; }
        [MaxLength(2000, ErrorMessage = "Must be less than 2000 characters")]
        public string text { get; set; }

        public long? burialid { get; set; }
        [MaxLength(5, ErrorMessage = "Must be less than 5 characters")]
        public string photos { get; set; }
        public DateTime? dateofexcavation { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string shaftnumber { get; set; }
        [MaxLength(200, ErrorMessage = "Must be less than 200 characters")]
        public string clusternumber { get; set; }
        [MaxLength(5, ErrorMessage = "Must be less than 5 characters")]
        public string burialmaterials { get; set; }
        [MaxLength(100, ErrorMessage = "Must be less than 100 characters")]
        public string excavationrecorder { get; set; }
        [MaxLength(5, ErrorMessage = "Must be less than 5 characters")]
        public string hair { get; set; }

        //connects to Textile

        public ICollection<BurialMain_Textile> BurialMain_Textile { get; set; }
    }
}
