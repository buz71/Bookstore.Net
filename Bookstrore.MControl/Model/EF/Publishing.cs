using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Publishing
    {
        public Publishing()
        {
            Publications = new HashSet<Publication>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
