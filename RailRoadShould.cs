using System;
using System.Collections.Generic;
using Xunit;

namespace dotnetcore_kata
{
    public class RailRoadShould
    {
        private RailRoad _railRoad;

        public RailRoadShould()
        {
            _railRoad = new RailRoad();
            _railRoad.LoadRoutes("AB5");
            _railRoad.LoadRoutes("BC4");
            _railRoad.LoadRoutes("CD8");
            _railRoad.LoadRoutes("DC8");
            _railRoad.LoadRoutes("DE6");
            _railRoad.LoadRoutes("AD5");
            _railRoad.LoadRoutes("CE2");
            _railRoad.LoadRoutes("EB3");
            _railRoad.LoadRoutes("AE7");
        }

        [Theory]
        [InlineData("ABC", "9")]
        [InlineData("AD", "5")]
        [InlineData("ADC", "13")]
        [InlineData("AEBCD", "22")]
        [InlineData("AED", "NO SUCH ROUTE")]
        public void Distance_Of_Trip(string trip, string expectedDistance)
        {
            var message = _railRoad.ReportDistance(trip);

            Assert.Equal(message, expectedDistance);
        }

        [Theory]
        [InlineData("ABC", 2)]
        [InlineData("ABCD", 3)]
        [InlineData("AEDEU", 4)]
        [InlineData("ABCDUFHGJA", 9)]
        public void Understand_Trip_Format(string trip, int expectedSteps)

        {
            var getDistance = _railRoad.UnderstandTrip(trip);

            Assert.Equal(getDistance.Count, expectedSteps);
        }

        [Theory]
        [InlineData("AB", 5)]
        [InlineData("BC", 4)]
        [InlineData("CD", 8)]
        [InlineData("DC", 8)]
        [InlineData("DE", 6)]
        [InlineData("AD", 5)]
        [InlineData("CE", 2)]
        public void Calculate_Distance_Of_A_Given_Route(string route, int expectedDistance)
        {
            var getDistance = _railRoad.CalculateRouteDistance(route);

            Assert.Equal(getDistance, expectedDistance);
        }

        [Theory]
        [InlineData("AB5", "AB")]
        [InlineData("BC4", "BC")]
        [InlineData("CD8", "CD")]
        [InlineData("DC8", "DC")]
        [InlineData("DE6", "DE")]
        [InlineData("AD5", "AD")]
        [InlineData("CE2", "CE")]
        [InlineData("EB3", "EB")]
        [InlineData("AE7", "AE")]
        public void UnderstandRoute_Format_Get_Route(string route, string expectedRoute)
        {
            string actualRoute = _railRoad.UnderstandRoute(route);

            Assert.Equal(actualRoute, expectedRoute);
        }

        [Theory]
        [InlineData("AB5", 5)]
        [InlineData("BC4", 4)]
        [InlineData("CD8", 8)]
        [InlineData("DC8", 8)]
        [InlineData("DE6", 6)]
        [InlineData("AD5", 5)]
        [InlineData("CE2", 2)]
        [InlineData("EB3", 3)]
        [InlineData("AE7", 7)]
        public void UnderstandRoute_Format_Get_Distance(string route, int expectedDistance)
        {
            int distance = _railRoad.RetrieveDistanceFromRoute(route);

            Assert.Equal(distance, expectedDistance);
        }


    }

    public class RailRoad
    {
        private char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private Dictionary<string, int> _routes = new Dictionary<string, int>();

        public string ReportDistance(string trip)
        {
            var totalDistance = CalculateTripDistance(trip);
            if (totalDistance < 0) return "NO SUCH ROUTE";
            else
                return totalDistance.ToString();
        }

        public string CalculatePossibleTrips(string origin, string end)
        {
            // A A, A B, A C, A D, A E, A F...
            // D

            List<string> possibleRoutesFromOrigin = new List<string>();
            int possibleTripsStartingFrom_Origin = 0;
            string newRoute = "";

            foreach (var value in _alphabet)
            {
                newRoute = value.ToString();
                origin += value;

                var calculateRoute = CalculateRouteDistance(origin);
                if (calculateRoute > 0)
                {
                    possibleTripsStartingFrom_Origin++;
                    possibleRoutesFromOrigin.Add(origin);
                }
            }

            foreach(var value in possibleRoutesFromOrigin)
            {

            }

            return "";
        }

        public void LoadRoutes(string route)
        {
            _routes[UnderstandRoute(route)] = RetrieveDistanceFromRoute(route);
        }

        public string UnderstandRoute(string fullRoute)
        {
            return fullRoute.Substring(0,2);
        }

        public List<string> UnderstandTrip(string fullRoute)
        {
            List<string> routes = new List<string>();
            int length = 2;

            for(int i = 0; i <= fullRoute.Length - length; i++)
            {
                string route = fullRoute.Substring(i, length);
                routes.Add(route);
            }

            return routes;
        }

        public int RetrieveDistanceFromRoute(string fullRoute)
        {
            var extractedDistance = fullRoute[2].ToString();
            return int.Parse(extractedDistance);
        }

        public int CalculateRouteDistance(string route)
        {
            if(_routes.ContainsKey(route))
            {
                return _routes[route];
            }

            return -1;
        }

        public int CalculateTripDistance(string trip)
        {
            int totalDistance = 0;
            var steps = UnderstandTrip(trip);
            foreach(var step in steps)
            {
                var addDistance = CalculateRouteDistance(step);

                if (addDistance < 0)
                {
                    totalDistance = -1;
                    return totalDistance;
                }

                totalDistance += addDistance;
            }

            return totalDistance;
        }
    }
}
