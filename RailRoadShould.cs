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
        [InlineData("AB", "BC")]
        public void Distance_Of_Route_A_B_C(string stepOne, string stepTwo)
        {
            int expectedDistance = 9;
            var getDistance = _railRoad.CalculateDistance(stepOne, stepTwo);

            Assert.Equal(getDistance, expectedDistance);
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
        [InlineData("AE7", "AE7")]
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
        private Dictionary<string, int> _routes = new Dictionary<string, int>();

        public int CalculateDistance(string origin, string end)
        {
            return 0;
        }

        public void LoadRoutes(string route)
        {
            _routes[UnderstandRoute(route)] = RetrieveDistanceFromRoute(route);
        }

        public string UnderstandRoute(string fullRoute)
        {
            return fullRoute.Substring(0,2);
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
    }
}
