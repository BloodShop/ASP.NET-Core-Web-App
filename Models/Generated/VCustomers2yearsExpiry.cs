using System;
using System.Collections.Generic;

namespace ReverseEnginereeing.Models
{
    public partial class VCustomers2yearsExpiry
    {
        public int PersonId { get; set; }
        public string FullName { get; set; } = null!;
        public int CityId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SaleDate { get; set; }
    }
}
