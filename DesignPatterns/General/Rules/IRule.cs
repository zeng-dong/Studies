namespace Rules
{
    internal interface IRule
    {
        bool IsApplicable(Context context);

        string Execute(Context context);
    }
}