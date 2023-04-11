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
        public int id { get; set; }
        public string FieldBookExcavationYear { get; set; }
        public string FieldBookPage { get; set; }
        public string DataExpertInitials { get; set; }
        public string SquareNorthSouth { get; set; }
        public string NorthSouth { get; set; }
        public string SquareEastWest { get; set; }
        public string EastWest { get; set; }
        public string Area { get; set; }
        public string BurialNumber { get; set; }
        public string WestToHead { get; set; }
        public string WestToFeet { get; set; }
        public string SouthToHead { get; set; }
        public string SouthToFeet { get; set; }
        public string Depth { get; set; }
        public string Length { get; set; }
        public string HeadDirection { get; set; }
        public string Preservation { get; set; }
        public string Wrapping { get; set; }
        public string AdultSubadult { get; set; }
        public string Sex { get; set; }
        public string AgeAtDeath { get; set; }
        public string HairColor { get; set; }
        public string SamplesCollected { get; set; }
        public string Goods { get; set; }
        public string FaceBundles { get; set; }
        public string Text { get; set; }
        public string BurialId { get; set; }
        public string Photos { get; set; }
        public string DateOfExcavation { get; set; }
        public string ShaftNumber { get; set; }
        public string ClusterNumber { get; set; }
        public string BurialMaterials { get; set; }
        public string ExcavationRecorder { get; set; }
        public string Hair { get; set; }


    }
}
