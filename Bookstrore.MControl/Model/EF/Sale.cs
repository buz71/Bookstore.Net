using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.MControl
{
    public partial class Sale
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long ProductId { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public string Date { get; set; }

        public virtual Client Client { get; set; }
        public virtual Store Product { get; set; }
    }
}
