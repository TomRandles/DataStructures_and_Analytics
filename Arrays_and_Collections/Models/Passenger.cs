namespace Arrays_and_Collections.Models
{
    public class Passenger
    {
        public string Name { get; init; }
        public string Destination { get; init; }

        public Passenger(string name, string destination)
        {
            Name = name;
            Destination = destination;
        }
        public override string ToString() => $"Name {Name}, destination: {Destination}";
    }
}