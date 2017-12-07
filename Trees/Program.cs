using System;
using System.IO;

namespace Trees
{
    internal class Program
    {
        private static void Main()
        {
            var input = File.ReadAllLines("input.txt");
            var test = new Input[input.Length];
            for (var i = 0; i < input.Length; i++)
                test[i] = new Input(input[i]);

            var t = new Tree(test);
            Console.WriteLine($"Balanced: {t.Balanced.Name} {t.Balanced.Weight}");
            Console.WriteLine($"Root: {t.RootNode.Name} {t.RootNode.Weight}");
            Console.ReadKey();
        }
    }
}