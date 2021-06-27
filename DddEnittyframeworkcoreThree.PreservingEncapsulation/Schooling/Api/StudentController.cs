using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data;
using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Api
{
    public sealed class StudentController
    {
        private readonly SchoolContext _context;
        private readonly StudentRepository _studentRepository;

        public StudentController(SchoolContext context)
        {
            _context = context;
            _studentRepository = new StudentRepository(context);
        }

        public string CheckStudentFavoriteCourse(long studentId, long courseId)
        {
            //Student student = _context.Students.Find(studentId);
            Student student = _studentRepository.GetById(studentId);

            if (student == null) return "Student not found";

            Course course = Course.FromId(courseId);
            if (course == null) return "Course not found";

            return student.FavoriteCourse == course ? "Yes" : "No";
        }

        public string AddEnrollment(long studentId, long courseId, Grade grade)
        {
            Student student = _context.Students.Find(studentId);
            if (student == null) return "Student not found";

            Course course = Course.FromId(courseId);
            if (course == null) return "Course not found";


            //student.Enrollments.Add(new Enrollment(course, student, grade));  ===>
            string result = student.EnrollIn(course, grade);
            _context.SaveChanges();

            return result;
        }
    }
}
