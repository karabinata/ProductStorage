namespace ProductStorage.ViewModels.Category
{
    using System.ComponentModel;
    using Models;

    public class CategoryListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Category name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        [DisplayName("Parent category")]
        public virtual Category ParentCategory { get; set; }

        public int StorageId { get; set; }

        [DisplayName("Storage")]
        public virtual Storage Storage { get; set; }
    }
}