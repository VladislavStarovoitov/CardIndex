using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MVCPL.Models
{
    public class IndexViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; }
        public int TotalItems { get; set; } 
        public int TotalPages 
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
        public PageInfo()
        {
            PageSize = int.Parse(WebConfigurationManager.AppSettings["itemsPerPage"]);
        }
    }
}