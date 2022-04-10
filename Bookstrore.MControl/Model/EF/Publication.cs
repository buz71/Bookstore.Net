using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Publication
    {
        public Publication()
        {
            Stores = new HashSet<Store>();
        }

        public long Id { get; set; }
        public long BookId { get; set; }
        public long PublishingId { get; set; }
        public long Pages { get; set; }
        public long SeriesId { get; set; }
        public long Year { get; set; }
        public double CostPrice { get; set; }

        public virtual Book Book { get; set; }
        public virtual Publishing Publishing { get; set; }
        public virtual Series Series { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
