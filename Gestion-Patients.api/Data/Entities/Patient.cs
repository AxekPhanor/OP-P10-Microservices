namespace Gestion_Patients.api.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
