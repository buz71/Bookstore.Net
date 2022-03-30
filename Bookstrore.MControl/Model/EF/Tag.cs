using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Tag
    {
        public Tag()
        {
            Stores = new HashSet<Store>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
