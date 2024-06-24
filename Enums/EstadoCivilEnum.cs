using System.Text.Json.Serialization;

namespace SIGP.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoCivilEnum
    {
        Solteiro,
        Casado,
        Divorciado,
        Viúvo,
        UniaoEstavel
    }
}
