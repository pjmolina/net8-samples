namespace UnitTesting;

using HelloWorld2;

public class CalulatorTest
{
    [Fact]
    public void CalculatorSumTest()
    {
        var sut = new Calculator();

        var res = sut.Sum(1, 2);

        Assert.Equal(3, res);
    }


    [Fact]
    public void TestWithNegativeNumbers()
    {
        var sut = new Calculator();

        var res = sut.Sum(-1, -6);

        Assert.Equal(-7, res);
    }
}
