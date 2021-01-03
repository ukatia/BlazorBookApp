using BlazorBookApp.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBookApp.Services
{
    public class BookService
    {

        private string filename = "Data\\books.json";
        public Task<Book[]> GetBooksAsync()
        {
            string json = File.ReadAllText(this.filename);
            Books bookList = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(json);
            return Task.FromResult(bookList.books);
        }

        public string Create(Book book)
        {
            if (book.isbn == null || book.title == null)
            {
                return "ISBN and title are missing!";
            }
            string json = File.ReadAllText(this.filename);
            Books bookList = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(json);
            bookList.Add(book);
            string jsonOutput = JsonConvert.SerializeObject(bookList);
            System.IO.File.WriteAllText(this.filename, jsonOutput);
            return "";
        }
        public Book GetById(string isbn)
        {
            string json = File.ReadAllText(this.filename);
            Books bookList = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(json);
            bookList.books = bookList.books.Where(val => val.isbn != isbn).ToArray();
            return bookList.books[0];
        }

        public string Delete(string isbn)
        {
            string json = File.ReadAllText(this.filename);
            Books bookList = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(json);
            bookList.books = bookList.books.Where(val => val.isbn != isbn).ToArray();
            string jsonOutput = JsonConvert.SerializeObject(bookList);
            System.IO.File.WriteAllText(this.filename, jsonOutput);
            return "";
        }

        public string Edit(string isbn, Book book)
        {
            string json = File.ReadAllText(this.filename);
            Books bookList = Newtonsoft.Json.JsonConvert.DeserializeObject<Books>(json);
            int index = -1;
            for (int i=0; i<bookList.books.Length; i++)
            {
                if (bookList.books[i].isbn == isbn)
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
            {
                bookList.books[index] = book;
            }
            string jsonOutput = JsonConvert.SerializeObject(bookList);
            System.IO.File.WriteAllText(this.filename, jsonOutput);
            return "";
        }
    }
}
