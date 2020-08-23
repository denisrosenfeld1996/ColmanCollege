using ColmanCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColmanCollege.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return; // DB is full already
            }
            var students = new Student[]
            {
                new Student{FirstName="Shay",LastName="Horovitz",EnrollmentDate=DateTime.Parse("2020-09-09")},
                new Student{FirstName="Adi",LastName="Zano",EnrollmentDate=DateTime.Parse("2020-09-09")},
                new Student{FirstName="Yarin",LastName="Meron",EnrollmentDate=DateTime.Parse("2020-09-09")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            var courses = new Course[]
            {
                new Course{CourseID=100,Title="Infiniticimal Calculus",Credits=5},
                new Course{CourseID=200,Title="Database Systems",Credits=3},
                new Course{CourseID=300,Title="Makrame",Credits=2},

            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
           {
                new Enrollment{StudentID=1,CourseID=100,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=300,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=100,Grade=Grade.B},

           };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

        }

    }
}
