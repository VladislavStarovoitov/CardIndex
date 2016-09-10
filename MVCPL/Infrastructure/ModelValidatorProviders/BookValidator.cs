using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCPL.Models;
using MVCPL.Models.Interfaces;
using System.Linq;

namespace MVCPL.Infrastructure.ModelValidatorProviders
{
    public class BookValidator : ModelValidator
    {
        private const string genres = "genres";
        private const string authors = "authors";

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
                        if (AnyDuplicate<Genre>(book.NewGenres, genres))
                        {
                            yield return new ModelValidationResult { Message = $"Don't duplicate {genres}" };
                        }
                        break;
                    case "NewAuthors":
                        if (AnyDuplicate<Author>(book.NewAuthors, authors))
                        {
                            yield return new ModelValidationResult { Message = $"Don't duplicate {authors}" };
                        }
                        break;
                    case "Genres":
                        if (!IsCorrect<Genre>(book.Genres.Select(a => a.Id), genres))
                        {
                            yield return new ModelValidationResult { Message = $"Choose correct {genres}" };
                        }
                        break;
                    case "Authors":
                        if (!IsCorrect<Author>(book.Authors.Select(a => a.Id), authors))
                        {
                            yield return new ModelValidationResult { Message = $"Choose correct {authors}" };
                        }
                        break;
                }
            }
        }

        //Объединить методы
        private bool AnyDuplicate<T>(IEnumerable<string> newTags, string tagName) where T : ITag
        {
            bool anyDuplicate = false;
            if (newTags.Count() != 0)
            {
                var existGenres = ((List<T>)ControllerContext.Controller.TempData.Peek(tagName))
                                  .Select(eG => eG.Name);
                anyDuplicate = newTags.Any(g => existGenres.Contains(g));                
            }
            return anyDuplicate;
        }

        private bool IsCorrect<T>(IEnumerable<int> tagIds, string tagName) where T : ITag
        {
            bool isCorrect = true;
            if (tagIds.Count() != 0)
            {
                IEnumerable<int> existGenreIds = ((List<T>)ControllerContext.Controller.TempData.Peek(tagName))
                                                 .Select(eG => eG.Id);
                isCorrect = !tagIds.Any(tI => !existGenreIds.Contains(tI));
            }
            return isCorrect;
        }
    }
}