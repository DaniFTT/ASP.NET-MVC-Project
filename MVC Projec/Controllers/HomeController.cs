using MVC_Projec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Projec.Controllers
{
    public class HomeController : Controller
    {
        private static List<Book> Books;

        public HomeController()
        {
            if (Books == null)
                Books = new Book().GetBooks();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(Books);
        }

        public ActionResult NovoLivro()
        {
            return View();
        }

        public ActionResult EditarLivro(int id)
        {
            return View(Books.FirstOrDefault(x => x.ID == id));
        }

        [HttpPost]
        public ActionResult InserirLivro(Book book)
        {
            if (ModelState.IsValid)
            {
                if (!Books.Any(x => x.ID == book.ID))
                    Books.Add(book);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoLivro", book);
            }
        }

        [HttpPost]
        public ActionResult AtualizarLivro(Book book)
        {
            if (ModelState.IsValid)
            {
                var index = Books.FindIndex(x => x.ID == book.ID);
                Books[index] = book;
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditarLivro", book);
            }
        }

        public ActionResult ExcluirLivro(int id)
        {
            Books.Remove(Books.FirstOrDefault(x => x.ID == id));
            return RedirectToAction("Index");
        }
    }
}