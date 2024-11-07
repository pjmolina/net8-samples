namespace Api2.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

public class LongJsonConverter : JsonConverter<long>
{

    public override long Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if ("unknown".Equals(value))
        {
            return -1;
        }
        return long.Parse(value);
    }
    public override void Write(
        Utf8JsonWriter writer,
        long value,
        JsonSerializerOptions options)
    {
        // writer.WriteNumberValue(value);
        writer.WriteStringValue(value.ToString());
    }
}

