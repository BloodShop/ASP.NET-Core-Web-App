using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class Person
    {
        public Person()
        {
            Houses = new HashSet<House>();
            SaleBuyers = new HashSet<Sale>();
            SaleSellers = new HashSet<Sale>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? CompanyId { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Sale> SaleBuyers { get; set; }
        public virtual ICollection<Sale> SaleSellers { get; set; }
    }
}
