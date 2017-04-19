namespace ProductStorage.ViewModels.Product
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Models.Validation;
    using Models;

    public class ProductListViewModel
    {
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
    }
}