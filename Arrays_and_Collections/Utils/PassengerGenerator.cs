using Arrays_and_Collections.Models;
using Arrays_and_Collections.Models.BusApp;
using System;

namespace Arrays_and_Collections.Utils
{
    public static class PassengerGenerator
    {
        private static int _count = 0;
        private static Random _random = new Random();
        public static Passenger CreatePassenger()
        {
            return new Passenger($"Person {++_count}", "Limerick");
        }
        public static Passenger CreatePassengerWithDifferentDestinations()
        {
            var destination = (_random.Next(2) == 0) ? "Ennis" : "Limerick";
            return new Passenger($"Person {++_count}", destination);
        }
    }
}