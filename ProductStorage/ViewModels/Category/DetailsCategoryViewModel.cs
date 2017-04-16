namespace ProductStorage.ViewModels.Category
{
    using System.ComponentModel;

    public class DetailsCategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Category name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Parent category")]
        public string ParentCategoryName { get; set; }

        [DisplayName("Storage")]
        public string StorageName { get; set; }

        [DisplayName("Number of products in category")]
        public int ProductsCount { get; set; }
    }
}