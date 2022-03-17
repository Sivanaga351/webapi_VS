using System.Collections.Generic;
using System.Threading.Tasks;
using Web_api.DTO.Characterdto;
using Web_api.Models;

namespace Web_api.Services
{
    public interface ICharacterService 
    {

        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacher(UpdateCharacterDto updatecharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
