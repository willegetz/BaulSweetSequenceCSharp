using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ApprovalTests.Reporters;
using ApprovalTests;

namespace BaumSweetSequenceTests
{
    [TestClass]
    [UseReporter(typeof(BeyondCompare4Reporter))]
    public class SequenceTests
    {
        // Convert number to binary :: Binary output is a string
        // Drop preceeding 0's :: Happens on conversion to binary
        //  Minimum number of digits is 1
        // Find all sequences of 0's
        // Does any sequence contain an odd number of 0's?
        //  If Yes: This is a value of 1
        //  If No: This is a value of 0
        // Absence of any 0's in a binary value is considered an absence of any 0 sequence of odd value
        // Iteration of numbers begins at number 0 and loops until reaching the final number

        [TestMethod]
        public void BinaryConversionTest()
        {
            var startingValue = 1;

            var actual = Convert.ToString(startingValue, 2);

            var expected = "1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Number2HasOdd0Sequence()
        {
            var startingValue = 2;

            var binaryConversion = GetBinaryValue(startingValue);
            var sequencesOf0 = GetBlocksOf0s(binaryConversion);
            var baumSweetEvaluation = GetBaumSweetEvaluation(sequencesOf0);

            var expected = 0;

            Assert.AreEqual(expected, baumSweetEvaluation, "Evaluation contains no block of consecutive 0s of odd length");
        }

        [TestMethod]
        public void Number1DoesNotHaveOdd0Sequence()
        {
            var startingValue = 1;

            var binaryConversion = GetBinaryValue(startingValue);
            var sequencesOf0 = GetBlocksOf0s(binaryConversion);
            int baumSweetEvaluation = GetBaumSweetEvaluation(sequencesOf0);

            var expected = 1;

            Assert.AreEqual(expected, baumSweetEvaluation, "Evaluation contains 1 or more blocks of consecutive 0s of odd length");
        }

        [TestMethod]
        public void BaumSweetSequenceFor2Is1and1and0()
        {
            var baumSweetSequence = new List<int>() { 1 };

            var numberToEvaluate = 2;

            for (int i = 1; i <= numberToEvaluate; i++)
            {
                var binaryConversion = GetBinaryValue(i);
                var sequenceOf0s = GetBlocksOf0s(binaryConversion);
                var sequenceEvaluation = GetBaumSweetEvaluation(sequenceOf0s);

                baumSweetSequence.Add(sequenceEvaluation);
            }

            Approvals.VerifyAll(baumSweetSequence, "b_");
        }
        
        private string GetBinaryValue(int startingValue)
        {
            return Convert.ToString(startingValue, 2);
        }

        private string[] GetBlocksOf0s(string binaryConversion)
        {
            return binaryConversion.Split(new char[] { '1' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private int GetBaumSweetEvaluation(string[] sequencesOf0)
        {
            var hasOdd0Sequence = false;
            var baumSweetEvaluation = 1;

            foreach (var seq in sequencesOf0)
            {
                if (seq.Length % 2 == 1)
                {
                    hasOdd0Sequence = true;
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
