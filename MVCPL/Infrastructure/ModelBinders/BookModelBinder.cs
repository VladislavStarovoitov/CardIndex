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
        private IValueProvider _valueProvider;
        private ModelStateDictionary _modelState;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            _valueProvider = bindingContext.ValueProvider;
            _modelState = controllerContext.Controller.ViewData.ModelState;

            int year = BindProperty<int>("Year");
            string name = BindProperty<string>("Name");
            string description = BindProperty<string>("Description");

            int[] authors = BindProperty<int[]>("AuthorsSelected");
            IEnumerable<string> newAuthors = BindProperty<string>("NewAuthors").ToTagArray();

            int[] genres = BindProperty<int[]>("GenresSelected");
            IEnumerable<string> newGenres = BindProperty<string>("NewGenres").ToTagArray();

            HttpPostedFileBase imageFile = BindProperty<HttpPostedFileBase>("ImageFile");

            BookViewModel book = new BookViewModel()
            {
                Name = name.Equals(string.Empty) ? null : name,
                Year = year,
                Description = description.Equals(string.Empty) ? null : description,
                NewAuthors = newAuthors,
                NewGenres = newGenres,
                CoverFile = imageFile
            };
            
            return book;
        }

        private T BindProperty<T>(string key)
        {
            var value = _valueProvider.GetValue(key);
            try
            {
                if (!ReferenceEquals(value, null))
                {
                    return (T)value.ConvertTo(typeof(T));
                }
            }
            catch (InvalidOperationException)
            {
                _modelState.AddModelError(key, "Choose the correct data.");
            }
            return default(T);
        }
    }
}