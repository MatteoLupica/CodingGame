using System;
using System.Collections.Generic;
//TODO The code must be optimized
class Solution
{
    static string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
                              "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-",
                              "..-", "...-", ".--", "-..-", "-.--", "--.." };

    static string sequence = "";
    static Dictionary<string, int> occur = new Dictionary<string, int>();
    static long[] combos;
    static int max = 0;

    static void Main(string[] args)
    {
        sequence = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        combos = new long[sequence.Length];

        for (int i = 0; i < N; i++)
        {
            Morph(Console.ReadLine());
        }

        Console.WriteLine(TryCombos(0));
    }

    static void Morph(string word)
    {
        string morphed = "";
        for (int i = 0; i < word.Length; i++)
        {
            morphed += morse[word[i] - 'A'];
            if (sequence.IndexOf(morphed) == -1) { return; }
        }
        int freq = 1;
        if (occur.ContainsKey(morphed))
        {
            freq += occur[morphed];
        }
        else
        {
            max = Math.Max(max, morphed.Length);
        }
        occur[morphed] = freq;
    }

    static long TryCombos(int start)
    {
        if (start == sequence.Length) return 1L;
        if (combos[start] != 0) return combos[start] - 1L;

        long result = 0;

        for (int i = 1; i <= max && start + i <= sequence.Length; i++)
        {
            if (occur.TryGetValue(sequence.Substring(start, i), out int frequency))
            {
                result += (long)frequency * TryCombos(start + i);
            }
        }

        combos[start] = result + 1L;
        return result;
    }
}
