using NUnit.Framework;

namespace UnitTests
{
    public class FindTheEmptySpaceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindEmptySpaceCorrectly()
        {
            int expected = 4;
            bool[] row = new bool[] { false, false, false, false, true };
            int actual = Program.FindTheEmptySpace(row);
            
            Assert.AreEqual(expected, actual, "space not found correctly");
        }
        
        [Test]
        public void FindEmptySpaceReturnsNoSpace()
        {
            int expected = -1;
            bool[] row = new bool[] { false, false, false, false, false };
            int actual = Program.FindTheEmptySpace(row);

            Assert.AreEqual(expected, actual, "No spaces not correctly identified");
        }

        [Test]
        public void FindEmptySpaceFirstOfMultiple()
        {
            int expected = 1;
            bool[] row = new bool[] { false, true, false, true, false };
            int actual = Program.FindTheEmptySpace(row);

            Assert.AreEqual(expected, actual, "Empty space not correctly found.");
        }

        [Test]
        public void FindEmptySpaceFirstOfMultipleAll()
        {
            int expected = 0;
            bool[] row = new bool[] { true, true, true, true, true };
            int actual = Program.FindTheEmptySpace(row);

            Assert.AreEqual(expected, actual, "Empty space not correctly found.");
        }
    }
}