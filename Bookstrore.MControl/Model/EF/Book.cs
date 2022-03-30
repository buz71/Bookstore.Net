using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Book
    {
        public Book()
        {
            Publications = new HashSet<Publication>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long AutorId { get; set; }
        public long GenreId { get; set; }
        public long CycleId { get; set; }

        public virtual Author Autor { get; set; }
        public virtual Cycle Cycle { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
