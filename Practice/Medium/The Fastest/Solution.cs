using System;

class Program
{
    static void Main()
    {
        string timew = "23:59:59";
        int minimum = 23 * 60 * 60 + 59 * 60 + 59;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string t = Console.ReadLine();
            Console.Error.WriteLine(t);

            string[] temp = t.Split(':');
            int time = int.Parse(temp[0]) * 60 * 60 + int.Parse(temp[1]) * 60 + int.Parse(temp[2]);

            if (time < minimum)
            {
                minimum = time;
                timew = t;
            }
        }
        Console.WriteLine(timew);
    }
}
