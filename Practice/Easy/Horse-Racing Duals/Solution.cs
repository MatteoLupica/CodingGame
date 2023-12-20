using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] pi = new int[n];

        for (int i = 0; i < n; i++)
        {
            pi[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(pi);

        int min = 10000000;
        for (int i = 0; i < n - 1; i++)
        {
            if (min > Math.Abs(pi[i] - pi[i + 1]))
            {
                min = Math.Abs(pi[i] - pi[i + 1]);

                if (min == 0)
                {
                    break;
                }
            }
        }

        Console.WriteLine(min);
    }
}
