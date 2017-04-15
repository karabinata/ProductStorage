namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class Product
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Price]
        public decimal Price { get; set; }

        [Quantity]
        public int Quantity { get; set; }

        [Quantity]
        public int MinimumQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
