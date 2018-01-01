using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ApprovalTests.Reporters;
using ApprovalTests;
using BaumSweetSequence;

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
            var evaluator = new SequenceEvaluation();
            var startingValue = 2;

            var binaryConversion = evaluator.GetBinaryValue(startingValue);
            var sequencesOf0 = evaluator.GetBlocksOf0s(binaryConversion);
            var baumSweetEvaluation = evaluator.GetBaumSweetEvaluation(sequencesOf0);

            var expected = 0;

            Assert.AreEqual(expected, baumSweetEvaluation, "Evaluation contains no block of consecutive 0s of odd length");
        }

        [TestMethod]
        public void Number1DoesNotHaveOdd0Sequence()
        {
            var evaluator = new SequenceEvaluation();
            var startingValue = 1;

            var binaryConversion = evaluator.GetBinaryValue(startingValue);
            var sequencesOf0 = evaluator.GetBlocksOf0s(binaryConversion);
            int baumSweetEvaluation = evaluator.GetBaumSweetEvaluation(sequencesOf0);

            var expected = 1;

            Assert.AreEqual(expected, baumSweetEvaluation, "Evaluation contains 1 or more blocks of consecutive 0s of odd length");
        }

        [TestMethod]
        public void BaumSweetSequenceFor2Is1and1and0()
        {
            var creator = new SequenceCreation();
            var numberToEvaluate = 2;
            var baumSweetSequence = creator.GetBaumSweetSequenceListFor(numberToEvaluate);

            Approvals.VerifyAll(baumSweetSequence, "b_");
        }
    }
}
