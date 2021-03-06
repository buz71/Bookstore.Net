using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Cycle
    {
        public Cycle()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
