using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int Year { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
