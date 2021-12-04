// See https://aka.ms/new-console-template for more information

using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        Point startPoint = new Point(0, 0);
        Point mazeLocation = new Point(0, 0);
        Point previousLocation = new Point(0, 0);
        Console.WriteLine("Maze Solver");

        bool[,] hallwayMaze = new bool[,] {{ false, false, false, true, false },
            { false, false, false, true, false },
            { false, false, false, true, false },
            { false, false, false, true, false }};

        /*
        bool[,] roomMaze = new bool[,] {{ false, true, false, false, false },
                                        { false, true, true, true, false },
                                        { false, true, true, true, false },
                                        { false, false, false, true, false }};
        */

        //bool[,] roomMaze = new bool[,] {{ false, false, false, true, false },
        //                                    { false, true, true, true, false },
        //                                    { false, true, true, true, false },
        //                                    { false, false, true, false, false }};
        /*
        bool[,] roomMaze = new bool[,] {    { false, true, false, false, false },
                                            { false, true, true, true, false },
                                            { false, true, true, true, false },
                                            { false, true, false, false, false }};
        */

        bool[,] windingMaze = new bool[,] {{ false, false, true, false, false },
                                            { false, false, true, true, false },
                                            { false, false, true, true, true },
                                            { false, false, true, true, true },
                                            { false, false, true, false, false },
                                            { true, true, true, false, false },
                                            { true, false, false, true, false } };

        bool[] row1;
        int spaceLocation;
        Point endMazeLocation;

        //Hallway Maze
        /*
        row1 = GetFirstRow(hallwayMaze);
        spaceLocation = FindTheEmptySpace(row1);
        
        if (spaceLocation == -1)
            Console.WriteLine("There is no empty space");
        else
            Console.WriteLine("location = " + spaceLocation);

        startPoint.X = spaceLocation;
        Console.WriteLine("start point, x = " + startPoint.X);
        Console.WriteLine("start point, y = " + startPoint.Y);

        mazeLocation = startPoint;
        endMazeLocation = MoveDown(hallwayMaze, startPoint);
        */

        //Room Maze
        row1 = GetFirstRow(windingMaze);
        spaceLocation = FindTheEmptySpace(row1);

        if (spaceLocation == -1)
            Console.WriteLine("There is no empty space");
        else
            Console.WriteLine("location = " + spaceLocation);

        startPoint.X = spaceLocation;
        Console.WriteLine("start point, x = " + startPoint.X);
        Console.WriteLine("start point, y = " + startPoint.Y);

        mazeLocation = startPoint;
        endMazeLocation = MoveThroughRoom(windingMaze, startPoint);
    }

    public static Point MoveThroughRoom(bool[,] matrix, Point mazeLocation)
    {
        int numRows = (matrix.GetUpperBound(0) + 1);
        int numCols = (matrix.GetUpperBound(1) + 1);
        Console.WriteLine("starting x = " + mazeLocation.X);
        Console.WriteLine("starting y = " + mazeLocation.Y);

        Point storedLocation = new Point();
        Point previousLocation = new Point(mazeLocation.X, mazeLocation.Y);

        while (mazeLocation.Y < (numRows - 1))
        {
            storedLocation.X = mazeLocation.X;
            storedLocation.Y = mazeLocation.Y;

            if ((mazeLocation.X != (numCols - 1)) && matrix[mazeLocation.Y, (mazeLocation.X + 1)] == true && (previousLocation.X != (mazeLocation.X + 1)))
            {
                mazeLocation.X++;
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
            }

            else if (matrix[(mazeLocation.Y + 1), mazeLocation.X] == true && (previousLocation.Y != (mazeLocation.Y + 1)))
            {
                mazeLocation.Y++;
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
            }

            else if ((mazeLocation.X != 0)  && (matrix[mazeLocation.Y, (mazeLocation.X - 1)] == true && (previousLocation.X != (mazeLocation.X - 1))))
            {
                mazeLocation.X--;
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
            }

            else
            {
                Console.WriteLine("Maze has reached dead end.");
                return mazeLocation;
            }
            
            previousLocation = storedLocation;
        }
        
        Console.WriteLine("Maze has completed.");
        return mazeLocation;
    }

    public static Point MoveDown(bool[,] matrix, Point mazeLocation)
    {
        int numRows = (matrix.GetUpperBound(0) + 1);
        int numCols = (matrix.GetUpperBound(1) + 1);

        for (int i = 0; i < numRows; i++)
        {
            Console.WriteLine(matrix[i, mazeLocation.X]);
            
            if (matrix[i, mazeLocation.X] == true)
            {
                Console.WriteLine("x = " + mazeLocation.X);
                Console.WriteLine("y = " + i);
                mazeLocation.Y = i;
            }
            else
            {
                Console.WriteLine("Maze has reached dead end.");
                Console.WriteLine("end point, x = " + mazeLocation.X);
                Console.WriteLine("end point, y = " + mazeLocation.Y);
                return mazeLocation;
            }
        }

        Console.WriteLine("Maze has been completed");
        Console.WriteLine("end point, x = " + mazeLocation.X);
        Console.WriteLine("end point, y = " + mazeLocation.Y);
        return mazeLocation;
    }
    
    public static bool[] GetFirstRow(bool[,] matrix)
    {
        return GetRow(matrix, 0);
    }

    public static bool[] GetRow(bool[,] matrix, int rowNumber)
    {
        int numCols = (matrix.GetUpperBound(1) + 1);
        Console.WriteLine("Number of Columns:" + numCols);
        bool[] row1 = new bool[numCols];

        for (int i = 0; i < numCols; i++)
        {
            row1[i] =  matrix[0, i];
            Console.WriteLine(row1[i]);
        }

        return row1;
    }
    
    public static int FindTheEmptySpace(bool[] row)
    {
        int spaceLocation = -1;

        for (int i = 0; i < row.Length; i++)
        {
            if (row[i] == true)
            {
                spaceLocation = i;
                return (spaceLocation);
            }
        }

        return spaceLocation;
    }
}
