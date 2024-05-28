using AutoMapper;

namespace Authentication.Config.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
               
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
