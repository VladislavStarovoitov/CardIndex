using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
    [Bind(Exclude = "Image, Id")]
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }

        public List<Genre> Genres { get; set; }
        public IEnumerable<int> GenreIds { get; set; }

        public int Year { get; set; }
        public string Description { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public byte[] Image { get; set; }

        public BookViewModel()
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();

            AuthorIds = new int[0];
            GenreIds = new int[0];
        }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}