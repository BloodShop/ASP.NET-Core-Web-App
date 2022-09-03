using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Table("House types")]
    public partial class HouseType
    {
        public HouseType()
        {
            Houses = new HashSet<House>();
            Specializations = new HashSet<Specialization>();
        }

        [Key]
        [Column("TypeID")]
        [StringLength(20)]
        public string TypeId { get; set; } = null!;

        [InverseProperty("Type")]
        public virtual ICollection<House> Houses { get; set; }
        [InverseProperty("Type")]
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
