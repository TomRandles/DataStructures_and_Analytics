using System;

namespace Arrays_and_Collections.Models.BusApp
{
    public class BusRouteArrayBased
    {
        public int Number { get;  }
        public string Origin { get; }
        public string Destination { get; }
        public string[] PlacesServed { get; }

        public BusRouteArrayBased(int number, string[] placesServed)
        {
            Number = number;
            PlacesServed = placesServed;
            Origin = placesServed[0];
            Destination = placesServed[^1];
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
        public bool ServesUsingArrayFind(string busStop)
        {
            var stopFound = Array.Find<string>(PlacesServed, route => route == busStop);
            if (string.IsNullOrEmpty(stopFound))
                return false;
            else
                return true;
        }
        public bool ServesUsingArrayExists(string busStop)
        {
            return Array.Exists<string>(PlacesServed, route => route == busStop);
        }
    }
}
