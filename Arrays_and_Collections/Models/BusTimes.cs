namespace Arrays_and_Collections.Models
{
    public class BusTimes
    {
        public string[,] Times { get; }
        public BusRouteArrayBased Route { get; }
        public BusTimes(BusRouteArrayBased route, string [,] times)
        {
            Route = route;
            Times = times;
        }
        public override string ToString()
        {
            var returnString = Route.ToString() + "\n";
            returnString += string.Join("|", Route.PlacesServed);
            returnString += "\n";

            var numberOfBusStops = Times.GetLength(1);
            var numberOfBusRuns = Times.GetLength(0);

            for (var i=0; i < numberOfBusRuns; i++ )
            { 
                for(var j=0;j< numberOfBusStops;j++)
                { 
                    returnString += Times[i, j];
                    if (j != (numberOfBusStops -1))
                        returnString += "|";
                }
                returnString += "\n";
            }
            return returnString;
        }
    }
}