namespace ReverseEnginereeing.Models
{
    public partial class SalesMan
    {
        public string FullName => $"{FirstName} {LastName}";
        public int Age => Convert.ToInt32(DateTime.UtcNow.Date.Year - BirthDate.Year);
        public override string ToString() =>
          $"ID: {SalesManId}\nFullname: {FirstName} {LastName}\nPhone: {PhoneNumber}\nCompanyID: {CompanyId}\nBirthDate: {BirthDate}\nHireDate: {HireDate}\n";
    }
}