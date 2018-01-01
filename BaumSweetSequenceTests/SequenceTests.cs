using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BaumSweetSequenceTests
{
    [TestClass]
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
            var binaryConversion = Convert.ToString(startingValue, 2);

            var sequencesOf0 = binaryConversion.Split(new char[] { '1' }, StringSplitOptions.RemoveEmptyEntries);
            var hasOdd0Sequence = false;

            foreach (var seq in sequencesOf0)
            {
                if (seq.Length % 2 == 1)
                {
                    hasOdd0Sequence = true;
                }
            }

            Assert.IsTrue(hasOdd0Sequence, "The binary value does not contain any sequence of 0 with an odd count");
        }

        [TestMethod]
        public void Number1DoesNotHaveOdd0Sequence()
        {
            var startingValue = 1;
            var binaryConversion = Convert.ToString(startingValue, 2);

            var sequencesOf0 = binaryConversion.Split(new char[] { '1' }, StringSplitOptions.RemoveEmptyEntries);
            var hasOdd0Sequence = false;

            foreach (var seq in sequencesOf0)
            {
                if (seq.Length % 2 == 1)
                {
                    hasOdd0Sequence = true;
                }
            }

            Assert.IsFalse(hasOdd0Sequence, "The binary value does contain a sequence of 0 with an odd count");
        }
    }
}
