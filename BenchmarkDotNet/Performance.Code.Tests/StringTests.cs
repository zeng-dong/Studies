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

    [Fact]
    public void Split_string_in_vaive_way()
    {
        var name = "Zeng, Michael";
        var worker = new StringWorker();

        var lastName = worker.NaiveSplit(name).lastName;
        var firstName = worker.NaiveSplit(name).firstName;

        Assert.Equal("Zeng", lastName);
        Assert.Equal("Michael", firstName);
    }

    [Fact]
    public void Split_string_using_split_function()
    {
        var name = "Zeng, Michael";
        var worker = new StringWorker();

        var lastName = worker.SplitSplit(name).lastName;
        var firstName = worker.SplitSplit(name).firstName;

        Assert.Equal("Zeng", lastName);
        Assert.Equal("Michael", firstName);
    }

    [Fact]
    public void Split_string_using_span_function()
    {
        var name = "Zeng, Michael";
        var worker = new StringWorker();

        var lastName = worker.SpanSplit(name).lastName;
        var firstName = worker.SpanSplit(name).firstName;

        Assert.Equal("Zeng", lastName);
        Assert.Equal("Michael", firstName);
    }
}