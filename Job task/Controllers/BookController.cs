using Job_task.Models;
using Job_task.Models.Book;
using Microsoft.AspNetCore.Mvc;

namespace Job_task.Controllers
{
    public class BookController : Controller
    {
        Context context = new Context();
        public IActionResult GetBooks()
        {

            var book = context.Books.ToList();
            return View("GetBooks", book);
        }

        [Route("Book/GetBookDetails/{id}")]
        public IActionResult GetBookDetails(int id)
        {

            var book = context.Books.FirstOrDefault(x => x.Id == id);
            ViewBag.BookDetails = book;
            return View();
        }

        public IActionResult CreateBook()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Books book)
        {

            context.Add(book);
            context.SaveChanges();

            return RedirectToAction("GetBooks");
        }

        public IActionResult UpdateBook(int id)
        {
            var Book = context.Books.Find(id);
            // ViewBag.Book = Book;
            return View(Book);
        }

        [HttpPost]

        public IActionResult UpdateBook(int id, Books bookModel)
        {
            var Book = context.Books.Find(id);
            try
            {
                if (bookModel is not null)
                {
                    Book.Name = bookModel.Name;
                    Book.Code = bookModel.Code;
                    Book.NumOfCopies = bookModel.NumOfCopies;
                }
                // Book.Borrowers=bookModel.Borrowers;


                context.Update(Book);
                context.SaveChanges();

                return RedirectToAction("GetBooks");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult DeleteBook(int id)
        {

            var deletedBook = context.Books.Find(id);
            context.Books.Remove(deletedBook);
            context.SaveChanges();

            return RedirectToAction("GetBooks");
        }


        public IActionResult Search()
        {
            var book = context.Books.ToList();

            return View(book);
        }
        [HttpPost]
        public IActionResult Search(string searchNum)
        {
            List<Books> book;
            if (string.IsNullOrEmpty(searchNum))
            {
                book = context.Books.ToList();
            }
            else
            {
                book = context.Books.Where(b => b.Name.StartsWith(searchNum)).ToList();
            }
            return View("GetBooks",book);
        }

        public JsonResult autoComp(string term)
        {
            List<string> book;
            book = context.Books.Where(b => b.Name.StartsWith(term))
                .Select(b => b.Name).ToList();
            return Json(book, System.Web.Mvc.JsonRequestBehavior.AllowGet);
               
        }
    }
}