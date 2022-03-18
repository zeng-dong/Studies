using Xunit;

namespace Performance.Code.Tests;

public class StringTests
{
    [Fact]
    public void Build_string_badly()
    {
        var s = new StringWorker().BuildBadly("test");

        Assert.Equal("test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test", s);
    }

    [Fact]
    public void Build_string_better()
    {
        var s = new StringWorker().BuildBetter("test");

        Assert.Equal("test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test test", s);
    }

    [Fact]
    public void Functions_are_equivalent()
    {
        var sw = new StringWorker();

        var bad = sw.BuildBadly("test");
        var better = sw.BuildBetter("test");

        Assert.Equal(bad, better);
    }
}