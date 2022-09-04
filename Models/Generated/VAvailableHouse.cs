using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class VAvailableHouse
    {
        public int ForSaleHouseId { get; set; }
        public string Address { get; set; } = null!;
        public string? BuiltAt { get; set; }
        public int SizeM2 { get; set; }
        public int Rooms { get; set; }
        public decimal WantedPrice { get; set; }
        public int? HouseOwnerId { get; set; }
        public string TypeId { get; set; } = null!;
        public int NeighborId { get; set; }
        public string Neighbor { get; set; } = null!;
        public int SameCityId { get; set; }
    }
}
