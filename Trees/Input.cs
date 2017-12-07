namespace Trees
{
    internal class Input
    {
        public string[] Children;
        public string Name;
        public int Weight;

        public Input(string name)
        {
            var replace = name.Replace("->", ">");
            var tmp = replace.Split('>');
            Name = tmp[0].Split(' ')[0];
            Weight = int.Parse(tmp[0].Split(' ')[1].Substring(1, tmp[0].Split(' ')[1].Length - 2));
            if (tmp.Length > 1)
                Children = tmp[1].Replace(" ", "").Split(',');
        }
    }
}