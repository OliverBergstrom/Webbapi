using System.Text.Json.Serialization;

namespace Webbapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Maträtter
    {
        Kött,

        Vegitariskt,

        Havsmat,
    }
}