namespace ProductStorage.ViewModels.Storage
{
    using System.ComponentModel;

    public class DetailsStorageViewModel
    {

        public int Id { get; set; }

        [DisplayName("Storage name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Number of categories in storage")]
        public int CategoriesCount { get; set; }

        [DisplayName("Number of products in storage")]
        public int ProductsCount { get; set; }
    }
}