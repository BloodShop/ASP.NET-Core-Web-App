using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int HouseId { get; set; }
        public int? BuyerId { get; set; }
        public int SellerId { get; set; }
        public int SalesManId { get; set; }
        public decimal? FinalPrice { get; set; }
        public float Income { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Person? Buyer { get; set; }
        public virtual House House { get; set; } = null!;
        public virtual SalesMan SalesMan { get; set; } = null!;
        public virtual Person Seller { get; set; } = null!;
    }
}
