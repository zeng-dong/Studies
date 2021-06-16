namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain
{
    public class Student
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        //public long FavoriteCourseId { get; private set; }

        // virtual here to enable lazy loading
        public virtual Course FavoriteCourse { get; private set; }

        //public Student(string name, string email, long favoriteCouseId)
        //{
        //    Name = name;
        //    Email = email;
        //    FavoriteCourseId = favoriteCouseId;
        //}


        public Student(string name, string email, Course favoriteCouse) : this()
        {
            Name = name;
            Email = email;
            FavoriteCourse = favoriteCouse;
        }


        // so this is a violation of separation of concern, this ctor is persistence/orm concern

        // efc lazy loading requires non-private parameter-less ctor so we change it to protected

        protected Student()    // but efc 3.x not smart enough to supply non-primative type parameters, so when we use Course in ctor, we need the parameter-less ctor
        {

        }
    }

    // public setters: not easy to maintain invariant
    // efc binds to backing fields by default, that is why we can use private setters, or even no setters

    // efc 3.x can instantiate object with custom ctor, so no need for parameter-less ctor (public or private)?
    //    but these parameter names must match the Property Names
    //    if public Student(string name2, string email, long favoriteCouseId), for example, we get InvalidOperationException

    // but efc 3.x not smart enough to supply non-primative type parameters, so when we use Course in ctor, we need the parameter-less ctor

    // two ways to m2o: id or navigation property. id is violation of separation of concerns

    // Persistence Ignorance only applies to the domain model: Entities, Aggregates, Value Objects, Domain Events, Pure Domain Services
}
