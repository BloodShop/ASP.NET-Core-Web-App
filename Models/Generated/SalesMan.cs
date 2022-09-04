using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class SalesMan
    {
        public SalesMan()
        {
            Sales = new HashSet<Sale>();
            Specializations = new HashSet<Specialization>();
        }

        public int SalesManId { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}
