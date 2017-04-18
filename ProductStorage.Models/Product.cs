using System.ComponentModel;

namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class Product
    {
        public Product()
        {
            this.Offers = new HashSet<Offer>();
            this.Invoices = new HashSet<Invoice>();
        }
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100), DisplayName("Product name")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Price]
        public double Price { get; set; }

        [Quantity]
        public int Quantity { get; set; }

        [Quantity, DisplayName("Minimum quantity")]
        public int MinimumQuantity { get; set; }

        [Required, DisplayName("Item category")]
        public int CategoryId { get; set; }

        [DisplayName("Item category")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
