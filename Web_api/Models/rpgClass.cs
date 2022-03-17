using System.Text.Json.Serialization;

namespace Web_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum rpgClass
    {
       Knight,

       Mage,

       Cleric

    }
}
