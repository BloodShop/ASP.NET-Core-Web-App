using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class City
    {
        public City()
        {
            Neighborhoods = new HashSet<Neighborhood>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
