// See https://aka.ms/new-console-template for more information

using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        Point startPoint = new Point(0, 0);
        Point mazeLocation = new Point(0, 0);
        Console.WriteLine("Maze Solver");

        bool[,] maze = new bool[,] {{ false, false, false, true, false },
            { false, false, false, true, false },
            { false, false, false, true, false },
            { false, false, false, true, false }};
        
        bool[] row1 = GetFirstRow(maze);
        int spaceLocation = FindTheEmptySpace(row1);
        
        if (spaceLocation == -1)
            Console.WriteLine("There is no empty space");
        else
            Console.WriteLine("location = " + spaceLocation);

        startPoint.X = spaceLocation;
        Console.WriteLine("start point, x = " + startPoint.X);
        Console.WriteLine("start point, y = " + startPoint.Y);

        mazeLocation = startPoint;
        Point endMazeLocation = MoveDown(maze, startPoint);
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
