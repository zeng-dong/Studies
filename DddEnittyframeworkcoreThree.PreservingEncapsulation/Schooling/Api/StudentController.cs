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

        public string DisenrollStudent(long studentId, long courseId)
        {
            Student student = _studentRepository.GetById(studentId);

            if (student == null) return "Student not found";

            Course course = Course.FromId(courseId);
            if (course == null) return "Course not found";

            student.Disenroll(course);

            _context.SaveChanges();

            return "OK";
        }

        public string RegisterStudent(
            string name, string email,
            long favoriteCourseId, Grade favoriteCourseGrade)
        {
            Course favoriteCourse = Course.FromId(favoriteCourseId);
            if (favoriteCourse == null)
                return "Course not found";

            var student = new Student(name, email, favoriteCourse, favoriteCourseGrade);

            _context.Attach(student);       // or _context.Update(student);  but .......
                                            //  always prefer Attach over Update or Add
            _context.SaveChanges();

            return "OK";
        }
    }
}
