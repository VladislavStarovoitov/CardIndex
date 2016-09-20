using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPL.Models;
using BLL;

namespace MVCPL.Infrastructure.ModelBinders
{
    public class BookModelBinderEx : DefaultModelBinder
    {
        IValueProvider _valueProvider;

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);
            var book = model as BookViewModel;
            _valueProvider = bindingContext.ValueProvider;

            book.NewAuthors = BindProperty<string>("NewAuthors").ToTagArray();
            book.NewGenres = BindProperty<string>("NewGenres").ToTagArray();

            return model;
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