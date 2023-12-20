using System;

class Solution
{
    static bool[] eqt;
    static bool[] used;

    public static void Main(string[] args)
    {
        int r1 = int.Parse(Console.ReadLine());
        eqt = new bool[r1];
        used = new bool[r1];
        int count = 0;

        for (int cnt = 1; cnt < r1; cnt++)
        {
            if (WillReach(cnt, r1))
                count++;

            if (count >= 2)
            {
                Console.WriteLine("YES");
                return;
            }
        }

        Console.WriteLine("NO");
    }

    public static bool WillReach(int cnt, int TARGET)
    {
        if (used[cnt])
            return eqt[cnt];

        used[cnt] = true;
        int nxt = GetNew(cnt);

        if (nxt == TARGET)
            return eqt[cnt] = true;
        else if (nxt > TARGET)
            return eqt[cnt] = false;

        return eqt[cnt] = WillReach(nxt, TARGET);
    }

    public static int GetNew(int cnt)
    {
        int copy = cnt;

        while (copy > 0)
        {
            cnt += copy % 10;
            copy /= 10;
        }

        return cnt;
    }
}
