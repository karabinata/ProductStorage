namespace ProductStorage.ViewModels.Storage
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AddEditStorageViewModel
    {
        [DisplayName("Storage name")]
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}