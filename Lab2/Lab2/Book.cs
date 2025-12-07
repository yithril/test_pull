using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int AuthorId { get; set; }

        public Book(int id, string title, decimal price, int authorId)
        {
            Id = id;
            Title = title;
            Price = price;
            AuthorId = authorId;
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - {Price:C}";
        }
    }
}
