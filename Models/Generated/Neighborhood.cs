using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Houses = new HashSet<House>();
        }

        [Key]
        [Column("NeighborhoodID")]
        public int NeighborhoodId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        [InverseProperty("Neighborhoods")]
        public virtual City City { get; set; } = null!;
        [InverseProperty("Neighborhood")]
        public virtual ICollection<House> Houses { get; set; }
    }
}
