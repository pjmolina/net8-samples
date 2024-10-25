namespace Test1;

using HelloWorld;

public class CalculatorTest
{
    [Fact()]
    public void SumTest()
    {
        var sut = new Calculator();

        var res = sut.Sum(1, 2);

        Assert.Equal(3, res);

    }
}
