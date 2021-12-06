// See https://aka.ms/new-console-template for more information
using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Maze Solver is beginning.");

        //complete maze
        bool[,] maze = new bool[,] {{ false, false, false, false, true, false, false, false, false, false },
                                                    { false, true, true, true, true, true, true, true, true, false },
                                                    { false, true, false, false, false, true, false, false, true, false },
                                                    { false, false, false, true, true, true, true, false, true, false },
                                                    { false, true, true, true, false, false, false, false, true, false },
                                                    { false, false, false, true, true, true, false, true, true, false },
                                                    { false, true, false, false, false, true, false, false, false, false },
                                                    { false, true, true, true, true, true, false, false, true, false },
                                                    { false, false, true, false, false, true, true, true, true, false },
                                                    { false, false, false, false, false, false, false, true, false, false } };

        Point startPoint = FindTheStartingPoint(maze);
        if (startPoint.X == -1 & startPoint.Y == -1)
            Console.WriteLine("There is no starting point.");
        else
        {
            StartSolveMaze(maze, startPoint);
            Console.WriteLine("Maze has been solved.");
        }
    }

    public static Point StartSolveMaze(bool[,] maze, Point startPoint)
    {
        List<Point> path = new List<Point>();
        path.Add(startPoint);

        SolveMaze(maze, path);

        //Show the path that was found
        foreach (Point p in path)
            Console.WriteLine("Point, x = {0}, y = {1} " , p.X, p.Y);

        return (path[path.Count - 1]);
    }

    public static bool SolveMaze(bool[,] matrix, List<Point> path)
    {
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
            return true;
        }

        if (lastPoint.X != 0)
        {
            if ((matrix[lastPoint.Y, (lastPoint.X - 1)] == true) && (previousPoint.X != lastPoint.X - 1))
            {
                path.Add(new Point(lastPoint.X - 1, lastPoint.Y));
                if (SolveMaze(matrix, path))
                {
                    return true;
                }
                path.RemoveAt(path.Count - 1);
            }
        }

        if ((matrix[(lastPoint.Y + 1), lastPoint.X] == true) && (previousPoint.Y != lastPoint.Y + 1))
        {
            path.Add(new Point(lastPoint.X, lastPoint.Y + 1));
            if (SolveMaze(matrix, path))
            {
                return true;
            }
            path.RemoveAt(path.Count - 1);
        }
        
        if(lastPoint.X != (numCols - 1))
        {
            if ((matrix[lastPoint.Y, (lastPoint.X + 1)] == true) && (previousPoint.X != lastPoint.X + 1))
            {
                path.Add(new Point(lastPoint.X + 1, lastPoint.Y));
                if (SolveMaze(matrix, path))
                {
                    return true;
                }
                path.RemoveAt(path.Count - 1);
            }
        }
            
        if (lastPoint.Y != 0)
        {
            if (((matrix[lastPoint.Y - 1, (lastPoint.X)] == true) && (previousPoint.Y != (lastPoint.Y - 1))))
            {
                path.Add(new Point(lastPoint.X, lastPoint.Y - 1));
                if (SolveMaze(matrix, path))
                {
                    return true;
                }
                path.RemoveAt(path.Count - 1);
            }
        }
            
        return false;
    }

    public static Point FindTheStartingPoint(bool[,] maze)
    {
        Point startPoint = new Point(0, 0);
        bool[] row1 = GetFirstRow(maze);
        int startingSpace = FindTheEmptySpace(row1);
        if (startingSpace == -1)
        {
            startPoint.X = -1;
            startPoint.Y = -1;
        }
        else
            startPoint.X = startingSpace;
        return startPoint;
    }

    public static bool[] GetFirstRow(bool[,] matrix)
    {
        return GetRow(matrix, 0);
    }

    public static bool[] GetRow(bool[,] matrix, int rowNumber)
    {
        int numCols = (matrix.GetUpperBound(1) + 1);
        bool[] row1 = new bool[numCols];

        for (int i = 0; i < numCols; i++)
        {
            row1[i] = matrix[0, i];
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
