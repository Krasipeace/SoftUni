using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library
    {
         private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }       

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.books)
            {
                yield return book;
            }
        }       
    }
}
