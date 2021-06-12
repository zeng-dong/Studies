using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Theory
{
    public class NonSeparationOfConcern_Course
    {
        [Column("Is_active", TypeName = "char(1)")]
        public bool IsActive { get; set; }

        [Column("Students_enrolled", TypeName = "int")]
        public int NumberOfStudents { get; set; }
    }

    // violates the principle of separation of concerns: two concerns: domain modeling and orm mapping

    // use fluent mapping instead (never use attribute mapping)

    public class CourseDto
    {
        [RegularExpression("[a-zA-Z]{1,50}")]
        public string Name { get; set; }
    }

    // it is ok to have multiple concerns if the topic is simple and introduces no additional complexity, like incoming input with validation


    public class NonEncapsulated_Course
    {
        public bool IsActive { get; set; }

        public int NumberOfStudents { get; set; }

        // no way to maintain invariants: non-active Course cannot have students
    }

    public class Encapsulated_Course
    {
        public bool IsActive { get; private set; }

        public int NumberOfStudents { get; private set; }

        public void Disable()
        {
            IsActive = false;
            NumberOfStudents = 0;
        }

        // reduce public api area
    }


    // ef core often requires you to compromise on encapsulation
    // Separation of concerns is not about disregarding EF Core or the database.
    // It's about being able to reason about these components independently.
    // This way, you would use the number of things you need to keep in mind simultaneously, which greatly simplifies the development process.
}
