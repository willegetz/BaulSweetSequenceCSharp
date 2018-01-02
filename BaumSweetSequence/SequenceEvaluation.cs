using System;

namespace BaumSweetSequence
{
    public class SequenceEvaluation
    {
        public string GetBinaryValue(int startingValue)
        {
            return Convert.ToString(startingValue, 2);
        }

        public string[] GetBlocksOf0s(string binaryConversion)
        {
            return binaryConversion.Split(new char[] { '1' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public int GetBaumSweetEvaluation(string[] sequencesOf0)
        {
            var hasOdd0Sequence = false;
            var baumSweetEvaluation = 1;

            foreach (var seq in sequencesOf0)
            {
                if (seq.Length % 2 == 1)
                {
                    hasOdd0Sequence = true;
                    break;
                }
            }

            if (hasOdd0Sequence)
            {
                baumSweetEvaluation = 0;
            }

            return baumSweetEvaluation;
        }
    }
}
