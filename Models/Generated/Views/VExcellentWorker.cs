using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models.Generated.Views
{
    [Keyless]
    public partial class VExcellentWorker
    {
        public int? Year { get; set; }
        [Column("SalesManID")]
        public int SalesManId { get; set; }
        [Column("Total Income")]
        public float? TotalIncome { get; set; }
    }
}
