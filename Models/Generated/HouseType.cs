using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class HouseType
    {
        public HouseType()
        {
            Houses = new HashSet<House>();
            Specializations = new HashSet<Specialization>();
        }

        public string TypeId { get; set; } = null!;

        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
