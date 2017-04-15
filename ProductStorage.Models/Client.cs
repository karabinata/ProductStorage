namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsVatRegisterd { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
