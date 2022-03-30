using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Store
    {
        public Store()
        {
            Decommissioneds = new HashSet<Decommissioned>();
            Reserves = new HashSet<Reserf>();
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public long ActionId { get; set; }
        public long TagId { get; set; }

        public virtual Action Action { get; set; }
        public virtual Publication Product { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<Decommissioned> Decommissioneds { get; set; }
        public virtual ICollection<Reserf> Reserves { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
