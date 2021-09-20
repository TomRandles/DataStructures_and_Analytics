using System.Collections.Generic;

namespace Arrays_and_Collections.Models
{
    public class BusStop
    {
        private Queue<Passenger> _peopleWaiting = new Queue<Passenger>();

        public int PeopleWaitingCount { get => _peopleWaiting.Count; }

        public void PersonArrive(Passenger passenger)
        {
            _peopleWaiting.Enqueue(passenger);
            System.Console.WriteLine($"{passenger} waiting at busstop.");
        }

        public void BusArrive (Bus bus)
        {
            System.Console.WriteLine("Bus arrived at stop to pick up passengers");
            while ((bus.Space > 0) && (_peopleWaiting.Count > 0))
            {
                // Bus loading in accordance with the bus stop queue, i.e. those waiting longest embarque first. 
                var passenger = _peopleWaiting.Dequeue();
                bus.Load(passenger);
            }
        }

        // BusAlt uses a linked list. 
        public void BusArrive(BusAlt bus)
        {
            System.Console.WriteLine("Bus arrived at stop to pick up passengers");
            while ((bus.Space > 0) && (_peopleWaiting.Count > 0))
            {
                // Bus loading in accordance with the bus stop queue, i.e. those waiting longest embarque first. 
                var passenger = _peopleWaiting.Dequeue();
                bus.Load(passenger);
            }
        }
    }
}