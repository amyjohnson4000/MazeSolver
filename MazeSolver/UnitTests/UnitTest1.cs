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
            Point endLocation = Program.StartSolveMaze(maze, startPoint);
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
            Point endLocation = Program.StartSolveMaze(maze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 3;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }
    }

    public class RoomMazeTests
    {
        [Test]
        public void RoomTest1()
        {
            bool[,] roomMaze = new bool[,] {{ false, false, true, false, false },
                                            { false, true, true, true, false },
                                            { false, true, true, true, false },
                                            { false, false, false, true, false }};

            bool[] row1 = Program.GetFirstRow(roomMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(roomMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 3;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void RoomTest2()
        {
            bool[,] roomMaze = new bool[,] {{ false, false, false, true, false },
                                            { false, true, true, true, false },
                                            { false, true, true, true, false },
                                            { false, false, true, false, false }};

            bool[] row1 = Program.GetFirstRow(roomMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(roomMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 2;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void RoomTest3()
        {
            bool[,] roomMaze = new bool[,] {{ false, false, false, true, false },
                                            { false, true, true, true, false },
                                            { false, true, true, true, false },
                                            { false, true, false, false, false }};

            bool[] row1 = Program.GetFirstRow(roomMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(roomMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 1;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void RoomTest4()
        {
            bool[,] roomMaze = new bool[,] {{ false, false, true, false, false },
                                            { false, true, true, true, false },
                                            { false, true, true, true, false },
                                            { false, false, true, false, false }};

            bool[] row1 = Program.GetFirstRow(roomMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(roomMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 2;
            int expectedY = 3;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }
    }

    public class WindingMazeTests
    {
        [Test]
        public void WindingMazeTest1()
        {
            bool[,] windingMaze = new bool[,] {{ false, true, false, false, false },
                                            { false, true, true, true, false },
                                            { false, false, false, true, false },
                                            { false, true, true, true, false },
                                            { false, true, false, false, false },
                                            { false, true, true, true, false },
                                            { false, false, false, true, false } };

            bool[] row1 = Program.GetFirstRow(windingMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(windingMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 3;
            int expectedY = 6;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void WindingMazeTest2()
        {
            bool[,] windingMaze = new bool[,] {{ false, false, false, true, false },
                                            { false, true, true, true, false },
                                            { false, true, false, false, false },
                                            { false, true, true, true, false },
                                            { false, false, false, true, false },
                                            { false, true, true, true, false },
                                            { false, true, false, false, false } };

            bool[] row1 = Program.GetFirstRow(windingMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(windingMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 1;
            int expectedY = 6;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void WindingMazeTest3()
        {
            bool[,] windingMaze = new bool[,] {{ true, false, false, false, false },
                                               { true, true, true, false, false },
                                               { false, false, true, false, false },
                                               { false, true, true, false, false },
                                               { false, true, true, true, true },
                                               { false, false, true, true, true },
                                               { false, false, true, false, false } };

            bool[] row1 = Program.GetFirstRow(windingMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(windingMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 2;
            int expectedY = 6;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void WindingMazeTest4()
        {
            bool[,] windingMaze = new bool[,] {{ false, false, true, false, false },
                                            { false, false, true, true, false },
                                            { false, false, true, true, true },
                                            { false, false, true, true, true },
                                            { false, false, true, false, false },
                                            { true, true, true, false, false },
                                            { true, false, false, true, false } };

            bool[] row1 = Program.GetFirstRow(windingMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(windingMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 0;
            int expectedY = 6;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }
    }
    
    public class DeadEndTests
    {
        [Test]
        public void DeadEndTest1()
        {
            bool[,] deadEndMaze = new bool[,] {{ false, true, false, false, false },
                                               { false, true, true, true, false },
                                               { false, true, false, false, false },
                                               { false, true, true, true, false },
                                               { false, true, false, true, false },
                                               { false, false, false, true, false } };

            bool[] row1 = Program.GetFirstRow(deadEndMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(deadEndMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 3;
            int expectedY = 5;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        [Test]
        public void DeadEndTest2()
        {
            bool[,] deadEndMaze = new bool[,] {{ false, true, false, false, false },
                                               { false, true, true, true, false },
                                               { false, true, true, true, true },
                                               { false, true, false, false, true },
                                               { true, true, false, false, false },
                                               { true, false, false, false, false } };

            bool[] row1 = Program.GetFirstRow(deadEndMaze);
            Point startPoint = new Point(0, 0);
            int spaceLocation = Program.FindTheEmptySpace(row1);
            startPoint.X = spaceLocation;
            Point endLocation = Program.StartSolveMaze(deadEndMaze, startPoint);
            int actualX = endLocation.X;
            int actualY = endLocation.Y;

            int expectedX = 0;
            int expectedY = 5;

            Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
            Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
        }

        public class CompleteMazeTests
        {
            [Test]
            public void CompleteMazeTest1()
            {
                bool[,] completeMaze = new bool[,] {{ false, false, false, false, true, false, false, false, false, false },
                                                    { false, true, true, true, true, true, true, true, true, false },
                                                    { false, true, false, false, false, true, false, false, true, false },
                                                    { false, false, false, true, true, true, true, false, true, false },
                                                    { false, true, true, true, false, false, false, false, true, false },
                                                    { false, false, false, true, true, true, false, true, true, false },
                                                    { false, true, false, false, false, true, false, false, false, false },
                                                    { false, true, true, true, true, true, false, false, true, false },
                                                    { false, false, true, false, false, true, true, true, true, false },
                                                    { false, false, false, false, false, false, false, true, false, false } };

                bool[] row1 = Program.GetFirstRow(completeMaze);
                Point startPoint = new Point(0, 0);
                int spaceLocation = Program.FindTheEmptySpace(row1);
                startPoint.X = spaceLocation;
                Point endLocation = Program.StartSolveMaze(completeMaze, startPoint);
                int actualX = endLocation.X;
                int actualY = endLocation.Y;

                int expectedX = 7;
                int expectedY = 9;

                Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
                Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
            }

            [Test]
            public void CompleteMazeTestWithRoom()
            {
                //complete maze
                bool[,] completeMaze = new bool[,] {{ false, false, false, false, true,  false, false, false, false, false },
                                                    { false, true,  true,  true,  true,  true,  true,  true,  true,  false },
                                                    { false, true,  false, false, false, true,  false, false, true,  false },
                                                    { false, false, false, true,  true,  true,  true,  false, true,  false },
                                                    { false, true,  true,  true,  false, false, false, false, true,  false },
                                                    { false, false, false, true,  true,  true,  true,  true,  true,  false },
                                                    { false, true,  false, false, false, true,  true,  true,  false, false },
                                                    { false, true,  true,  true,  true,  true,  false, false, true,  false },
                                                    { false, false, true,  false, false, true,  true,  true,  true,  false },
                                                    { false, false, false, false, false, true, false, false,  false, false } };

                bool[] row1 = Program.GetFirstRow(completeMaze);
                Point startPoint = new Point(0, 0);
                int spaceLocation = Program.FindTheEmptySpace(row1);
                startPoint.X = spaceLocation;
                Point endLocation = Program.StartSolveMaze(completeMaze, startPoint);
                int actualX = endLocation.X;
                int actualY = endLocation.Y;

                int expectedX = 5;
                int expectedY = 9;

                Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
                Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
            }

            [Test]
            public void CompleteMazeTestWithRoom2()
            {
                bool[,] completeMaze = new bool[,] {{ false, false, false, false, true,  false, false, false, false, false },
                                                    { false, true,  true,  true,  true,  true,  true,  true,  true,  false },
                                                    { false, true,  false, false, false, true,  false, false, true,  false },
                                                    { false, false, false, true,  true,  true,  true,  false, true,  false },
                                                    { false, true,  true,  true,  false, false, false, false, true,  false },
                                                    { false, false, false, true,  true,  true,  true,  true,  true,  false },
                                                    { false, true,  false, false, false, true,  true,  true,  false, false },
                                                    { false, true,  true,  true,  true,  true,  false, true, true,  false },
                                                    { false, false, true,  false, false, true,  false, true,  true,  false },
                                                    { false, false, false, false, false, false, false, true,  false, false } };

                bool[] row1 = Program.GetFirstRow(completeMaze);
                Point startPoint = new Point(0, 0);
                int spaceLocation = Program.FindTheEmptySpace(row1);
                startPoint.X = spaceLocation;
                Point endLocation = Program.StartSolveMaze(completeMaze, startPoint);
                int actualX = endLocation.X;
                int actualY = endLocation.Y;

                int expectedX = 7;
                int expectedY = 9;

                Assert.AreEqual(expectedX, actualX, "End of maze not reached.");
                Assert.AreEqual(expectedY, actualY, "End of maze not reached.");
            }
        }
    }
}
