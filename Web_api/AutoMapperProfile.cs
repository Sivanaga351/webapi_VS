using AutoMapper;
using Web_api.DTO.Characterdto;
using Web_api.Models;

namespace Web_api
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Character, GetCharacterDto>());
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }  
    }
}
