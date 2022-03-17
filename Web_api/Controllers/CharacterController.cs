using Microsoft.AspNetCore.Mvc;
using Web_api.Models;
using System.Collections.Generic;
using System.Linq;
using Web_api.Services;
using System.Threading.Tasks;
using Web_api.DTO.Characterdto;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterservice;
        public CharacterController(ICharacterService characterservice)
        {
            _characterservice = characterservice;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get()
        {
            return Ok(await _characterservice.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Getsingle(int id)
        {
            return Ok(await _characterservice.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter (AddCharacterDto newCharacter)
        {
            return Ok(await _characterservice.AddCharacter(newCharacter));
        }
        [HttpPut]

        public async Task<ActionResult<ServiceResponse<UpdateCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatecharacter)
        {
            var response = await _characterservice.UpdateCharacher(updatecharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response = await _characterservice.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
