using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int oodsLeft = n;
        int costLeft = int.Parse(Console.ReadLine());

        int[] budgetLeft = new int[n];
        int[] budgetCalculated = new int[n];

        for (int i = 0; i < n; i++)
        {
            budgetLeft[i] = int.Parse(Console.ReadLine());
            budgetCalculated[i] = 0;
        }

        while (oodsLeft > 0)
        {
            int eachPay = (int)Math.Floor((double)costLeft / oodsLeft);

            for (int i = 0; i < n; i++)
            {
                if (budgetLeft[i] == 0)
                {
                    continue;
                }

                if (budgetLeft[i] <= eachPay)
                {
                    oodsLeft--;
                    budgetCalculated[i] += budgetLeft[i];
                    costLeft -= budgetLeft[i];
                    budgetLeft[i] = 0;
                }
                else
                {
                    budgetCalculated[i] += eachPay;
                    costLeft -= eachPay;
                    budgetLeft[i] -= eachPay;
                }

                if (costLeft == 0)
                {
                    break;
                }
            }

            if (costLeft < oodsLeft)
            {
                for (int i = n - 1; i > 0; i--)
                {
                    if (costLeft == 0)
                    {
                        break;
                    }

                    if (budgetLeft[i] > 0)
                    {
                        budgetCalculated[i] += 1;
                        costLeft -= 1;
                    }
                }
            }

            if (costLeft == 0)
            {
                break;
            }
        }

        if (oodsLeft == 0 && costLeft > 0)
        {
            Console.WriteLine("IMPOSSIBLE");
        }
        else
        {
            Array.Sort(budgetCalculated);

            foreach (int b in budgetCalculated)
            {
                Console.WriteLine(b);
            }
        }
    }
}
