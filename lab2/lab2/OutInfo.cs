namespace lab2
{
    public class OutInfo
    {
        private int _count;
        private string _name;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public OutInfo(string name, int count)
        {
            this._count = count;
            _name = name;
        }
    }
}