﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get { return this.title; } private set { this.title = value; } }
        public int Year { get { return this.year; } private set { this.year = value; } }
        public List<string> Authors { get { return this.authors; } private set { this.authors = value; } }

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }

            return result;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
