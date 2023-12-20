using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<char, int> values = new Dictionary<char, int>
    {
        {'e', 1}, {'a', 1}, {'i', 1}, {'o', 1}, {'n', 1}, {'r', 1}, {'t', 1}, {'l', 1}, {'s', 1}, {'u', 1},
        {'d', 2}, {'g', 2},
        {'b', 3}, {'c', 3}, {'m', 3}, {'p', 3},
        {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4}, {'y', 4},
        {'k', 5},
        {'j', 6}, {'x', 6},
        {'q', 7}, {'z', 7}
    };

    static void Main()
    {
        List<string> words = new List<string>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string w = Console.ReadLine();
            words.Add(w);
        }

        string letters = Console.ReadLine();
        int max = 0;
        string winword = "";

        foreach (string word in words)
        {
            int temp = 0;
            List<char> tempLetters = new List<char>(letters);

            foreach (char letter in word)
            {
                if (tempLetters.Contains(letter))
                {
                    temp += values[letter];
                    tempLetters.Remove(letter);
                }
                else
                {
                    temp = -1;
                    break;
                }
            }

            if (temp > max)
            {
                max = temp;
                winword = word;
            }
        }

        Console.WriteLine(winword);
    }
}
