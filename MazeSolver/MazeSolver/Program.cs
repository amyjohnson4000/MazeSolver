// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Maze Solver");
        bool[] row = new bool[] { false, false, false, false, false };

        int spaceLocation = FindTheEmptySpace(row);

        if (spaceLocation == -1)
            Console.WriteLine("There is no empty space");
        else
            Console.WriteLine("location = " + spaceLocation);
    }

    static int FindTheEmptySpace(bool[] row)
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