using NUnit.Framework;
using System.Drawing;

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

    public class FindFirstRowTests
    {
        [Test]
        public void FindFirstRow()
        {
            bool[,] maze = new bool[,] {{ false, true, false, false, false },
            { false, false, false, true, true },
            { false, false, false, true, true },
            { false, false, false, true, true }};

            bool[] expected = { false, true, false, false, false };
            bool[] actual = Program.GetFirstRow(maze);

            Assert.AreEqual(expected, actual, "First row not found properly.");
        }

        [Test]
        public void FindFirstRowMultipleTrues()
        {
            bool[,] maze = new bool[,] {{ true, true, true, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false }};

            bool[] expected = { true, true, true, false, false };
            bool[] actual = Program.GetFirstRow(maze);

            Assert.AreEqual(expected, actual, "First row not found properly.");
        }
    }

    public class HallwayMazeTests
    {
        [Test]
        public void HallwayTest1()
        {
            bool[,] maze = new bool[,] {{ false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false },
                { false, false, true, false, false }};

            bool[] row1 = Program.GetFirstRow(maze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.MoveDown(maze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 2;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void HallwayTest2()
        {
            bool[,] maze = new bool[,] {{ false, false, false, true, false },
                { false, false, false, true, false },
                { false, false, false, true, false },
                { false, false, false, true, false }};

            bool[] row1 = Program.GetFirstRow(maze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.MoveDown(maze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 3;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void HallwayDeadEndTest1()
        {
            bool[,] maze = new bool[,] {{ false, true, false, false, false },
                { false, true, false, false, false },
                { false, true, false, false, false },
                { false, false, false, false, false }};

            bool[] row1 = Program.GetFirstRow(maze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.MoveDown(maze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 1;
            int expectedY = 2;

            Assert.AreEqual(expectedX, actualX, "Dead end not properly found.");
            Assert.AreEqual(expectedY, actualY, "Dead end not properly found.");
        }

        [Test]
        public void HallwayDeadEndTest2()
        {
            bool[,] maze = new bool[,] {{ false, true, false, false, false },
                { false, true, false, false, false },
                { false, true, false, false, false },
                { false, false, false, false, false }};

            bool[] row1 = Program.GetFirstRow(maze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.MoveDown(maze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 1;
            int expectedY = 2;

            Assert.AreEqual(expectedX, actualX, "Dead end not properly found.");
            Assert.AreEqual(expectedY, actualY, "Dead end not properly found.");
        }
    }
}

    