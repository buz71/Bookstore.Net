using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Action
    {
        public Action()
        {
            Stores = new HashSet<Store>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
