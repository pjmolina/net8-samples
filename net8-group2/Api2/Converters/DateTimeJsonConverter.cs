namespace Api2.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    //  DateTime <-> string
    //    class                              json
    //    string Created                     "created": "2014-12-09T13:50:49.641000Z",

    //    class                              json
    //    string Created                     "created": "2014-12-09T13:50:49.641000Z",


    public override DateTime Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var dt = DateTime.Parse(value);
        return dt;
    }
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        DateTime value,
        System.Text.Json.JsonSerializerOptions options)
    {
        var res = value.ToString("O");
        writer.WriteStringValue(res);
    }
}

