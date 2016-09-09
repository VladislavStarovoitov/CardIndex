using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPL.Models;
using BLL;

namespace MVCPL.Infrastructure.ModelBinders
{
    public class BookModelBinder : IModelBinder
    {
        IValueProvider _valueProvider;
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            _valueProvider = bindingContext.ValueProvider;

            int year = BindProperty<int>("Year");
            string name = BindProperty<string>("Name");
            string description = BindProperty<string>("Description");

            IEnumerable<int> authors = BindProperty<IEnumerable<int>>("Authors") ?? new List<int>();
            IEnumerable<string> newAuthors = BindProperty<string>("NewAuthors").ToTagArray();

            IEnumerable<int> genres = BindProperty<IEnumerable<int>>("Genres") ?? new List<int>();
            IEnumerable<string> newGenres = BindProperty<string>("NewGenres").ToTagArray();

            HttpPostedFileBase imageFile = BindProperty<HttpPostedFileBase>("ImageFile");

            BookViewModel book = new BookViewModel()
            {
                Name = name.Equals(string.Empty) ? null : name,
                Year = year,
                Description = description.Equals(string.Empty) ? null : description,
                NewAuthors = newAuthors,//.Select(nA => new Author { Name = nA, Id = default(int) }),
                NewGenres = newGenres,//.Select(nG => new Genre { Name = nG, Id = default(int) }),
                ImageFile = imageFile
            };

            book.Authors = authors.Select(a => new Author { Name = string.Empty, Id = a }).ToList();
            book.Genres = genres.Select(g => new Genre { Name = string.Empty, Id = g }).ToList();
            
            return book;
        }

        private T BindProperty<T>(string key)
        {
            var value = _valueProvider.GetValue(key);
            if (!ReferenceEquals(value, null))
            {
                return (T)value.ConvertTo(typeof(T));
            }
            return default(T);
        }
    }
}