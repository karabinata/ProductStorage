namespace ProductStorage
{
    using System.Linq;
    using AutoMapper;
    using Models;
    using ViewModels.Storage;

    public class AutoMappingWebConfig
    {
        public static void StorageMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddEditStorageViewModel, Storage>();

                cfg.CreateMap<Storage, DetailStorageViewModel>()
                    .ForMember(dest => dest.CategoriesCount, mo => mo.MapFrom(src => src.Categories.Count))
                    .ForMember(dest => dest.ProductsCount,
                        mo => mo.MapFrom(src => src.Categories.Sum(c => c.Products.Count)));
            });
        }
    }
}