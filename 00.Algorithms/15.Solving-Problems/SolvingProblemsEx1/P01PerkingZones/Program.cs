using System;
using System.Linq;

namespace _01.Parking_Zones
{
    internal class Program
    {
        private static void Main()
        {
            var parkingZonesCount = int.Parse(Console.ReadLine());
            var parkingZones = new ParkingZone[parkingZonesCount];

            for (var i = 0; i < parkingZonesCount; i++)
            {
                parkingZones[i] = new ParkingZone(Console.ReadLine());
            }

            var parkingSpots = Console.ReadLine()
                .Split(';')
                .Select(x => ParkingSpot.Parse(x, parkingZones))
                .ToArray();

            var targetPoint = ParkingSpot.Parse(Console.ReadLine(), parkingZones);

            var timeToTravelBlock = int.Parse(Console.ReadLine());

            foreach (var parkingSpot in parkingSpots)
            {
                parkingSpot.Distance = parkingSpot.GetDistance(targetPoint) * 2;
                parkingSpot.UpdateCost(timeToTravelBlock);
            }

            parkingSpots = parkingSpots
                .OrderBy(x => x.Cost)
                .ThenBy(x => x.Distance)
                .ToArray();

            Console.WriteLine(parkingSpots[0]);
        }

        internal class ParkingZone
        {
            public string Name { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public decimal Price { get; set; }

            public ParkingZone(string zoneString)
            {
                var tokens = zoneString.Split(':')
                    .ToArray();

                Name = tokens[0];

                tokens = tokens[1]
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                X = int.Parse(tokens[0]);
                Y = int.Parse(tokens[1]);
                Width = int.Parse(tokens[2]);
                Height = int.Parse(tokens[3]);
                Price = decimal.Parse(tokens[4]);
            }

            public bool IsInZone(int x, int y)
            {
                return x >= X
                    && x <= X + Width
                    && y >= Y
                    && y <= Y + Height;
            }
        }

        internal class ParkingSpot
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Distance { get; set; }
            public decimal Cost { get; set; }
            public ParkingZone ParkingZone { get; set; }

            public ParkingSpot(int x, int y, ParkingZone[] parkingZones)
            {
                X = x;
                Y = y;
                Distance = int.MaxValue;
                Cost = decimal.MaxValue;

                foreach (var parkingZone in parkingZones)
                {
                    if (!parkingZone.IsInZone(X, Y))
                    {
                        continue;
                    }

                    ParkingZone = parkingZone;
                    break;
                }
            }

            internal static ParkingSpot Parse(string spotString, ParkingZone[] parkingZones)
            {
                var tokens = spotString
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                return new ParkingSpot(tokens[0], tokens[1], parkingZones);
            }

            internal int GetDistance(ParkingSpot other)
            {
                return Math.Abs(X - other.X) + Math.Abs(Y - other.Y) - 1;
            }

            internal void UpdateCost(int timeToTravelBlock)
            {
                var timeInMinutes = Distance * timeToTravelBlock;
                timeInMinutes = timeInMinutes / 60 + (timeInMinutes % 60 > 0 ? 1 : 0);
                Cost = timeInMinutes * ParkingZone.Price;
            }

            public override string ToString()
            {
                return $"Zone Type: {ParkingZone.Name}; X: {X}; Y: {Y}; Price: {Cost:F2}";
            }
        }
    }
}