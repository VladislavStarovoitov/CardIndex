using MVCPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPL.Infrastructure.ModelValidatorProviders
{
    public class BookValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(BookViewModel))
            {
                return new ModelValidator[] { new BookValidator(metadata, context) };
            }
            return Enumerable.Empty<ModelValidator>();
        }
    }
}