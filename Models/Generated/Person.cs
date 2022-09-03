using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Index("PhoneNumber", Name = "UQ__People__79578B9366CF0684", IsUnique = true)]
    public partial class Person
    {
        public Person()
        {
            Houses = new HashSet<House>();
            SaleBuyers = new HashSet<Sale>();
            SaleSellers = new HashSet<Sale>();
        }

        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Column("First Name")]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;
        [Column("Last Name")]
        [StringLength(30)]
        public string LastName { get; set; } = null!;
        [Column("CompanyID")]
        public int? CompanyId { get; set; }
        [Column("Phone Number")]
        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("People")]
        public virtual Company? Company { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<House> Houses { get; set; }
        [InverseProperty("Buyer")]
        public virtual ICollection<Sale> SaleBuyers { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<Sale> SaleSellers { get; set; }
    }
}
