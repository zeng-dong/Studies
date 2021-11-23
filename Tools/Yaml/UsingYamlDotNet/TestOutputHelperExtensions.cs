using Xunit.Abstractions;

namespace UsingYamlDotNet
{
    public static class TestOutputHelperExtensions
    {
        public static void WriteLine(this ITestOutputHelper output)
        {
            output.WriteLine(string.Empty);
        }
    }
}
