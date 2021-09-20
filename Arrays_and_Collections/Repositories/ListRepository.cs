using Arrays_and_Collections.Models;
using System.Collections.Generic;

namespace Arrays_and_Collections.Repositories
{
    public class ListRepository
    {
        private List<BusRouteListBased> _busRoutes;
        public List<BusRouteListBased> InitializeBusRoutesListWithSize()
        {
            _busRoutes = new List<BusRouteListBased>(5);
            _busRoutes.Add(new BusRouteListBased(5, new[] { "Galway", "Limerick" }));
            _busRoutes.Add(new BusRouteListBased(6, new[] { "Galway", "Limerick", "Cork" }));
            _busRoutes.Add(new BusRouteListBased(7, new[] { "Galway", "Athlone", "Dublin" }));
            _busRoutes.Add(new BusRouteListBased(8, new[] { "Galway", "Sligo", "Letterkenny" }));
            _busRoutes.Add(new BusRouteListBased(9, new[] { "Galway", "An Spiddéal", "An Ceathra Rua" }));

            return _busRoutes;
        }
        public List<BusRouteListBased> InitializeListFromConstructor()
        {
            _busRoutes = new List<BusRouteListBased>()
            {
                new BusRouteListBased(8, new [] {"Galway", "Limerick", "Cork" }),
                new BusRouteListBased(9, new [] {"Galway", "Dublin"}),
                new BusRouteListBased(9, new [] {"Galway", "Sligo", "Letterkenny"})
            };

            return _busRoutes;
        }
        public SortedList<int, BusRouteListBased> InitializeSortedListFromConstructor()
        {
            // Very similar to sorted keys.
            // Performance differences - SortedLists perform better in special circumstances.
            // Use sortedList if the items are pre-sorted and will not modify much after instantiation. 
            var sortedListBusRoutes = new SortedList<int, BusRouteListBased>()
            {
                { 8, new BusRouteListBased(8, new [] {"Galway", "Limerick", "Cork" }) },
                { 9,  new BusRouteListBased(9, new [] {"Galway", "Dublin"}) },
                { 10, new BusRouteListBased(10, new [] {"Galway", "Sligo", "Letterkenny"}) }
            };
            return sortedListBusRoutes;
        }
    }
}