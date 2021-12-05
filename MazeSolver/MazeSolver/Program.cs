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

        //bool[,] maze = new bool[,] {{ false, false, false, true, false },
        //    { false, false, false, true, false },
        //    { false, false, false, true, false },
        //    { false, false, false, true, false }};

        //room maze
        //bool[,] maze = new bool[,] {{ false, true, false, false, false },
        //                                { false, true, true, true, false },
        //                                { false, true, true, true, false },
        //                                { false, false, false, true, false }};


        //bool[,] roomMaze = new bool[,] {{ false, false, false, true, false },
        //                                    { false, true, true, true, false },
        //                                    { false, true, true, true, false },
        //                                    { false, false, true, false, false }};

        //bool[,] roomMaze = new bool[,] {    { false, true, false, false, false },
        //                                    { false, true, true, true, false },
        //                                    { false, true, true, true, false },
        //                                    { false, true, false, false, false }};

        //winding maze
        //bool[,] maze = new bool[,] {        { false, false, true, false, false },
        //                                    { false, false, true, true, false },
        //                                    { false, false, true, true, true },
        //                                    { false, false, true, true, true },
        //                                    { false, false, true, false, false },
        //                                    { true, true, true, false, false },
        //                                    { true, false, false, true, false } };

        //dead end maze
        bool[,] maze = new bool[,] {           { false, true, false, false, false },
                                               { false, true, true, true, false },
                                               { false, true, true, true, true },  //true
                                               { false, true, false, false, true },  //true
                                               { true, true, false, false, false },
                                               { true, false, false, false, false } };

        //bool[,] completeMaze = new bool[,] {        { false, false, false, false, true, false, false, false, false, false },
        //                                            { false, true, true, true, true, true, true, true, true, false },
        //                                            { false, true, false, false, false, true, false, false, true, false },
        //                                            { false, false, false, true, true, true, true, false, true, false },
        //                                            { false, true, true, true, false, false, false, false, true, false },
        //                                            { false, false, false, true, true, true, false, true, true, false },
        //                                            { false, true, false, false, false, true, false, false, false, false },
        //                                            { false, true, true, true, true, true, false, false, true, false },
        //                                            { false, false, true, false, false, true, true, true, true, false },
        //                                            { false, false, false, false, false, false, false, true, false, false } };

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
        row1 = GetFirstRow(maze);
        spaceLocation = FindTheEmptySpace(row1);

        if (spaceLocation == -1)
            Console.WriteLine("There is no empty space");
        else
            Console.WriteLine("location = " + spaceLocation);

        startPoint.X = spaceLocation;
        //endMazeLocation = MoveThroughRoom(completeMaze, startPoint);
        StartSolveMaze(maze, startPoint);
        Console.WriteLine("Maze has been solved.");
    }

    public static void StartSolveMaze(bool[,] matrix, Point startPoint)
    {
        //creates the list of points (the path), that we'll be exploring
        List<Point> path = new List<Point>();

        Console.WriteLine("Start Point, x = {0}, y = {1} ", startPoint.X, startPoint.Y);
        //Adds the start point to the path;
        path.Add(startPoint);

        SolveMaze(matrix, path);

        //Show the path that was found
        foreach (Point p in path)
            Console.WriteLine("Point, x = {0}, y = {1} " , p.X, p.Y);
    }

    public static bool SolveMaze(bool[,] matrix, List<Point> path)
    {
        Console.WriteLine("Solve Maze CALLED");
        int numRows = (matrix.GetUpperBound(0) + 1);
        int numCols = (matrix.GetUpperBound(1) + 1);
        Point lastPoint = path[path.Count - 1];

        //only for the start point
        Point previousPoint = lastPoint;

        if (path.Count > 1)
        {
            previousPoint = path[path.Count - 2];
        }

        if (lastPoint.Y == numRows - 1)
        {
            Console.WriteLine("The Last Point Has Been Found!, x = {0}, y = {1} ", lastPoint.X, lastPoint.Y);
            Console.WriteLine("Last Point SHOULD be in Index: x = {0}", numRows - 1);
            return true;
        }
        
        if ((lastPoint.X != (numCols - 1)) && matrix[lastPoint.Y, (lastPoint.X + 1)] == true && (previousPoint.X != (lastPoint.X + 1)))
        {
            path.Add(new Point(lastPoint.X + 1, lastPoint.Y));
            if (SolveMaze(matrix, path))
            {
                Console.WriteLine("Call of RIGHT X has returned true");
                return true;
            }
            path.RemoveAt(path.Count - 1);
            Console.WriteLine("Point, x = {0}, y = {1} ", lastPoint.X, lastPoint.Y);
        }

        else if (matrix[(lastPoint.Y + 1), lastPoint.X] == true && (previousPoint.Y != (lastPoint.Y + 1)))
        {
            path.Add(new Point(lastPoint.X, lastPoint.Y + 1));
            if (SolveMaze(matrix, path))
            {
                Console.WriteLine("Call of DOWN Y has returned true");
                return true;
            }
            path.RemoveAt(path.Count - 1);
            Console.WriteLine("Point, x = {0}, y = {1} ", lastPoint.X, lastPoint.Y);
        }

        else if ((lastPoint.X != 0) && (matrix[lastPoint.Y, (lastPoint.X - 1)] == true && (previousPoint.X != (lastPoint.X - 1))))
        {
            path.Add(new Point(lastPoint.X -1, lastPoint.Y));
            if (SolveMaze(matrix, path))
            {
                Console.WriteLine("Call of LEFT X has returned true");
                return true;
            }
            path.RemoveAt(path.Count - 1);
            Console.WriteLine("Point, x = {0}, y = {1} ", lastPoint.X, lastPoint.Y);
        }

        else if ((lastPoint.Y != 0) && (matrix[lastPoint.Y - 1, (lastPoint.X)] == true && (previousPoint.Y != (lastPoint.Y - 1))))
        {
            path.Add(new Point(lastPoint.X, lastPoint.Y - 1));
            if (SolveMaze(matrix, path))
            {
                Console.WriteLine("Call of UP Y has returned true");
                return true;
            }
            path.RemoveAt(path.Count - 1);
            Console.WriteLine("Point, x = {0}, y = {1} ", lastPoint.X, lastPoint.Y);
        }

        //Dead end
        else
        {
            Console.WriteLine("Dead End Reached");
            path.RemoveAt(path.Count - 1);
            return false;
            //if (SolveMaze(matrix, path))
            //{
            //    Console.WriteLine("Call of Dead End has returned true");
            //    return true;
            //}
        }

        return false;
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
            
            else if ((mazeLocation.X != 0) && (matrix[mazeLocation.Y, (mazeLocation.X - 1)] == true && (previousLocation.X != (mazeLocation.X - 1))))
            {
                mazeLocation.X--;
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
            }

            else if ((mazeLocation.Y != 0) && (matrix[mazeLocation.Y - 1, (mazeLocation.X)] == true && (previousLocation.Y != (mazeLocation.Y - 1))))
            {
                mazeLocation.Y--;
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
            }

            else
            {
                mazeLocation.X = previousLocation.X;
                mazeLocation.Y = previousLocation.Y;

                Console.WriteLine("Maze has reached dead end.");
                Console.WriteLine("\nx = " + mazeLocation.X);
                Console.WriteLine("y = " + mazeLocation.Y);
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
