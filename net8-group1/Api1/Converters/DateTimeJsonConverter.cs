namespace Api1.Converters;

using System.Text.Json.Serialization;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var date = DateTime.Parse(value);
        return date;
    }
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        DateTime value,
        System.Text.Json.JsonSerializerOptions options)
    {
        var str = value.ToString("O");
        writer.WriteStringValue(str);
    }
}

