using System.ComponentModel;

namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public Client()
        {
            this.Offers = new HashSet<Offer>();
            this.Invoices = new HashSet<Invoice>();
        }
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100), DisplayName("Client name")]
        public string Name { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Is VAT registered")]
        public bool IsVatRegisterd { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
