namespace ProductStorage.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Storage
    {
        public Storage()
        {
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
