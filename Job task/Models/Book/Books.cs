using Job_task.Models.Borrower;

namespace Job_task.Models.Book
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int NumOfCopies { get; set; }

        public List<Borrowers> Borrowers { get; set; }

    }
}
