using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class House
    {
        public House()
        {
            Sales = new HashSet<Sale>();
        }

        public int HouseId { get; set; }
        public string Address { get; set; } = null!;
        public DateTime? BuiltAt { get; set; }
        public int SizeM2 { get; set; }
        public int Rooms { get; set; }
        public decimal WantedPrice { get; set; }
        public bool ForSale { get; set; }
        public int? OwnerId { get; set; }
        public string TypeId { get; set; } = null!;
        public int NeighborhoodId { get; set; }

        public virtual Neighborhood Neighborhood { get; set; } = null!;
        public virtual Person? Owner { get; set; }
        public virtual HouseType Type { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
