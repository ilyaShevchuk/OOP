namespace lab2
{
    public class OutInfo
    {
        public int Count { get; }

        public string Name { get; }

        public OutInfo(string name, int count)
        {
            Count = count;
            Name = name;
        }
    }
}