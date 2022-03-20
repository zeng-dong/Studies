using System.Text;

namespace Performance.Code;

public class StringWorker
{
    public string BuildBadly(string value)
    {
        for (var i = 0; i < 50; i++)
        {
            value += " " + "test";
        }

        return value;
    }

    public string BuildBetter(string value)
    {
        var sb = new StringBuilder(value);

        for (var i = 0; i < 50; i++)
        {
            sb.Append(" ").Append("test");
        }

        return sb.ToString();
    }

    public string BuildBetter2(string value)
    {
        var sb = new StringBuilder(value);

        for (var i = 0; i < 50; i++)
        {
            sb.Append(' ').Append("test");
        }

        return sb.ToString();
    }
}