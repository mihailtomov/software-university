namespace P07Tuple
{
    class Tuple<T, V>
    {
        public Tuple(T value1, V value2)
        {
            this.item1 = value1;
            this.item2 = value2;
        }
        public T item1 { get; set; }
        public V item2 { get; set; }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}".ToString();
        }
    }
}
