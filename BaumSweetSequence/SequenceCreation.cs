using System;
using System.Collections.Generic;
using System.Text;

namespace BaumSweetSequence
{
    public class SequenceCreation
    {
        private readonly SequenceEvaluation evaluator;

        public SequenceCreation()
        {
            evaluator = new SequenceEvaluation();
        }

        public IEnumerable<int> GetBaumSweetSequenceListFor(int numberToEvaluate)
        {
            var evaluator = new SequenceEvaluation();
            var baumSweetSequence = new List<int>() { 1 };
            for (int i = 1; i <= numberToEvaluate; i++)
            {
                var binaryConversion = evaluator.GetBinaryValue(i);
                var sequenceOf0s = evaluator.GetBlocksOf0s(binaryConversion);
                var sequenceEvaluation = evaluator.GetBaumSweetEvaluation(sequenceOf0s);

                baumSweetSequence.Add(sequenceEvaluation);
            }

            return baumSweetSequence;
        }
    }
}
