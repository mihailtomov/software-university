namespace P08Threeuple
{
    class Threeuple<T, U, V>
    {
        public Threeuple(T value1, U value2, V value3)
        {
            this.item1 = value1;
            this.item2 = value2;
            this.item3 = value3;
        }
        public T item1 { get; set; }
        public U item2 { get; set; }
        public V item3 { get; set; }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}".ToString();
        }
    }
}
