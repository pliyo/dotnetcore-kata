using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;

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
        [InlineData("AB5", 5)]
        [InlineData("BC4", 4)]
        [InlineData("CD8", 8)]
        [InlineData("DC8", 8)]
        [InlineData("DE6", 6)]
        [InlineData("AD5", 5)]
        [InlineData("CE2", 2)]
        [InlineData("EB3", 3)]
        [InlineData("AE7", 7)]
        public void UnderstandRoute_Format(string route, int expectedDistance)
        {
            int distance = _railRoad.UnderstandRoute(route);

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

        public int UnderstandRoute(string route)
        {
            var distance = route[2].ToString();
            return int.Parse(distance);
        }

        public void LoadRoutes(string route)
        {
            var origin = route[0];
            var end = route[1];
            _routes[route] = UnderstandRoute(route);
        }
    }
}
