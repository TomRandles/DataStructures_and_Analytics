using System;
using System.Collections.Generic;

namespace Arrays_and_Collections.Models.BusApp
{
    public class Bus
    {
        public const int Capacity = 5;
        
        public int PassengerCount { get => _passengers.Count; }

        public int Space { get => Capacity - _passengers.Count; }

        private Stack<Passenger> _passengers = new Stack<Passenger>();

        public bool Load(Passenger passenger)
        {
            if (Space < 1)
                return false;
            _passengers.Push(passenger);
            Console.WriteLine($"{passenger} got on bus");
            return true;
        }

        public Passenger UnloadAPassenger()
        {
            return _passengers.Pop();
        }
    }
}