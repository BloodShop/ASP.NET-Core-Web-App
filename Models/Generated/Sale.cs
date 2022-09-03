using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Index("SaleId", Name = "UQ__Sales__1EE3C41E0DBBEAF7", IsUnique = true)]
    public partial class Sale
    {
        [Key]
        [Column("SaleID")]
        public int SaleId { get; set; }
        [Column("HouseID")]
        public int HouseId { get; set; }
        [Column("BuyerID")]
        public int? BuyerId { get; set; }
        [Column("SellerID")]
        public int SellerId { get; set; }
        [Column("SalesManID")]
        public int SalesManId { get; set; }
        [Column("Final Price", TypeName = "money")]
        public decimal? FinalPrice { get; set; }
        public float Income { get; set; }
        [Column("Sale date", TypeName = "datetime")]
        public DateTime? SaleDate { get; set; }
        [Column("Publish Date", TypeName = "datetime")]
        public DateTime PublishDate { get; set; }

        [ForeignKey("BuyerId")]
        [InverseProperty("SaleBuyers")]
        public virtual Person? Buyer { get; set; }
        [ForeignKey("HouseId")]
        [InverseProperty("Sales")]
        public virtual House House { get; set; } = null!;
        [ForeignKey("SalesManId")]
        [InverseProperty("Sales")]
        public virtual SalesMan SalesMan { get; set; } = null!;
        [ForeignKey("SellerId")]
        [InverseProperty("SaleSellers")]
        public virtual Person Seller { get; set; } = null!;
    }
}
