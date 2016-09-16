using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPL.Infrastructure.ModelBinders;
using System.ComponentModel.DataAnnotations;
using MVCPL.Models.Interfaces;

namespace MVCPL.Models
{
    //[ModelBinder(typeof(BookModelBinderEx))]
    [ModelBinder(typeof(BookModelBinder))]
   // [Bind(Exclude = "Image")]
    public class BookViewModel : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Enter book name")]
        public string Name { get; set; }
        
        public int Year { get; set; }

        [Required]

        public string Description { get; set; }

        public List<Author> Authors { get; set; }
        public IEnumerable<string> NewAuthors { get; set; }
        public IEnumerable<int> AuthorsSelected { get; set; }

        public List<Genre> Genres { get; set; }
        public IEnumerable<string> NewGenres { get; set; }
        public IEnumerable<int> GenresSelected { get; set; }

        //Наверно стоит отделить 
        //public string NewAuthors { get; set; }
        //public string NewGenres { get; set; }
        //
        public HttpPostedFileBase ImageFile { get; set; }
        public byte[] Image { get; set; }

        public BookViewModel()
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();

            AuthorsSelected = new List<int>();
            GenresSelected = new List<int>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Year > DateTime.Now.Year)
            {
                yield return new ValidationResult($"Year must be less than {DateTime.Now.Year}", new string[] { "Year" });
            }
        }
    }

    public class Author : ITag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre : ITag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}