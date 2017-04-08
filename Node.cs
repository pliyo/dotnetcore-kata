using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace dotnetcore_kata
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
            //Links = new List<Node>();
        }
        public string Name { get; private set; }

        public List<Node> Links { get; set; }

        public int FindNode(string node)
        {
            //var nodesWith = Links.Value.Where(x => x.Name).ToList();

            //return nodesWith.Count;
            return 0;
        }

        public List<string> AvailableNextNodes()
        {
            return Links.Select(x => x.Name).ToList();
        }

        public object AvailableNodes()
        {
            return Links.Select(x => x.Links.Select(u => u.Name)).ToList();
        }
    }
}
