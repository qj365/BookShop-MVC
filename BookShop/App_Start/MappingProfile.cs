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
                cfg.CreateMap<Book, Book>();
                
            });
            Mapper = config.CreateMapper();
        }
    }
}