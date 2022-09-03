using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Table("Specialization")]
    public partial class Specialization
    {
        [Key]
        [Column("SalesManID")]
        public int SalesManId { get; set; }
        [Key]
        [Column("TypeID")]
        [StringLength(20)]
        public string TypeId { get; set; } = null!;
        [StringLength(8)]
        public string Level { get; set; } = null!;

        [ForeignKey("Level")]
        [InverseProperty("Specializations")]
        public virtual ExperienceLevel LevelNavigation { get; set; } = null!;
        [ForeignKey("SalesManId")]
        [InverseProperty("Specializations")]
        public virtual SalesMan SalesMan { get; set; } = null!;
        [ForeignKey("TypeId")]
        [InverseProperty("Specializations")]
        public virtual HouseType Type { get; set; } = null!;
    }
}
