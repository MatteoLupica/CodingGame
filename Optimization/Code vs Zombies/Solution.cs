using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeVsZombie
{
    /**
    * Save humans, destroy zombies!
    **/
    public class Player
    {
        static void Main(string[] args)
        {
            string[] inputs;

            // game loop
            while (true)
            {
                var me = GetMyInfo();
                System.Console.Error.WriteLine("******** ME ********");
                System.Console.Error.WriteLine(me);

                var humans = GetHumans();
                System.Console.Error.WriteLine("******** HUMANS ********");
                humans.ForEach(System.Console.Error.WriteLine);

                var zombies = GetZombies();
                System.Console.Error.WriteLine("******** ZOMBIES ********");
                zombies.ForEach(System.Console.Error.WriteLine);

                var theNearestHumanInDanger = GetTheNearestHumanInDanger(me, zombies, humans);
                System.Console.Error.WriteLine("******** NEAREST HUMAN IN DANGER ********");
                System.Console.Error.WriteLine(theNearestHumanInDanger);

                var latitudeMove = theNearestHumanInDanger.Latitude;
                var longitudeMove = theNearestHumanInDanger.Longitude;

                Console.WriteLine($"{latitudeMove} {longitudeMove}");
            }
        }
        static Human GetMyInfo()
        {
            var inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);

            return new Human{ Id = 0, Latitude = y, Longitude = x};
        }
        static List<Human> GetHumans()
        {
            var humans = new List<Human>();
            int humanCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < humanCount; i++)
                {
                    var inputs = Console.ReadLine().Split(' ');
                    humans.Add(new Human{
                        Id=int.Parse(inputs[0]),
                        Latitude = int.Parse(inputs[1]),
                        Longitude = int.Parse(inputs[2])
                    });
                }
                return humans;
        }
        static List<Zombie> GetZombies()
        {
            var zombies = new List<Zombie>();
            int zombieCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < zombieCount; i++)
                {
                    var inputs = Console.ReadLine().Split(' ');
                    zombies.Add(new Zombie{
                        Id = int.Parse(inputs[0]),
                        Latitude = int.Parse(inputs[1]),
                        Longitude = int.Parse(inputs[2]),
                        NextLatitude = int.Parse(inputs[3]),
                        NextLongitude = int.Parse(inputs[4])
                    });
                }
                return zombies;
        }

        public static Zombie GetTheNearestZombie(Human me, List<Zombie> zombies)
        {
            var theNearestZombie = zombies.First();
            var nearestDistance = Math.Abs(me.DistanceFromZero - theNearestZombie.DistanceFromZero);

            zombies = zombies.Skip(1).ToList();

            foreach (var zombie in zombies)
            {
                var distance = Math.Abs(me.DistanceFromZero - zombie.DistanceFromZero);

                if(nearestDistance > distance)
                    theNearestZombie = zombie;
            }

            return theNearestZombie;
        }

        public static Human GetTheNearestHuman(Human me, List<Human> humans)
        {
            var theNearestHuman = humans.First();
            var nearestDistance = Math.Abs(me.DistanceFromZero - theNearestHuman.DistanceFromZero);

            humans = humans.Skip(1).ToList();

            foreach (var human in humans)
            {
                var distance = Math.Abs(me.DistanceFromZero - human.DistanceFromZero);

                if(nearestDistance > distance)
                    theNearestHuman = human;
            }

            return theNearestHuman;
        }

        public static Human GetTheNearestHumanInDanger(Human me, List<Zombie> zombies, List<Human> humans)
        {
            foreach (var human in humans)
            {
                var nearestZombie = GetTheNearestZombie(human, zombies);
                var distanceFromHuman = Math.Abs(human.DistanceFromZero - nearestZombie.DistanceFromZero);
                human.IsInDanger = distanceFromHuman < 4;
            }

            var humansInDanger = humans.Where(h => h.IsInDanger).ToList();

            if(!humansInDanger.Any())
                humansInDanger = humans;

            return GetTheNearestHuman(me, humansInDanger);
        }
    }
    public class Human
    {
        public int Id { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public int DistanceFromZero => Latitude + Longitude;

        public bool IsInDanger { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Latitude: {Latitude}, Longitude: {Longitude}";
        }
    }
    public class Zombie
    {
        public int Id { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }

        public int NextLatitude { get; set; }

        public int NextLongitude { get; set; }

        public int DistanceFromZero => NextLatitude + NextLongitude;

        public override string ToString()
        {
            return $"Id: {Id}, Latitude: {Latitude}, Longitude: {Longitude}, NextLatitude: {NextLatitude}, NextLongitude: {NextLongitude}";
        }
    }
}