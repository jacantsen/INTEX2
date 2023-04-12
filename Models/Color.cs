namespace INTEX2.Models
{
    public class Color
    {
        public long id { get; set; }
        public string value { get; set; }
        //public long colorid { get; set; }

        // Navigation property for the related Textile
        public ColorTextile ColorTextile { get; set; }


        // white, peach purple, yellow, red, brown, other, beige, undyed, blue, purple/brown, tan, green, black
    }
}
