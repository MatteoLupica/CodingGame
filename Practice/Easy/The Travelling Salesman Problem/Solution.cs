using System;

public class Solution
{
    static int seen = 0;
    static int N;
    static Point[] spots;
    static bool[] used;
    static double path = 0.0;

    public static void Main(string[] args)
    {
        N = int.Parse(Console.ReadLine());
        spots = new Point[N];
        used = new bool[N];

        for (int i = 0; i < N; i++)
        {
            string[] coordinates = Console.ReadLine().Split();
            int X = int.Parse(coordinates[0]);
            int Y = int.Parse(coordinates[1]);
            spots[i] = new Point(X, Y);
        }

        FindPath(0);
        Console.WriteLine((int)Math.Round(path));
    }

    public static void FindPath(int index)
    {
        used[index] = true;
        Point p = spots[index];
        double minDist = double.MaxValue;
        int ind = 0;

        for (int i = 0; i < N; i++)
        {
            if (!used[i] && i != index)
            {
                double dist = Math.Sqrt(Math.Pow(p.X - spots[i].X, 2) + Math.Pow(p.Y - spots[i].Y, 2));

                if (dist < minDist)
                {
                    minDist = dist;
                    ind = i;
                }
            }
        }

        if (ind == 0)
        {
            minDist = Math.Sqrt(Math.Pow(p.X - spots[0].X, 2) + Math.Pow(p.Y - spots[0].Y, 2));
        }

        Console.Error.WriteLine($"Nearest point to {index} is {ind}");

        seen++;
        path += minDist;

        Console.Error.WriteLine($"Path is {path}");

        used[ind] = true;

        if (seen != N)
        {
            FindPath(ind);
        }
    }
}

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
