using System;

class Player
{
    static void Main(string[] args)
    {
        int surfaceN = int.Parse(Console.ReadLine());
        Point[] land = new Point[surfaceN];
        int ground = -1;
        int high = 0;

        for (int i = 0; i < surfaceN; i++)
        {
            string[] landData = Console.ReadLine().Split(' ');
            int landX = int.Parse(landData[0]);
            int landY = int.Parse(landData[1]);
            land[i] = new Point(landX, landY);
            high = Math.Max(high, landY);

            if (i == 0) continue;
            if (land[i].Y == land[i - 1].Y) ground = i - 1;
        }

        int testCase = -1;
        bool offTheMark = false;

        // game loop
        while (true)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]);
            int vSpeed = int.Parse(inputs[3]);
            int fuel = int.Parse(inputs[4]);
            int rotate = int.Parse(inputs[5]);
            int power = int.Parse(inputs[6]);

            if (testCase == -1)
            {
                if (hSpeed == 0) testCase = 1;
                else testCase = 0;
            }

            // RULES FOR TEST 1
            if (testCase == 0)
            {
                if (Y - land[ground].Y < 800)
                {
                    if (vSpeed <= -39) Console.WriteLine("0 4");
                    else Console.WriteLine("0 3");
                    continue;
                }
                else if (X <= land[ground + 1].X) { Console.WriteLine("-45 4"); continue; }
                else if (vSpeed <= -20) { Console.WriteLine("0 4"); continue; }
                else if (vSpeed <= -12) { Console.WriteLine("0 2"); continue; }
                else { Console.WriteLine("45 4"); continue; }
            }

            // RULES FOR TEST 2
            if (testCase == 1)
            {
                Console.Error.WriteLine(offTheMark);
                if (vSpeed < -45 || Y <= 1135) { Console.WriteLine("0 4"); continue; }
                else if (X <= land[ground].X) { Console.WriteLine("-32 3"); continue; }
                else if (vSpeed == 0 && Y > high) { Console.WriteLine("0 3"); continue; }
                else if (vSpeed < 0 || Y < high) { Console.WriteLine("0 4"); continue; }
                else if (vSpeed >= 12 || offTheMark)
                {
                    offTheMark = true;
                    Console.WriteLine("45 4");
                    continue;
                }
                else { Console.WriteLine("0 4"); continue; }
            }
        }
    }
}

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
