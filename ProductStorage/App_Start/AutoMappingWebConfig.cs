namespace ProductStorage
{
    using System.Linq;
    using AutoMapper;
    using Models;
    using ViewModels.Category;
    using ViewModels.Product;
    using ViewModels.Storage;
    using ViewModels.Client;

    public class AutoMappingWebConfig
    {
        public static void Mappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddEditStorageViewModel, Storage>();

                cfg.CreateMap<Storage, DetailsStorageViewModel>()
                    .ForMember(dest => dest.CategoriesCount, mo => mo.MapFrom(src => src.Categories.Count))
                    .ForMember(dest => dest.ProductsCount,
                        mo => mo.MapFrom(src => src.Categories.Sum(c => c.Products.Count)));

                cfg.CreateMap<Category, CategoryListViewModel>();

                cfg.CreateMap<Category, DetailsCategoryViewModel>()
                    .ForMember(dest => dest.ProductsCount, mo => mo.MapFrom(src => src.Products.Count()))
                    .ForMember(dest => dest.ParentCategoryName,
                        mo => mo.MapFrom(src => src.ParentCategory.Name))
                    .ForMember(dest => dest.StorageName,
                        mo => mo.MapFrom(src => src.Storage.Name));

                cfg.CreateMap<Client, ClientListViewModel>();

                cfg.CreateMap<Product, ProductListViewModel>();
            });
        }
    }
}