using System;
using System.Collections;
using System.Collections.Generic;

namespace P01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
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
        
        public void PrintAll()
        {
            foreach (var item in this.list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
