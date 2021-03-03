using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Projec.Models
{
    public class Book
    {
        [Required(ErrorMessage = "O código é obrigatorio")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O autor é obrigatorio")]
        public string Author { get; set; }

        [Required(ErrorMessage = "O ano de publicação é obrigatorio")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "O ano deve possuir 4 digitos")]
        public int YearOfPublication { get; set; }

        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Title = "Domain Driven Design",
                    Author = "Eric Evans",
                    YearOfPublication = 2003
                },
                new Book
                {
                    ID = 2,
                    Title = "Agile Principles, Patterns, and practices in c#",
                    Author = "Robert C. Marim",
                    YearOfPublication = 2006
                },
                new Book
                {
                    ID = 3,
                    Title = "Clean Code",
                    Author = "Robert C. Marim",
                    YearOfPublication = 2008
                },
            };
        }
    }
}