namespace Api2Test;

using System.Text.Json;
using Api2.Converters;

public class LongJsonConverterTest
{
    [Fact]
    public void LongToJson()
    {
        // AAA

        // Arrange
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new LongJsonConverter()
            }
        };

        var obj = new SampleValueHolder
        {
            Value = 42
        };
        // Act
        var json = JsonSerializer.Serialize(obj, options);

        // Assert
        Assert.Contains("\"42\"", json);

    }
    [Fact]
    public void JsonToLong()
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new LongJsonConverter()
            }
        };
        var json = "{\"Value\":\"123\"}";
        var obj = JsonSerializer.Deserialize<SampleValueHolder>(json, options);

        Assert.Equal(123, obj.Value);

    }
    [Fact]
    public void JsonToLongUnknown()
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new LongJsonConverter()
            }
        };
        var json = "{\"Value\":\"unknown\"}";
        var obj = JsonSerializer.Deserialize<SampleValueHolder>(json, options);

        Assert.Equal(-1, obj.Value);
    }
}

public class SampleValueHolder
{
    public long Value { get; set; }
}
