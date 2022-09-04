using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class VNeighborhoodTotalPrice
    {
        public string CityName { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public decimal? TotalWanted { get; set; }
    }
}
