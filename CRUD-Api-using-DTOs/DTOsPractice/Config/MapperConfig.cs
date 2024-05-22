using AutoMapper;
using DTOsPractice.DTOs;
using DTOsPractice.Models;
namespace DTOsPractice.Config
{
    public class MapperConfig
    {
        public static IMapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserRequestDTO, User>();
                cfg.CreateMap<UpdateUserRequestDTO, User>();
                cfg.CreateMap<User, UserResponseDTO>();
            });

            return config.CreateMapper();
        }
    }
}
