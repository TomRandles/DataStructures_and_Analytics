using Arrays_and_Collections.Models;
using Arrays_and_Collections.Models.BusApp;
using System;

namespace Arrays_and_Collections.Repositories
{
    public class ArrayRepository
    {
        private BusRouteArrayBased[] _busRoutes;
        private string[,] _busTimes;

        public BusRouteArrayBased[] InitializeArrayFromConstructor()
        {
            _busRoutes = new[]
            {
                new BusRouteArrayBased(8, new [] {"Galway", "Limerick", "Cork" }),
                new BusRouteArrayBased(9, new [] {"Galway", "Dublin"}),
                new BusRouteArrayBased(9, new [] {"Galway", "Sligo", "Letterkenny"})
            };
            return _busRoutes;
        }

        public BusRouteArrayBased[] InitializeBusRoutesArrayWithSize()
        {
            _busRoutes = new BusRouteArrayBased[6];
            _busRoutes[0] = new BusRouteArrayBased(5, new[] { "Galway", "Ennis", "Limerick" });
            _busRoutes[1] = new BusRouteArrayBased(6, new[] { "Galway", "Limerick", "Cork" });
            _busRoutes[2] = new BusRouteArrayBased(7, new[] { "Galway", "Athlone", "Dublin" });
            _busRoutes[3] = new BusRouteArrayBased(8, new[] { "Galway", "Kildare", "Dublin" });
            _busRoutes[4] = new BusRouteArrayBased(9, new[] { "Galway", "Sligo", "Letterkenny" });
            _busRoutes[5] = new BusRouteArrayBased(10, new[] { "Galway", "An Spiddéal", "An Ceathra Rua" });

            return _busRoutes;
        }
        public BusTimes InitializeBusRouteWithTimeTable(int busRouteNumber)
        {
            _busRoutes = new BusRouteArrayBased[6];
            _busRoutes[0] = new BusRouteArrayBased(5, new[] { "Galway", "Ennis", "Limerick" });
            _busRoutes[1] = new BusRouteArrayBased(6, new[] { "Galway", "Limerick", "Cork" });
            _busRoutes[2] = new BusRouteArrayBased(7, new[] { "Galway", "Athlone", "Dublin" });
            _busRoutes[3] = new BusRouteArrayBased(8, new[] { "Galway", "Kildare", "Dublin" });
            _busRoutes[4] = new BusRouteArrayBased(9, new[] { "Galway", "Sligo", "Letterkenny" });
            _busRoutes[5] = new BusRouteArrayBased(10, new[] { "Galway", "An Spiddéal", "An Ceathra Rua" });

            // Multidimensional array – single array with more than one index
            string [,] _busTimes =
            {
                {"12.00","12.30","01:00" },
                {"14:00","14:30","15:00" },
                {"16:00","16:30","17:00" },
                {"18:00","18:30","19:00" },
                {"20:00","20:30","21:00" }
            };

            var busTime = new BusTimes(Array.Find<BusRouteArrayBased>(_busRoutes, route => route.Number == busRouteNumber), _busTimes);
            return busTime;
        }

        public BusTimesAlt InitializeBusRouteWitheJaggedArrayTimeTable(int busRouteNumber)
        {
            _busRoutes = new BusRouteArrayBased[6];
            _busRoutes[0] = new BusRouteArrayBased(5, new[] { "Galway", "Ennis", "Limerick" });
            _busRoutes[1] = new BusRouteArrayBased(6, new[] { "Galway", "Limerick", "Cork" });
            _busRoutes[2] = new BusRouteArrayBased(7, new[] { "Galway", "Athlone", "Dublin" });
            _busRoutes[3] = new BusRouteArrayBased(8, new[] { "Galway", "Kildare", "Dublin" });
            _busRoutes[4] = new BusRouteArrayBased(9, new[] { "Galway", "Sligo", "Letterkenny" });
            _busRoutes[5] = new BusRouteArrayBased(10, new[] { "Galway", "An Spiddéal", "An Ceathra Rua" });

            //Jagged array - Array whose elements are also arrays. 
            string[][] _busTimes =
            {
                new string[] {"12.00","12.30","01:00" },
                new string[] {"14:00","14:30","15:00" },
                new string[] {"16:00","16:30","17:00" },
                new string[] {"18:00","18:30","19:00" },
                new string[] {"20:00","20:30" }
            };

            var busTime = new BusTimesAlt(Array.Find<BusRouteArrayBased>(_busRoutes, route => route.Number == busRouteNumber), _busTimes);
            return busTime;
        }

        public BusRouteArrayBased[] FindBusesFrom(string busStop)
        {
            return Array.FindAll<BusRouteArrayBased>(_busRoutes,
                route => route.Origin.Equals(busStop, StringComparison.Ordinal));
        }

        public BusRouteArrayBased[] FindBusesTo(string busStop)
        {
            return Array.FindAll<BusRouteArrayBased>(_busRoutes,
                                                     route => Array.Exists<string>(route.PlacesServed, 
                                                        stop => (stop.Equals(busStop, StringComparison.Ordinal))));
        }
    }
}