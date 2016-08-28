using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPL.Models
{
    [Bind(Exclude = "Image, Authors,Id")]
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string[] Authors { get; set; }
        
        public int Year { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}