using System.Collections.Generic;
using Xunit;

namespace dotnetcore_kata
{
    public class NodeShould
    {
        [Theory]
        public void Find_Trips_To_Node()
        {
            var node = new Node("A");

            node.Links = new List<Node>();
            node.Links.Add(new Node("B"));

            var tripsToNode = node.FindNode("B");

            var stuff = node.AvailableNextNodes();

            var superStuff = node.AvailableNodes();
        }
    }
}
