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

    public (string lastName, string firstName) NaiveSplit(string name)
    {
        var commaPosition = name.IndexOf(',');
        var lastName = name.Substring(0, commaPosition);
        var firstName = name.Substring(commaPosition + 2);

        return (lastName, firstName);
    }

    public (string lastName, string firstName) SplitSplit(string name)
    {
        var nameArray = name.Split(',');

        return (nameArray[0].Trim(), nameArray[1].Trim());
    }

    public (string lastName, string firstName) SpanSplit(string name)
    {
        ReadOnlySpan<char> span = name.AsSpan();

        var lastName = span.Slice(0, name.IndexOf(',')).ToString();
        var firstName = span.Slice(name.IndexOf(',') + 2).ToString();

        return (lastName, firstName);
    }
}