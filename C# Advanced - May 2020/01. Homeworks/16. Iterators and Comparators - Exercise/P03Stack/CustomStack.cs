using System;
using System.Collections;
using System.Collections.Generic;

namespace P03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public CustomStack()
        {
            this.stack = new List<T>();
        }

        public void Push(T element)
        {
            this.stack.Add(element);
        }

        public void Pop()
        {
            if (this.stack.Count > 0)
            {
                T element = this.stack[this.stack.Count - 1];
                this.stack.RemoveAt(this.stack.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
