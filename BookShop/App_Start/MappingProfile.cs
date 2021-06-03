using AutoMapper;
using BookShop.Areas.Admin.ViewModel;
using BookShop.Models;

namespace BookShop.App_Start
{
    public class MappingProfile
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>()
                .ForMember(d => d.Authors, s => s.MapFrom(c => c.IdAuthor))
                .ForMember(d => d.Publishers, s => s.MapFrom(c => c.IdPublisher))
                .ForMember(d => d.Categories, s => s.MapFrom(c => c.IdCategory));
            });
            Mapper = config.CreateMapper();
        }
    }
}