using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models.Generated.Views
{
    [Keyless]
    public partial class VNeighborhoodTotalPrice
    {
        [StringLength(30)]
        [Unicode(false)]
        public string CityName { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Neighborhood { get; set; } = null!;
        [Column("Total Wanted", TypeName = "money")]
        public decimal? TotalWanted { get; set; }
    }
}
