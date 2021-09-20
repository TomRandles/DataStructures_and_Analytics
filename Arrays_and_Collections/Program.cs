using Arrays_and_Collections.Models;
using Arrays_and_Collections.Repositories;
using Arrays_and_Collections.Utils;
using System;
using System.Collections.Generic;

namespace Arrays_and_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Press any key to demonstrate Array collections ...");
            Console.ReadKey();
            ArrayExercises();

            Console.WriteLine();
            Console.WriteLine("Press any key to demonstrate List collections ...");
            Console.ReadKey();
            Console.Clear();
            ListExercises();

            Console.WriteLine();
            Console.WriteLine("Press any key to demonstrate Dictionary collections ...");
            Console.ReadKey();
            Console.Clear();
            DictionaryExercises();
            
            Console.WriteLine();
            Console.WriteLine("Press any key to demonstrate FindBusTo using Array collections ...");
            Console.ReadKey();
            Console.Clear();
            FindBusToUsingArrayExercise();

            FindBusToUsingHashSetExercise();

            IncludeTimeTableUsingMultiDimensionalArrays();

            IncludeTimeTableUsingJaggedArrays();

            BusStopExample();

            BusStopExampleWithLinkedList();
        }

        private static void BusStopExampleWithLinkedList()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Galway busstop. We'll be stopping at Ennis and Limerick.");
            BusStop busstop = new BusStop();
            BusAlt bus = new BusAlt();

            for (int i = 0; i < 6; i++)
                busstop.PersonArrive(PassengerGenerator.CreatePassengerWithDifferentDestinations());
            Console.WriteLine($"There are {busstop.PeopleWaitingCount} passengers waiting at the busstop");
            Console.ReadKey();

            Console.WriteLine("The bus for Limerick has arrived!");
            busstop.BusArrive(bus);

            bus.ArriveAt("Ennis");
            bus.ArriveAt("Limerick");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
        private static void BusStopExample()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Galway busstop");
            BusStop busstop = new BusStop();
            Bus bus = new Bus();

            for (int i = 0; i < 6; i++)
                busstop.PersonArrive(PassengerGenerator.CreatePassenger());
            Console.WriteLine($"There are {busstop.PeopleWaitingCount} passengers waiting at the busstop");
            Console.ReadKey();

            Console.WriteLine("The bus for Limerick has arrived!");
            busstop.BusArrive(bus);
            Console.WriteLine();
            Console.WriteLine($"The bus stop has {busstop.PeopleWaitingCount} passengers waiting for the next Limerick bus.");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.WriteLine("Bus arrives at final terminal");

            while (bus.PassengerCount > 0 )
            {
                var passenger = bus.UnloadAPassenger();
                Console.WriteLine($"Passenger {passenger.Name} has disembarqued");
            }
        }

        private static void IncludeTimeTableUsingJaggedArrays()
        {
            var arrayRepository = new ArrayRepository();
            var busTime = arrayRepository.InitializeBusRouteWitheJaggedArrayTimeTable(5);

            // output details
            Console.Clear();
            Console.WriteLine($"Output timetable with Jagged Array for route number: {busTime.Route.Number}");
            Console.WriteLine(busTime.ToString());
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private static void IncludeTimeTableUsingMultiDimensionalArrays()
        {
            var arrayRepository = new ArrayRepository();
            var busTime = arrayRepository.InitializeBusRouteWithTimeTable(5);

            // output details
            Console.Clear();
            Console.WriteLine($"Output timetable for route number: {busTime.Route.Number}");
            Console.WriteLine(busTime.ToString());
            Console.ReadKey();
        }

        public static void FindBusToUsingHashSetExercise()
        {
            var arrayRepository = new ArrayRepository();

            var busRoutes = arrayRepository.InitializeBusRoutesArrayWithSize();
            foreach (var route in busRoutes)
                Console.WriteLine($"{route}");

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Using hash sets");
            Console.WriteLine();
            Console.WriteLine("Enter starting point");
            var origin = Console.ReadLine();
            Console.WriteLine("Enter destination");
            var destination = Console.ReadLine();

            BusRouteArrayBased[] originRoutes = arrayRepository.FindBusesFrom(origin);
            BusRouteArrayBased[] destinationRoutes = arrayRepository.FindBusesTo(destination);

            HashSet<BusRouteArrayBased> routes = new HashSet<BusRouteArrayBased>(originRoutes);
            // Calculate intersection between two arrays. 
            // It does not create a new collection. It stores the results back in routes.
            routes.IntersectWith(destinationRoutes);

            if (routes.Count > 0)
                // HasSet can be enumerated as normal with foreach
                foreach (var item in routes)
                    Console.WriteLine($"You can use route {item}");
            else
                Console.WriteLine("No intersecting route found");
            Console.ReadKey();
            // Note: HashSet required more setting up because data was contained in an array.
            // Very simple once HasSet is setup to get intersects.
        }
        private static void FindBusToUsingArrayExercise()
        {

            var arrayRepository = new ArrayRepository();

            var busRoutes = arrayRepository.InitializeBusRoutesArrayWithSize();
            foreach (var route in busRoutes)
                Console.WriteLine($"{route}");

            Console.WriteLine();
            Console.WriteLine("Enter starting point:");
            var origin = Console.ReadLine();
            Console.WriteLine("Enter destination");
            var destination = Console.ReadLine();

            // Get all buse routes going to this destination.
            var suitableRoutesFound = Array.FindAll(busRoutes, route => route.Serves(origin) && route.Serves(destination));
            if (suitableRoutesFound.Length == 0)
                Console.WriteLine($"No routes found for {origin} and {destination}");
            else
            {
                foreach (var item in suitableRoutesFound)
                    Console.WriteLine($"Route found: {item}");
            }
        }

        public static void DictionaryExercises()
        {
            Console.WriteLine("Hello Galway, lets get your bus routes for today!C");

            var routeOne = InitializeBusRouteListObject(5, new[] { "Galway", "Ballinasloe" });
            var routeTwo = InitializeBusRouteListObject(6, new[] { "Galway", "Bearna", "An Spiddéal}" });
            var routeThree = InitializeBusRouteListObject(7, new[] { "Galway", "Ballinasloe", "Athlone" });

            Console.WriteLine(routeOne);
            Console.WriteLine(routeTwo);
            Console.WriteLine(routeThree);

            var dictionaryRepository = new DictionaryRepository();
            var busRoutes = dictionaryRepository.InitializeBusRoutesDictionaryWithSize();

            // Iterate or enumerate over the array. foreach - no frills enumerating
            // myRoute - iteration variable. Assigned each value of the array in turn
            foreach (var myRoute in busRoutes)
            {
                Console.WriteLine($"Route number: {myRoute.Key}, routes: {myRoute.Value}");
            }

            var busRoutesAlt = dictionaryRepository.InitializeDictionaryFromConstructor();

            // Foreach loop enumeration.
            // Can iterate all keys in dictionary and use to lookup value.
            Console.WriteLine("For loop iteration:");
            foreach (var i in busRoutesAlt.Keys )
            {
                Console.WriteLine($"Bus route {i}: {busRoutesAlt[i]}");
            }
            Console.WriteLine();
            Console.WriteLine();
            // Ex find an item with the item key. 
            // Confirm that busRoute 7 is contained in the bus routes data structure 

            BusRouteListBased returnedBusRoute = null;
            // Needs exception management - so should not use this approach. 
            try
            {
                returnedBusRoute = busRoutes[7];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown. Route 7 not found."  );
            }

            if (returnedBusRoute != null)
                Console.WriteLine($"Found route 7: {returnedBusRoute.ToString()}");
            else
                Console.WriteLine("Bus route 7 not found");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Use dictionary's ContainsKey. Simpler and safer - returns bool");
            if (busRoutes.ContainsKey(7))
                // Can use [] key indexing safely here - definitely present. 
                Console.WriteLine($"Route 7 found: {busRoutes[7]}");
            else
                Console.WriteLine("Route 7 not found");

            Console.WriteLine("Use dictionary's TryGetValue. Simpler and safer and slightly faster." + 
                "No exceptions thrown - returns bool and value if found");
            if (busRoutes.TryGetValue(7, out var foundRoute))
                Console.WriteLine($"Route 7 found: {foundRoute}.");
            else
                Console.WriteLine("Route 7 not found.");

            Console.WriteLine();
            Console.WriteLine("Find all Galway originated routes");
            var galwayBuses = new List<BusRouteListBased>();
            foreach(var bRoute in busRoutes)
            {
                if (bRoute.Value.Origin.Equals("Galway", StringComparison.Ordinal))
                    galwayBuses.Add(bRoute.Value);
            }

            Console.WriteLine();
            Console.WriteLine("All routes originating in Galway:");
            if (galwayBuses.Count > 0)
                foreach (var route in galwayBuses)
                    Console.WriteLine(route.ToString());
            else
                Console.WriteLine("No buses originating from Galway.");

            Console.WriteLine();
            var preferredDestination = "Bearna";
            Console.WriteLine($"Check for correct route for {preferredDestination}");
            // Check for specific bus stop on route
            bool routeFound = false;
            foreach (var route in busRoutes)
            {
                if (route.Value.ServesUsingListContains(preferredDestination))
                {
                    Console.WriteLine($"Route {route.Key} serves {preferredDestination}");
                    routeFound = true;
                    break;
                }
            }
            Console.WriteLine("{0}", routeFound ? "Route found" : "Route not found");

            Console.WriteLine();
            Console.WriteLine("Remove bus route 5 ");
            busRoutes.Remove(5);

            Console.WriteLine();

            Console.WriteLine("Current routes:");
            foreach (var item in busRoutes)
                Console.WriteLine(item);
            Console.WriteLine();

            var newBusRoutes = dictionaryRepository.InitializeSortedDictionaryFromConstructor();
        }

        public static void ListExercises()
        {
            Console.WriteLine("Hello Galway, lets get your bus routes for today!");
            var listRepository = new ListRepository();

            var routeOne = InitializeBusRouteListObject(5, new[] { "Galway", "Ballinasloe" });
            var routeTwo = InitializeBusRouteListObject(6, new[] { "Galway", "Bearna", "An Spiddéal}" });
            var routeThree = InitializeBusRouteListObject(7, new[] { "Galway", "Ballinasloe", "Athlone" });

            Console.WriteLine(routeOne);
            Console.WriteLine(routeTwo);
            Console.WriteLine(routeThree);

            var busRoutes = listRepository.InitializeBusRoutesListWithSize();

            // Iterate or enumerate over the array. foreach - no frills enumerating
            // myRoute - iteration variable. Assigned each value of the array in turn
            foreach (var myRoute in busRoutes)
            {
                Console.WriteLine(myRoute);
            }

            var busRoutesAlt = listRepository.InitializeListFromConstructor();

            // Look up by index - 0 - position of item in array
            if (busRoutes[0].Number == 5)
                Console.WriteLine("First Bus route contains bus rounte number 5");

            // Get last item in array fully populated - C#8 special operator. ^n == Length - n
            // Same as busRoutesAlt.Length - 1
            var lastBusRoute = busRoutesAlt[^1];

            if (lastBusRoute != null)
                Console.WriteLine($"Last bus route is: {lastBusRoute.ToString()}");
            else
                Console.WriteLine("Error, no last bus route found.");

            // For loop enumeration. More complex, but more powerful, i.e. can include index in operations.
            // Can iterate for n entries in array
            Console.WriteLine("For loop iteration:");
            for (var i = 0; i < busRoutesAlt.Count; i++)
            {
                Console.WriteLine($"Bus route: {busRoutesAlt[i].ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine();
            // Ex find an item without knowing the index, i.e. an item with a specific value
            // Confirm that busRoute 7 is contained in the 
            // Works - brute force!
            foreach (var route in busRoutes)
            {
                if (route.Number == 7)
                {
                    Console.WriteLine("Found route 7");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            // Use Array.Find - static method. 
            // Lamda expression used for predicate - inline method.
            // Array.Find tests each entry in the array using the predicate until a match is 
            // found. 
            Console.WriteLine("Use Array.Find(T[], predicate<T> match)");
            var busRoute = busRoutes.Find(route => route.Number == 7);
            if (busRoute != null)
                Console.WriteLine("Route 7 found!");
            else
                Console.WriteLine("Route 7 not found");

            // Use List<T>.FindAll() to get all of the busses originating in Galway. Returns an empty array
            // if no routes found.
            var galwayBuses = busRoutes.FindAll(route => route.Origin.Equals("Galway", StringComparison.Ordinal));

            Console.WriteLine();
            Console.WriteLine("All routes originating in Galway:");
            if (galwayBuses.Count > 0)
                foreach (var route in galwayBuses)
                    Console.WriteLine(route.ToString());
            else
                Console.WriteLine("No buses originating from Galway.");

            Console.WriteLine();
            var preferredDestination = "Bearna";
            Console.WriteLine($"Check for correct route for {preferredDestination}");
            // Check for specific bus stop on route
            bool routeFound = false;
            foreach (var route in busRoutes)
            {
                if (route.ServesUsingListContains(preferredDestination))
                {
                    Console.WriteLine($"Route {route.Number} serves {preferredDestination}");
                    routeFound = true;
                    break;
                }
            }
            Console.WriteLine("{0}", routeFound ? "Route found" : "Route not found");

            Console.WriteLine();
            Console.WriteLine("Remove first route entry");
            busRoutes.RemoveAt(0);

            Console.WriteLine("Get new first entry");
            var newFirstRoute = busRoutes[0];

            Console.WriteLine("Remove new first entry using Remove(T object)");
            busRoutes.Remove(newFirstRoute);
            Console.WriteLine();

            Console.WriteLine("Current routes:");
            foreach (var item in busRoutes)
                Console.WriteLine(item);
            Console.WriteLine();
            Console.WriteLine("Remove Galway - Letterkenny route");
            // RemoveAll uses predicate to find match to remove
            busRoutes.RemoveAll(route => route.Destination.Equals("Letterkenny", StringComparison.Ordinal));
            Console.WriteLine();
            Console.WriteLine("Current routes:");
            foreach (var item in busRoutes)
                Console.WriteLine(item);
        }

        public static void ArrayExercises()
        {
            var arrayRepository = new ArrayRepository();

            Console.WriteLine("Hello Galway, lets get your bus routes for today!");

            var routeOne = InitializeBusRouteObject(5, new[] { "Galway", "Ballinasloe" });
            var routeTwo = InitializeBusRouteObject(6, new[] { "Galway", "Bearna", "An Spiddéal}" });
            var routeThree = InitializeBusRouteObject(7, new[] { "Galway", "Ballinasloe", "Athlone" });

            Console.WriteLine(routeOne);
            Console.WriteLine(routeTwo);
            Console.WriteLine(routeThree);

            var busRoutes = arrayRepository.InitializeBusRoutesArrayWithSize();

            var busRoutesAlt = arrayRepository.InitializeArrayFromConstructor();

            // Iterate or enumerate over the array. foreach - no frills enumerating
            // myRoute - iteration variable. Assigned each value of the array in turn
            foreach (var myRoute in busRoutes)
            {
                Console.WriteLine(myRoute);
            }

            // Look up by index - 0 - position of item in array
            if (busRoutes[0].Number == 5)
                Console.WriteLine("First Bus route contains bus rounte number 5");

            // Get last item in array fully populated - C#8 special operator. ^n == Length - n
            // Same as busRoutesAlt.Length - 1
            var lastBusRoute = busRoutesAlt[^1];

            if (lastBusRoute != null)
                Console.WriteLine($"Last bus route is: {lastBusRoute.ToString()}");
            else
                Console.WriteLine("Error, no last bus route found.");

            // For loop enumeration. More complex, but more powerful, i.e. can include index in operations.
            // Can iterate for n entries in array
            Console.WriteLine("For loop iteration:");
            for (var i = 0; i < busRoutesAlt.Length; i++)
            {
                Console.WriteLine($"Bus route: {busRoutesAlt[i].ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine();
            // Ex find an item without knowing the index, i.e. an item with a specific value
            // Confirm that busRoute 7 is contained in the 
            // Works - brute force!
            foreach (var route in busRoutes)
            {
                if (route.Number == 7)
                {
                    Console.WriteLine("Found route 7");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            // Use Array.Find - static method. 
            // Lamda expression used for predicate - inline method.
            // Array.Find tests each entry in the array using the predicate until a match is 
            // found. 
            Console.WriteLine("Use Array.Find(T[], predicate<T> match)");
            var busRoute = Array.Find<BusRouteArrayBased>(busRoutes, route => route.Number == 7);
            if (busRoute != null)
                Console.WriteLine("Route 7 found!");
            else
                Console.WriteLine("Route 7 not found");

            // Use Array.Find to get all of the busses originating in Galway. Returns an empty array
            // if no routes found.
            var galwayBuses = Array.FindAll<BusRouteArrayBased>(busRoutes,
                route => route.Origin.Equals("Galway", StringComparison.Ordinal));

            Console.WriteLine();
            Console.WriteLine("All routes originating in Galway:");
            if (galwayBuses.Length > 0)
                foreach (var route in galwayBuses)
                    Console.WriteLine(route.ToString());
            else
                Console.WriteLine("No buses originating from Galway.");

            Console.WriteLine();
            var preferredDestination = "Bearna";
            Console.WriteLine($"Check for correct route for {preferredDestination}");
            // Check for specific bus stop on route
            bool routeFound = false;
            foreach (var route in busRoutes)
            {
                if (route.ServesUsingArrayExists(preferredDestination))
                {
                    Console.WriteLine($"Route {route.Number} serves {preferredDestination}");
                    routeFound = true;
                    break;
                }
            }
            Console.WriteLine("{0}", routeFound ? "Route found" : "Route not found");
        }


        private static BusRouteArrayBased InitializeBusRouteObject(int busRouteNumber, params string[] busStops)
        {
            return new BusRouteArrayBased(busRouteNumber, busStops);
        }
        private static BusRouteListBased InitializeBusRouteListObject(int busRouteNumber, params string[] busStops)
        {
            return new BusRouteListBased(busRouteNumber, busStops);
        }

    }
}