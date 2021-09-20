namespace Arrays_and_Collections.Models.BusApp
{
    public class BusTimesAlt
    {
        // Uses jagged array.
        public string[][] Times { get; }
        public BusRouteArrayBased Route { get; }
        public BusTimesAlt(BusRouteArrayBased route, string [][] times)
        {
            Route = route;
            Times = times;
        }
        public override string ToString()
        {
            var returnString = Route.ToString() + "\n";
            returnString += string.Join("|", Route.PlacesServed);
            returnString += "\n";

            for (var i=0; i < Times.Length ; i++ )
            {
                returnString += string.Join("|", Times[i]);
                returnString += "\n";
            }
            return returnString;
        }
    }
}