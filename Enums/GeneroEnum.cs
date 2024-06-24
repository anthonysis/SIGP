using System.Text.Json.Serialization;

namespace SIGP.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneroEnum
    {
        Masculino,
        Feminino,
        NaoInformado
    }
}
