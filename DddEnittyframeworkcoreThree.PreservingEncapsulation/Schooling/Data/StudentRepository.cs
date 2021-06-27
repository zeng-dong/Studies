﻿using DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Data
{
    public class StudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public Student GetById(long studentId)
        {
            Student student = _context.Students.Find(studentId);
            if (student == null) return null;

            _context.Entry(student).Collection(x => x.Enrollments).Load();

            return student;
        }
    }
}
