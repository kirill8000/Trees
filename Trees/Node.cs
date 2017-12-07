using System.Collections.Generic;

namespace Trees
{
    internal class Node
    {
        public List<Node> Children = new List<Node>();
        public int Weight;

        public Node(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
    }
}