using BookStore2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.ViewModel
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Descrption { get; set; }

        public int AuthorId { get; set; }
        public List<Author> Authors { get; set; }
    }

}
