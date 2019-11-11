using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore2.Models;
using BookStore2.Models.Repositories;
using BookStore2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.controllers
{
    public class BookController :Controller
    {
        private readonly IBookStoreRepositories<Book> bookRepository;
        private readonly IBookStoreRepositories<Author> authorRepository;
        public BookController(IBookStoreRepositories<Book> bookRepository,IBookStoreRepositories<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };
            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel viewModel)
        {
            try
            {
                if(viewModel.AuthorId==-1)
                {
                    ViewBag.Message = "Please select an author from the list ";

                var model = new BookAuthorViewModel
                {
                   Authors = FillSelectList()
                 };
                    return View(model);
                }

                var author = authorRepository.Find(viewModel.AuthorId);
                Book book = new Book
                {
                    id = viewModel.BookId,
                    Title = viewModel.Title,
                    Description = viewModel.Descrption,
                    Author = author

                };
                bookRepository.Add(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var authorId = book.Author == null ? book.Author.id = 0 : book.Author.id;
            var viewModel = new BookAuthorViewModel
            {
                BookId = book.id,
                Title = book.Title,
                Descrption = book.Description,
                AuthorId = book.Author.id,
                Authors = authorRepository.List().ToList()
            };
            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BookAuthorViewModel ViewModel)
        {
            try
            {
                var author = authorRepository.Find(ViewModel.AuthorId);
                Book book = new Book
                {
                    id = ViewModel.BookId,
                    Title = ViewModel.Title,
                    Description = ViewModel.Descrption,
                    Author = author

                };
                bookRepository.Update(ViewModel.BookId,book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bookRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> FillSelectList()
        {
            var author = authorRepository.List().ToList();
            author.Insert(0, new Author { id = -1, Fullname = " ---Please selcet an author---" });
            return author;
        }
    }
}