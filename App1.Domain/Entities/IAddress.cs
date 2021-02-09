namespace App1.Domain.Entities
{
    public interface IAddress
    {
        string StreetAddress { get; set; }

        string StreetNumber { get; set; }

        string? ApartmentNumber { get; set; }

        string ZipCode { get; set; }

        string City { get; set; }

        string? State { get; set; }

        string? Country { get; set; }
    }
}
