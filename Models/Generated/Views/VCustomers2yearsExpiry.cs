using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models.Generated.Views
{
    [Keyless]
    public partial class VCustomers2yearsExpiry
    {
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Column("Full Name")]
        [StringLength(61)]
        public string FullName { get; set; } = null!;
        public int CityId { get; set; }
        [Column("Phone Number")]
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        [Column("Sale Date")]
        [StringLength(40)]
        [Unicode(false)]
        public string? SaleDate { get; set; }
    }
}
