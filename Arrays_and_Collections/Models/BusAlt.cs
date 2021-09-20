using System;
using System.Collections.Generic;

namespace Arrays_and_Collections.Models
{
    // Uses a linked list to manage passengers on the bus. 
    public class BusAlt
    {
        public const int Capacity = 5;
        
        public int PassengerCount { get => _passengers.Count; }

        public int Space { get => Capacity - _passengers.Count; }

        private LinkedList<Passenger> _passengers = new LinkedList<Passenger>();

        public bool Load(Passenger passenger)
        {
            if (Space < 1)
                return false;
            _passengers.AddLast(passenger);
            Console.WriteLine($"{passenger} got on bus");
            return true;
        }

        // ArriveAt does not pick up passengers.
        public void ArriveAt(string place)
        {
            if (_passengers.Count == 0)
                return;
            LinkedListNode<Passenger> currentNode = _passengers.First;

            // Manual interation required.
            do
            {
                LinkedListNode<Passenger> nextNode = currentNode.Next;
                var passenger = currentNode.Value;
                if (passenger.Destination.Equals(place, StringComparison.Ordinal))
                {
                    Console.WriteLine($"Passenger {passenger.Name} disembarquing at {place}");
                    _passengers.Remove(currentNode);
                }
                currentNode = nextNode;
            } while (currentNode != null);
            Console.WriteLine($"There are {_passengers.Count} left on the bus.");
        }
    }
}