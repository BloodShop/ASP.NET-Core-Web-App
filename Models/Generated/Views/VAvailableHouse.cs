using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models.Generated.Views
{
    [Keyless]
    public partial class VAvailableHouse
    {
        [Column("For sale HouseID")]
        public int ForSaleHouseId { get; set; }
        [StringLength(35)]
        public string Address { get; set; } = null!;
        [Column("Built At")]
        [StringLength(40)]
        [Unicode(false)]
        public string? BuiltAt { get; set; }
        [Column("Size (M^2)")]
        public int SizeM2 { get; set; }
        public int Rooms { get; set; }
        [Column("Wanted Price", TypeName = "money")]
        public decimal WantedPrice { get; set; }
        [Column("HouseOwnerID")]
        public int? HouseOwnerId { get; set; }
        [Column("TypeID")]
        [StringLength(20)]
        public string TypeId { get; set; } = null!;
        [Column("NeighborID")]
        public int NeighborId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Neighbor { get; set; } = null!;
        [Column("SameCityID")]
        public int SameCityId { get; set; }
    }
}
