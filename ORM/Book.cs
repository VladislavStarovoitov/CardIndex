 namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Authors = new HashSet<Author>();
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public byte[] Cover { get; set; }

        public string CoverMimeType { get; set; }

        public byte[] Content { get; set; }

        public string ContentMimeType { get; set; }

        public DateTime CreationDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
