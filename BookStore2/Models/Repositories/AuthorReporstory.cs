using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models.Repositories
{
    public class AuthorReporsitory:IBookStoreRepositories<Author>
    {
        IList<Author> authors;
        public AuthorReporsitory()
        {
            authors = new List<Author>()
            {
                new Author {id=1,Fullname="loaymannaa"},
                new Author {id=2,Fullname="foo"},
                new Author {id=3,Fullname="lolo"},

                 
            };
        }

        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }


        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.Fullname = newAuthor.Fullname;

        }
    }
}
