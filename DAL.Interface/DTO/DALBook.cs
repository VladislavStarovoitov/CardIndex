using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAL.Interface.DTO
{
    public class DALBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Authors { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
