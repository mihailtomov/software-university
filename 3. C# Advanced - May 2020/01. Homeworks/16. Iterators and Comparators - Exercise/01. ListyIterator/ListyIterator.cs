using System;
using System.Collections.Generic;

namespace P01ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int currentIndex = 0;

        public ListyIterator()
        {
            this.list = new List<T>();
        }

        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        public bool Move()
        {
            if (this.currentIndex + 1 < this.list.Count)
            {
                this.currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.list.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(this.list[this.currentIndex]);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
