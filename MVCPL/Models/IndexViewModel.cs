using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCPL.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    [Bind(Exclude = "Image, Authors, Id")]
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<string> Authors { get; set; }

        public int Year { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
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