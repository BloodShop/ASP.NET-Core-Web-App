using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Company
    {
        public Company()
        {
            People = new HashSet<Person>();
            SalesMen = new HashSet<SalesMan>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Website { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<SalesMan> SalesMen { get; set; }
    }
}
