using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazorBookApp.Models
{
    public class Book
    {
        [Required]
        public string isbn { get; set; }
        [Required]
        public string title { get; set; }
        public string subtitle { get; set; }
        public string author { get; set; }
        public DateTime published { get; set; }
        public string publisher { get; set; }
        public int pages { get; set; }
        public string description { get; set; }
        public string website { get; set; }
    }

    public class Books
    {
        public Book[] books { get; set; }

        public void Add(Book book)
        {
            List<Book> list = books.OfType<Book>().ToList();
            list.Add(book);
            books = list.ToArray();
        }
    }
}
