using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCPL.Models;
using System.Linq;

namespace MVCPL.Infrastructure.ModelValidatorProviders
{
    public class BookValidator : ModelValidator
    {
        public BookValidator(ModelMetadata metadata, ControllerContext controllerContext) 
            : base(metadata, controllerContext)
        { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            BookViewModel book = container as BookViewModel;
            if (!ReferenceEquals(book, null))
            {
                switch (Metadata.PropertyName)
                {
                    case "NewGenres":
                        {
                            if (book.NewGenres.Count() != 0)
                            {
                                var existGenres = (List<Genre>)ControllerContext.Controller.TempData.Peek("genres");
                                bool anyDuplicate = book.NewGenres.Any(g => existGenres.Select(eG => eG.Name).Contains(g));
                                if (anyDuplicate)
                                {
                                    yield return
                                        new ModelValidationResult { Message = "Don't duplicate athors" };
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}