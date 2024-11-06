namespace Api1.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

public class IntJsonConverter : JsonConverter<int>
{
    public override int Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32();
        }
        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if ("unknown".Equals(value))
            {
                return -1;
            }
            var num = (int) long.Parse(value);
            return num;
        }
        throw new Exception($"unsoported case: {reader.TokenType}");

    }
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        int value,
        System.Text.Json.JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}

