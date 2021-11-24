using Xunit.Abstractions;

namespace UsingYamlDotNetCoreTests
{
    public static class TestOutputHelperExtensions
    {
        public static void WriteLine(this ITestOutputHelper output)
        {
            output.WriteLine(string.Empty);
        }
    }
}
