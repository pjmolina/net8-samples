namespace Api1Test;

using System.Text.Json;
using Api1.Converters;
using Microsoft.Extensions.Options;

public class IntJsonConverterTests
{
    [Fact]
    public void ConvertStringToInt()
    {
        // Arrange
        var options = new JsonSerializerOptions
        {
            Converters = { new IntJsonConverter() }
        };
        // Act 
        var result = JsonSerializer.Deserialize<Sample>("{\"Value\":\"123\"}", options);
        // Assert
        Assert.Equal(123, result.Value);

    }

    [Fact]
    public void ConvertIntToString()
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new IntJsonConverter() }
        };
        var obj = new Sample { Value = 42 };
        var json = JsonSerializer.Serialize(obj, options);

        Assert.Contains("42", json);
    }

    [Fact]
    public void ConvertWhenUnknown()
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new IntJsonConverter() }
        };
        var result = JsonSerializer.Deserialize<Sample>("{\"Value\":\"unknown\"}", options);
        Assert.Equal(-1, result.Value);
    }
}

public class Sample
{
    public int Value { get; set; }
}
