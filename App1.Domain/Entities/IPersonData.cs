namespace App1.Domain.Entities
{
    public interface IPersonData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? SSN { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
