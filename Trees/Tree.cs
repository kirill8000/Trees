using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    internal class Tree
    {
        private readonly List<Input> _list = new List<Input>();
        private Node _balanced;
        private int[,] _matrix;
        public Node RootNode;

        public Tree(Input[] nodes)
        {
            foreach (var t in nodes)
                _list.Add(t);
            GenerateMatrix();
            FindRoot();
            CreateTree(RootNode);
        }

        public Node Balanced
        {
            get
            {
                Balance(RootNode);
                return _balanced;
            }
        }

        private void Balance(Node rootNode)
        {
            if (rootNode.Children.Count > 0)
                foreach (var rootNodeChild in rootNode.Children)
                    Balance(rootNodeChild);
            if (rootNode.Children.Count > 0)
            {
                var sums = new List<int>();
                foreach (var rootNodeChild in rootNode.Children)
                    sums.Add(TowerSum(rootNodeChild));
                if (sums.Max(i => i) - sums.Min(i => i) != 0)
                {
                    var j = (from s in sums group s by s into g where g.Count() == 1 select g.Key).ToArray()[0];
                    var k = sums.IndexOf(j);
                    var l = k == 0 ? k + 1 : k - 1;
                    rootNode.Children[k].Weight = rootNode.Children[k].Weight + TowerSum(rootNode.Children[l]) -
                                                  TowerSum(rootNode.Children[k]);
                    _balanced = new Node(rootNode.Children[k].Name, rootNode.Children[k].Weight);
                }
            }
        }

        private int TowerSum(Node node)
        {
            var sum = node.Weight;
            if (node.Children.Count != 0)
                foreach (var v in node.Children)
                    sum += TowerSum(v);
            return sum;
        }

        private void GenerateMatrix()
        {
            _matrix = new int[_list.Count, _list.Count];
            for (var i = 0; i < _list.Count; i++)
                if (_list[i].Children != null)
                    foreach (var t in _list[i].Children)
                    {
                        var ch = _list.IndexOf((from n in _list where n.Name == t select n)
                            .Single());
                        _matrix[i, ch] = 1;
                    }
        }

        private void FindRoot()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                var k = 0;
                for (var j = 0; j < _list.Count; j++)
                    if (_matrix[j, i] == 1) k++;
                if (k == 0)
                    RootNode = new Node(_list[i].Name, _list[i].Weight);
            }
        }

        public void CreateTree(Node root)
        {
            var j = _list.IndexOf(_list.Single(input => input.Name == root.Name));
            for (var i = 0; i < _list.Count; i++)
                if (_matrix[j, i] > 0)
                    root.Children.Add(new Node(_list[i].Name, _list[i].Weight));
            if (root.Children.Count != 0)
                foreach (var v in root.Children)
                    CreateTree(v);
        }
    }
}