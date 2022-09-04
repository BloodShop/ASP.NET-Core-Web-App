using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Houses = new HashSet<House>();
        }

        public int NeighborhoodId { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<House> Houses { get; set; }
    }
}
