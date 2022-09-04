using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Specialization
    {
        public int SalesManId { get; set; }
        public string TypeId { get; set; } = null!;
        public string Level { get; set; } = null!;

        public virtual ExperienceLevel LevelNavigation { get; set; } = null!;
        public virtual SalesMan SalesMan { get; set; } = null!;
        public virtual HouseType Type { get; set; } = null!;
    }
}
