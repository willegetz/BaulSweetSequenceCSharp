using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaulSweetSequenceTests
{
    [TestClass]
    public class SequenceTests
    {
        // Convert number to binary
        // Drop preceeding 0's
        //  Minimum number of digits is 1
        // Find all sequences of 0's
        // Does any sequence contain an odd number of 0's?
        //  If Yes: This is a value of 1
        //  If No: This is a value of 0
        // Absence of any 0's in a binary value is considered an absence of any 0 sequence of odd value
        // Iteration of numbers begins at number 0 and loops until reaching the final number

        [TestMethod]
        public void TestMethod1()
        {
            var startingValue = 1;

            var actual = Convert.ToString(startingValue, 2);

            var expected = "1";
            Assert.AreEqual(expected, actual);
        }
    }
}
