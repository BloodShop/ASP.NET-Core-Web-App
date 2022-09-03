using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    public partial class City
    {
        public City()
        {
            Neighborhoods = new HashSet<Neighborhood>();
        }

        [Key]
        public int CityId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string CityName { get; set; } = null!;
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; } = null!;
        [InverseProperty("City")]
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
