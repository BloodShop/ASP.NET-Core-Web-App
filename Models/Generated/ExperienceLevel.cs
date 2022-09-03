using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReverseEnginereeing.Models
{
    [Table("Experience Levels")]
    public partial class ExperienceLevel
    {
        public ExperienceLevel()
        {
            Specializations = new HashSet<Specialization>();
        }

        [Key]
        [StringLength(8)]
        public string Level { get; set; } = null!;

        [InverseProperty("LevelNavigation")]
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
