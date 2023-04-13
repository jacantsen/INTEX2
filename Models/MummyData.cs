using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX2.Models
{
    public class MummyData
    {
        public float squarenorthsouth { get; set; }
        public float squareeastwest { get; set; }

        public float depth { get; set; }

        public float length { get; set; }


        public float adultsubadult_A { get; set; }

        public float adultsubadult_C { get; set; }

        public float wrapping_B { get; set; }

        public float wrapping_H { get; set; }

        public float wrapping_W { get; set; }




        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                squarenorthsouth, squareeastwest, depth, length,
                adultsubadult_A, adultsubadult_C, wrapping_B, wrapping_H, wrapping_W
            };
            int[] dimensions = new int[] { 1, 9 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
