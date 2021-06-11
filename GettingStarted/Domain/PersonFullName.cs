namespace GettingStarted.Domain
{
    public class PersonFullName
    {
        public PersonFullName(string givenName, string surName)
        {
            SurName = surName;
            GivenName = givenName;
        }

        public string SurName { get; private set; }
        public string GivenName { get; private set; }
        public string FullName => $"{GivenName} {SurName}";
    }
}
