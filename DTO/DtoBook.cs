using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DtoAuthor> Authors { get; set; }
        public List<DtoGenre> Genres { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public byte[] Cover { get; set; }
        public string CoverMimeType { get; set; }
        public byte[] Content { get; set; }
        public string ContentMimeType { get; set; }
        public DateTime CreationDate { get; set; }

        public DtoBook()
        {
            Authors = new List<DtoAuthor>();
            Genres = new List<DtoGenre>();
        }
    }
}
