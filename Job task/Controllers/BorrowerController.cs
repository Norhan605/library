
using Job_task.Models;
using Microsoft.AspNetCore.Mvc;
using Job_task.Models.Borrower;

namespace Job_task.Controllers
{
    public class BorrowerController : Controller
    {
        Context context = new Context();
        public IActionResult GetBorrowers()
        {

            var borrower = context.Borrowers.ToList();
            return View("GetBorrowers", borrower);
        }

        [Route("Book/GetBorrowerDetails/{id}")]
        public IActionResult GetBorrowerDetails(int id)
        {

            var borrower = context.Borrowers.FirstOrDefault(x => x.Id == id);
            ViewBag.borrowerDetail = borrower;
            return View();
        }

        public IActionResult CreateBorrower()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateBorrower(Borrowers borrower)
        {

            context.Add(borrower);
            context.SaveChanges();

            return RedirectToAction("GetBorrowers");
        }

        public IActionResult UpdateBorrower()
        {
            return View();
        }

        [HttpPost]

        public IActionResult UpdateBorrower(Borrowers borrower)
        {

            context.Update(borrower);
            context.SaveChanges();

            return RedirectToAction("GetBorrowers");
        }

        public IActionResult DeleteBorrower()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBorrower(int id)
        {

            var deletedBorrower = context.Books.Find(id);
            context.Books.Remove(deletedBorrower);
            context.SaveChanges();

            return RedirectToAction("GetBorrowers");
        }

    }
}
