using System.ComponentModel.DataAnnotations;

namespace INTEX2.Models
{
    public class SearchSpecifications
    {
        public long? burialId { get; set; }
        public string sex { get; set; }
        public string depth { get; set; }
        public string textileColor { get; set; }
        public string textileStructure { get; set; }
        public string deathAge { get; set; }
        public string headDirection { get; set; }
        public string textileFunction { get; set; }
        public string hairColor { get; set; }
        public string faceBundle { get; set; }


    }
}
