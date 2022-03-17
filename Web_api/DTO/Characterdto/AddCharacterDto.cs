using Web_api.Models;

namespace Web_api.DTO.Characterdto
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Srinu";
        public int Hitpoint { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public rpgClass Class { get; set; } = rpgClass.Cleric;
    }
}
