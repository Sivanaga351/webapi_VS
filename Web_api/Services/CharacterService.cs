using System.Collections.Generic;
using Web_api.Models;
using System.Linq;
using System.Threading.Tasks;
using Web_api.DTO.Characterdto;
using AutoMapper;
using System;
using Web_api.Data;
using Microsoft.EntityFrameworkCore;

namespace Web_api.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly Datacontext _datacontext;
        public CharacterService(IMapper mapper, Datacontext datacontext)
        {
            _mapper = mapper;
            _datacontext = datacontext;
        }

        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name="Siva" }
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = Characters.Max(c => c.Id) + 1;
            ServiceResponse.Data =  Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return  ServiceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var dbCharacheters = await _datacontext.Characters.ToListAsync();
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            ServiceResponse.Data =  Characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            ServiceResponse.Data = _mapper.Map<GetCharacterDto>(Characters.FirstOrDefault(C => C.Id == id));
            return ServiceResponse;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacher(UpdateCharacterDto updatecharacter)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = Characters.FirstOrDefault(c => c.Id == updatecharacter.Id);
                if (character != null)
                {
                    character.Name = updatecharacter.Name;
                    character.Hitpoint = updatecharacter.Hitpoint;
                    character.Strength = updatecharacter.Strength;
                    character.Defense = updatecharacter.Defense;
                    character.Intelligence = updatecharacter.Intelligence;
                    character.Class = updatecharacter.Class;

                    ServiceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                }
                else
                {
                    Console.WriteLine("Id is not available:", ServiceResponse);
                }
            }
             catch(Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }              
            
               return ServiceResponse;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = Characters.First(c => c.Id == id);
                Characters.Remove(character);
                ServiceResponse.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
    }
}
