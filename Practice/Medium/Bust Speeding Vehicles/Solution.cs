using System;
using System.Collections.Generic;

class Program
{
    static double CheckSpeed(Dictionary<string, Car> cars, string car, int km, int timestamp)
    {
        double kilometers = km - cars[car].Kilometers;
        double hours = (timestamp - cars[car].Timestamp) / 3600.0;
        double speed = kilometers / hours;
        return speed;
    }

    const int L_MAX = 100;
    const int L_MIN = 10;
    const int N_MAX = 100;
    const int C_MAX = 1000;

    class Car
    {
        public string Name { get; set; }
        public int Kilometers { get; set; }
        public int Timestamp { get; set; }
    }

    static void Main()
    {
        int l = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        bool ok = true;

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string car = input[0];
            int km = int.Parse(input[1]);
            int timestamp = int.Parse(input[2]);

            if (cars.ContainsKey(car))
            {
                double speed = CheckSpeed(cars, car, km, timestamp);
                if (speed > l)
                {
                    Console.WriteLine($"{car} {km}");
                    ok = false;
                }
            }

            cars[car] = new Car { Name = car, Kilometers = km, Timestamp = timestamp };
        }

        if (ok)
        {
            Console.WriteLine("OK");
        }
    }
}
