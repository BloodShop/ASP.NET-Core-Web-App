using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Index("CountryName", Name = "UQ__Countrie__E056F201DD0CDF79", IsUnique = true)]
    [Index("Numeric", Name = "UQ__Countrie__FD07398E83A4904D", IsUnique = true)]
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public int CountryId { get; set; }
        [StringLength(100)]
        public string CountryName { get; set; } = null!;
        [Column("Alpha-2 Code")]
        [StringLength(2)]
        public string Alpha2Code { get; set; } = null!;
        [Column("Alpha-3 Code")]
        [StringLength(3)]
        public string Alpha3Code { get; set; } = null!;
        [StringLength(3)]
        [Unicode(false)]
        public string Numeric { get; set; } = null!;

        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }
    }
}
