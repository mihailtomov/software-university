using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class BookEnumerator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex = -1;

        public BookEnumerator(List<Book> books)
        {
            this.books = books;
        }
        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            this.currentIndex++;

            return currentIndex < books.Count;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}