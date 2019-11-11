using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models.Repositories
{
    public class BookRepository : IBookStoreRepositories<Book>
    {
        List<Book> books;
       

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book{
                id = 1,Title = "c#",Description="no",Author = new Author{}
                },
                  new Book{
                id = 2,Title = "java",Description="no",Author = new Author{}
                },
                    new Book{
                id = 3,Title = "c++",Description="no",Author = new Author{}
                },
            };
        }
        public void Add(Book entity)
        {
            entity.id = books.Max(b => b.id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = books.SingleOrDefault(b => b.id == id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id ,Book newbook)
        {
            var book = Find(id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author;

        }
    }
}
