using Arrays_and_Collections.Models;
using Arrays_and_Collections.Models.BusApp;
using System.Collections.Generic;

namespace Arrays_and_Collections.Repositories
{
    public class DictionaryRepository
    {
        private IDictionary<int, BusRouteListBased> _busRoutes;
        public IDictionary<int, BusRouteListBased> InitializeDictionaryFromConstructor()
        {
            _busRoutes = new Dictionary<int, BusRouteListBased>()
            {
                { 8, new BusRouteListBased(8, new [] {"Galway", "Limerick", "Cork" }) },
                { 9,  new BusRouteListBased(9, new [] {"Galway", "Dublin"}) },
                { 10, new BusRouteListBased(10, new [] {"Galway", "Sligo", "Letterkenny"}) }
            };
            return _busRoutes;
        }
        public SortedDictionary<int, BusRouteListBased> InitializeSortedDictionaryFromConstructor()
        {
            // Automatically sorts by key.
            // Plane dictionary, can use any type. 
            // Sorted dictionary, needs to know how to sort on the key type. Numbers and strings are fine.
            // Other types require extra work to specify how to sort.
            var sortedBusRoutes = new SortedDictionary<int, BusRouteListBased>()
            {
                { 8, new BusRouteListBased(8, new [] {"Galway", "Limerick", "Cork" }) },
                { 9,  new BusRouteListBased(9, new [] {"Galway", "Dublin"}) },
                { 10, new BusRouteListBased(10, new [] {"Galway", "Sligo", "Letterkenny"}) }
            };
            return sortedBusRoutes;
        }
        public IDictionary<int, BusRouteListBased> InitializeBusRoutesDictionaryWithSize()
        {
            _busRoutes = new Dictionary<int, BusRouteListBased>(5);

            _busRoutes.Add(5, new BusRouteListBased(5, new[] { "Galway", "Limerick" }));
            _busRoutes.Add(6, new BusRouteListBased(6, new[] { "Galway", "Limerick", "Cork" }));
            _busRoutes.Add(7, new BusRouteListBased(7, new[] { "Galway", "Athlone", "Dublin" }));
            _busRoutes.Add(8, new BusRouteListBased(8, new[] { "Galway", "Sligo", "Letterkenny" }));
            _busRoutes.Add(9, new BusRouteListBased(9, new[] { "Galway", "An Spiddéal", "An Ceathra Rua" }));

            return _busRoutes;
        }
    }
}