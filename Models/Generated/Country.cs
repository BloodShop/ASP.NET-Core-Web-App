using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public string Alpha2Code { get; set; } = null!;
        public string Alpha3Code { get; set; } = null!;
        public string Numeric { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
