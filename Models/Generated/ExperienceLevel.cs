using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class ExperienceLevel
    {
        public ExperienceLevel()
        {
            Specializations = new HashSet<Specialization>();
        }

        public string Level { get; set; } = null!;

        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
