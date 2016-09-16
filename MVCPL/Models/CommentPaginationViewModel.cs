using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPL.Models
{
    public class BookInfoViewModel
    {
        public BookViewModel Book { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}