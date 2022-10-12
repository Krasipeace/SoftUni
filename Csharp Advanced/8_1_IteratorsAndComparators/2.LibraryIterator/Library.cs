using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.Books = new List<Book>(books);
            }

            public List<Book> Books { get; set; }
            public int currentIndex { get; set; }
            public Book Current => this.Books[currentIndex];
            object IEnumerator.Current => this.Current;

            public void Dispose() { }
            public bool MoveNext()
            {
                return ++this.currentIndex < this.Books.Count();
            }
            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
