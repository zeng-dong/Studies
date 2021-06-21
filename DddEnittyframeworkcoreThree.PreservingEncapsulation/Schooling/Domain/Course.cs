using DddEnittyframeworkcoreThree.PreservingEncapsulation.Core;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain
{
    public class Course : Entity
    {
        public static readonly Course Calculus = new Course(1, "Calculus");
        public static readonly Course Chemistry = new Course(2, "Chemistry");

        public static readonly Course[] AllCourses = { Calculus, Chemistry };



        public string Name { get; }
        //public string Credits { get; set; }

        protected Course()
        {
        }

        private Course(long id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}
