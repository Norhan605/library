using Job_task.Models.Book;

namespace Job_task.Models.Borrower
{
    public class Borrowers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Books> Books  { get; set; }
    }
}
