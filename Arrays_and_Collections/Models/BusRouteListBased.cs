using System;
using System.Collections.Generic;

namespace Arrays_and_Collections.Models
{
    public class BusRouteListBased
    {
        public int Number { get;  }
        public string Origin { get; }
        public string Destination { get; }
        public List<string> PlacesServed { get; }

        public BusRouteListBased(int number, string[] placesServed)
        {
            Number = number;
            PlacesServed = new List<string>(placesServed);
            Origin = PlacesServed[0];
            Destination = PlacesServed[^1];
        }
        public override string ToString() => $"Bus number {Number}, origin: {Origin} -> destination: {Destination}";

        public bool Serves(string busStop)
        {
            foreach (var stop in PlacesServed)
            {
                if (stop.Equals(busStop, StringComparison.Ordinal))
                    return true;
                    
            }
            return false;
        }
        public bool ServesUsingListFind(string busStop)
        {
            var stopFound = PlacesServed.Find(route => route.Equals(busStop, StringComparison.Ordinal));
            if (string.IsNullOrEmpty(stopFound))
                return false;
            else
                return true;
        }
        public bool ServesUsingListContains(string busStop)
        {
            return PlacesServed.Contains(busStop);
        }
    }
}
