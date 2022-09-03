using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    public partial class Company
    {
        public Company()
        {
            People = new HashSet<Person>();
            SalesMen = new HashSet<SalesMan>();
        }

        [Key]
        [Column("CompanyID")]
        public int CompanyId { get; set; }
        [Column("Company Name")]
        [StringLength(24)]
        [Unicode(false)]
        public string CompanyName { get; set; } = null!;
        [StringLength(124)]
        public string? Website { get; set; }
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [InverseProperty("Company")]
        public virtual ICollection<Person> People { get; set; }
        [InverseProperty("Company")]
        public virtual ICollection<SalesMan> SalesMen { get; set; }
    }
}
