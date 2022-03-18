using BenchmarkDotNet.Attributes;
using Performance.Code;

namespace Performance.Benchmarker;

public class StringFunctions
{
    [Benchmark()]
    public void BuildStringBadly()
    {
        var x = new StringWorker().BuildBadly("test");
    }

    [Benchmark()]
    public void BuildStringBetter()
    {
        var x = new StringWorker().BuildBetter("test");
    }
}