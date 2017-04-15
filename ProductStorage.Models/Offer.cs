namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class Offer
    {
        public Offer()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Discount]
        public int Discount { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

    }
}
