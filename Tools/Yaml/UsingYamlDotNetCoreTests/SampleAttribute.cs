using Xunit;

namespace UsingYamlDotNetCoreTests
{
    public class SampleAttribute : FactAttribute
    {
        public string Description { get; set; }
    }
}
