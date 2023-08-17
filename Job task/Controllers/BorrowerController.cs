
using Job_task.Models;
using Microsoft.AspNetCore.Mvc;
using Job_task.Models.Borrower;
using Job_task.Models.Book;

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

      
        public IActionResult UpdateBorrower(int id)
        {
            var borrower = context.Borrowers.Find(id);
           
            return View(borrower);
        }

        [HttpPost]

        public IActionResult UpdateBorrower(int id, Borrowers borrowers)
        {
            var borrower = context.Borrowers.Find(id);
            try
            {
                if (borrowers is not null)
                {
                    borrower.Name = borrowers.Name;
                    borrower.Code = borrowers.Code;
                    
                }
                

                context.Update(borrower);
                context.SaveChanges();

                return RedirectToAction("GetBorrowers");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult DeleteBorrower(int id)
        {

            var deletedBorrower = context.Borrowers.Find(id);
            context.Borrowers.Remove(deletedBorrower);
            context.SaveChanges();

            return RedirectToAction("GetBorrowers");
        }



        public IActionResult Search()
        {
            var borrower = context.Borrowers.ToList();

            return View(borrower);
        }
        [HttpPost]
        public IActionResult Search(string searchNum)
        {
            List<Borrowers> borrowers;
            if (string.IsNullOrEmpty(searchNum))
            {
                borrowers = context.Borrowers.ToList();
            }
            else
            {
                borrowers = context.Borrowers.Where(b => b.Name.StartsWith(searchNum)).ToList();
            }
            return View("GetBorrowers", borrowers);
        }



    }
}
