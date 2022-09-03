using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Index("PhoneNumber", Name = "UQ__SalesMen__79578B93B9FBA71A", IsUnique = true)]
    public partial class SalesMan
    {
        public SalesMan()
        {
            Sales = new HashSet<Sale>();
            Specializations = new HashSet<Specialization>();
        }

        [Key]
        [Column("SalesManID")]
        public int SalesManId { get; set; }
        [Column("CompanyID")]
        public int CompanyId { get; set; }
        [Column("First Name")]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Column("Last Name")]
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [Column("Phone Number")]
        [StringLength(100)]
        public string? PhoneNumber { get; set; }
        [Column("Hire Date", TypeName = "datetime")]
        public DateTime HireDate { get; set; }
        [Column("Birth Date", TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("SalesMen")]
        public virtual Company Company { get; set; } = null!;
        [InverseProperty("SalesMan")]
        public virtual ICollection<Sale> Sales { get; set; }
        [InverseProperty("SalesMan")]
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
