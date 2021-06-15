namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain
{
    public class Student
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long FavoriteCourseId { get; private set; }

        public Student(string name, string email, long favoriteCouseId)
        {
            Name = name;
            Email = email;
            FavoriteCourseId = favoriteCouseId;
        }
    }

    // public setters: not easy to maintain invariant
    // efc binds to backing fields by default, that is why we can use private setters, or even no setters

    // efc 3.x can instantiate object with custom ctor, so no need for parameter-less ctor (public or private)?
    //    but these parameter names must match the Property Names
    //    if public Student(string name2, string email, long favoriteCouseId), for example, we get InvalidOperationException
}
