using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore2.Models;
using BookStore2.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookStoreRepositories<Author> authorReporsitory;
        public AuthorController(IBookStoreRepositories<Author> authorReporsitory)
        {
            this.authorReporsitory = authorReporsitory;

        }
        // GET: Author
        public ActionResult Index()
        {
            var authors = authorReporsitory.List();
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {

            var authors = authorReporsitory.Find(id);
            return View(authors);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                authorReporsitory.Add(author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var author = authorReporsitory.Find(id);
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                authorReporsitory.Update(id, author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var author = authorReporsitory.Find(id);
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                authorReporsitory.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}