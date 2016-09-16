using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCPL.Models
{
    public class BookPaginationViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}