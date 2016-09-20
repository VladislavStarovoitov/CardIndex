using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Genre : IEntity
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
