using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    public partial class House
    {
        public House()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        [Column("HouseID")]
        public int HouseId { get; set; }
        [StringLength(35)]
        public string Address { get; set; } = null!;
        [Column("Built At", TypeName = "datetime")]
        public DateTime? BuiltAt { get; set; }
        [Column("Size (M^2)")]
        public int SizeM2 { get; set; }
        public int Rooms { get; set; }
        [Column("Wanted Price", TypeName = "money")]
        public decimal WantedPrice { get; set; }
        [Column("For Sale")]
        public bool ForSale { get; set; }
        [Column("OwnerID")]
        public int? OwnerId { get; set; }
        [Column("TypeID")]
        [StringLength(20)]
        public string TypeId { get; set; } = null!;
        [Column("NeighborhoodID")]
        public int NeighborhoodId { get; set; }

        [ForeignKey("NeighborhoodId")]
        [InverseProperty("Houses")]
        public virtual Neighborhood Neighborhood { get; set; } = null!;
        [ForeignKey("OwnerId")]
        [InverseProperty("Houses")]
        public virtual Person? Owner { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("Houses")]
        public virtual HouseType Type { get; set; } = null!;
        [InverseProperty("House")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
