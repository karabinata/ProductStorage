namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50), DisplayName("Category name")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [DisplayName("Parent category")]
        public int? ParentCategoryId { get; set; }

        [DisplayName("Parent category")]
        public virtual Category ParentCategory { get; set; }

        [DisplayName("Storage")]
        public int StorageId { get; set; }

        [DisplayName("Storage")]
        public virtual Storage Storage { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}
