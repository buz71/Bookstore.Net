using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Client
    {
        public Client()
        {
            Reserves = new HashSet<Reserf>();
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Reserf> Reserves { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
