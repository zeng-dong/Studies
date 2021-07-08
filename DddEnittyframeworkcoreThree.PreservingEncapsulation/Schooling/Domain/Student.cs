using DddEnittyframeworkcoreThree.PreservingEncapsulation.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DddEnittyframeworkcoreThree.PreservingEncapsulation.Schooling.Domain
{
    public class Student : Entity     //  class cannot be sealed if lazy loading
    {
        private ILazyLoader _lazyLoader;

        public virtual Name Name { get; private set; }
        public Email Email { get; private set; }
        //public long FavoriteCourseId { get; private set; }

        // virtual here to enable lazy loading
        public virtual Course FavoriteCourse { get; private set; }

        // traditional way to o2m
        //public virtual ICollection<Enrollment> Enrollments { get; set; }

        // using backing field to encapsulate, once hidden, introduce a public method
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();


        // private readonly ICollection<Enrollment> _enrollments
        // public virtual IEnumerable<Enrollment> Enrollments



        public string EnrollIn(Course course, Grade grade)
        {
            if (_enrollments.Any(x => x.Course == course))
                return $"Already enrolled in course '{course.Name}'";

            var enrollment = new Enrollment(course, this, grade);
            _enrollments.Add(enrollment);

            return "OK";
        }

        public void Disenroll(Course course)
        {
            Enrollment enrollment = _enrollments.FirstOrDefault(x => x.Course == course);

            if (enrollment == null)
                return;

            _enrollments.Remove(enrollment);
        }

        //public Course FavoriteCourse
        //{
        //    get => _lazyLoader.Load(this, ref, _favoriteCourse);
        //}


        //public Student(string name, string email, long favoriteCouseId)
        //{
        //    Name = name;
        //    Email = email;
        //    FavoriteCourseId = favoriteCouseId;
        //}


        public Student(Name name, Email email, Course favoriteCouse, Grade favoriteCourseGrade) : this()
        {
            Name = name;
            Email = email;
            FavoriteCourse = favoriteCouse;

            EnrollIn(favoriteCouse, favoriteCourseGrade);
        }


        // so this is a violation of separation of concern, this ctor is persistence/orm concern

        // efc lazy loading requires non-private parameter-less ctor so we change it to protected

        protected Student()    // but efc 3.x not smart enough to supply non-primative type parameters, so when we use Course in ctor, we need the parameter-less ctor
        {

        }

        // there is another way to do lazy loading: inject a ILazyLoader in ctor and use it, this is a terrible idea
        //private Student(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}

        public void EditPersonalInfo(Name name, Email email, Course favoriteCourse)
        {
            if (name == null)
                throw new ArgumentNullException();
            if (email == null)
                throw new ArgumentNullException();
            if (favoriteCourse == null)
                throw new ArgumentNullException();

            if (Email != email)
            {
                RaiseDomainEvent(new StudentEmailChangedEvent(Id, email));
            }

            Name = name;
            Email = email;
            FavoriteCourse = favoriteCourse;
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
