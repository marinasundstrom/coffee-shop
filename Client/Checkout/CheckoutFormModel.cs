using System;
using System.ComponentModel.DataAnnotations;

namespace App1.Client.Checkout
{
    public class CheckoutFormModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string SSN { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [ValidateComplexType]
        public Common.Address BillingAddress { get; set; } = new Common.Address();

        //[ValidateComplexType]
        //public Common.Address ShippingAddress { get; set; } = new Common.Address();
    }
}
