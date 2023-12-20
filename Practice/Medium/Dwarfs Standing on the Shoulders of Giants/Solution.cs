using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, List<int>> connection = new Dictionary<int, List<int>>();

    static int LetsCount(int number)
    {
        int maxCount = 0;
        if (!connection.ContainsKey(number))
            return 0;

        List<int> getArray = connection[number];
        foreach (int item in getArray)
        {
            int temp = LetsCount(item);
            if (maxCount < temp)
                maxCount = temp;
        }
        return maxCount + 1;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // the number of relationships of influence
        for (int i = 0; i < n; i++)
        {
            // x: a relationship of influence between two people (x influences y)
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            if (!connection.ContainsKey(x))
                connection[x] = new List<int>();
            connection[x].Add(y);
        }

        int maxCount = 0;
        foreach (int item in connection.Keys)
        {
            int temp = LetsCount(item);
            if (maxCount < temp)
                maxCount = temp;
        }

        // The number of people involved in the longest succession of influences
        Console.WriteLine(maxCount + 1);
    }
}
