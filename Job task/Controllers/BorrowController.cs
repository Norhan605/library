using Job_task.Models;
using Job_task.Models.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Job_task.Controllers
{
    public class BorrowController : Controller

    {
        Context context = new Context();
      
      

        public IActionResult index()
        {
            var books = context.Books.ToList();

            //ViewBag.Book = books;
            //ViewBag.Books = new SelectList(books, "Id");
            //ViewBag.Borrowers =new SelectList(context.Borrowers,"Id");

            ViewBag.Books = new SelectList(books, "Id", "Name"); 


            return View();
        }



        [HttpPost]
        public ActionResult Borrow(int bookId)
        {
            var books = context.Books.ToList();
            var book =context.Books.FirstOrDefault(b => b.Id == bookId); 

            if (book != null && book.NumOfCopies > 0)
            {
                book.NumOfCopies--; 

                ViewBag.Message = "Book borrowed successfully.";
            }
            else
            {
                ViewBag.Message = "Book is not available.";
            }
            context.SaveChanges();
            ViewBag.Books = new SelectList(books, "Id", "Name");
            context.SaveChanges();
            return View("Index");
        }






        public IActionResult Borrow()
        {
            var books = context.Books.ToList();

            ViewBag.Books = new SelectList(books, "Id", "Name");
            return View("Index");
        }





        //[HttpPost]



        //public IActionResult Borrow(string searchNum )
        //{
        //    List<Books> book;
        //    if (string.IsNullOrEmpty(searchNum))
        //    {
        //        book = context.Books.ToList();
        //    }
        //    else
        //    {
        //        book = context.Books.Where(b => b.Name.StartsWith(searchNum)).ToList();
        //    }

        //if (string.IsNullOrEmpty(searchNum))
        //{
        //    book = context.Books.ToList();
        //}
        //else if(int.IsNegative(id))
        //{
        //    book = context.Books.ToList();
        //}
        //else
        //{
        //    book = context.Books
        //        .Where(b => b.Name.StartsWith(searchNum))
        //        .Where(b=>b.Id==id)
        //        .ToList();
        //}

        //return View(book);
    }



        //[HttpPost]
        //public IActionResult Borrow(int bookId, int borrowerId)
        //{
        //    var book =context.Books.FirstOrDefault(b => b.Id == bookId);
        //    var borrower = context.Borrowers.FirstOrDefault(b => b.Id == borrowerId);

        //    if (book == null)
        //    {
        //        ViewBag.Success = false;
        //        ViewBag.Message = "Book not found.";
        //    }
        //    else if (borrower == null)
        //    {
        //        ViewBag.Success = false;
        //        ViewBag.Message = "Borrower not found.";

        //    }
        //    else if(book.NumOfCopies==0)
        //    {
        //        ViewBag.Success = false;
        //        ViewBag.Message = "Number Of Copies = 0";
        //    }

        //    else
        //    {

        //        book.Id = borrower.Id;

        //        book.NumOfCopies--;

        //        context.SaveChanges();

        //        ViewBag.Success = true;
        //        ViewBag.Message = "Book borrowed successfully.";
        //    }

        //    return View();
        //}
    }
    
